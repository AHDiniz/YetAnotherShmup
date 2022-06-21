using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlatformerPhysics : MonoBehaviour
    {
        [SerializeField] private float gravityScale;
        [SerializeField] private float minGroundNormalY = .65f;
        [SerializeField] private LayerMask collisionLayers;

        private bool _grounded;
        private Vector2 _velocity, _targetVelocity, _groundNormal, _moveAlongGround = new Vector2(), _deltaPos, _move;
        private Rigidbody2D _rigidbody;
        private ContactFilter2D _contactFilter;
        private RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
        private List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);
        
        private const float MIN_MOVE_DIST = .001f;
        private const float SHELL_RADIUS = .01f;

        public bool Grounded { get => _grounded; }
        public Vector2 TargetVelocity { get => _targetVelocity; set => _targetVelocity = value; }
        public Vector2 Velocity { get => _velocity; }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _contactFilter.useTriggers = false;
            _contactFilter.SetLayerMask(collisionLayers);
            _contactFilter.useLayerMask = true;
        }

        private void FixedUpdate()
        {
            _velocity += gravityScale * Physics2D.gravity * Time.fixedDeltaTime;
            if (_targetVelocity.y != .0f)
                _velocity.y = _targetVelocity.y;
            _velocity.x = _targetVelocity.x;

            _grounded = false;

            _deltaPos = _velocity * Time.fixedDeltaTime;

            _moveAlongGround.Set(_groundNormal.y, -_groundNormal.x);

            if (_moveAlongGround == Vector2.zero)
                _moveAlongGround.x = 1;

            _move = _moveAlongGround * _deltaPos.x;
            Move(_move, false);

            _move = Vector2.up * _deltaPos.y;
            Move(_move, true);
        }

        private void Move(Vector2 move, bool moveOnY)
        {
            float distance = move.magnitude;
            if (distance >= MIN_MOVE_DIST)
            {
                int count = _rigidbody.Cast(move, _contactFilter, hitBuffer, distance + SHELL_RADIUS);
                
                hitBufferList.Clear();
                for (int i = 0; i < count; ++i)
                    hitBufferList.Add(hitBuffer[i]);

                for (int i = 0; i < hitBufferList.Count; ++i)
                {
                    Vector2 currentNormal = hitBufferList[i].normal;
                    
                    if (currentNormal.y > minGroundNormalY)
                    {
                        _grounded = true;

                        if (moveOnY)
                        {
                            _groundNormal = currentNormal;
                            currentNormal.x = 0;
                        }
                    }

                    float projection = Vector2.Dot(_velocity, currentNormal);
                    if (projection < .0f)
                    {
                        _velocity -= projection * currentNormal;
                    }

                    float modDistance = hitBufferList[i].distance - SHELL_RADIUS;
                    distance = modDistance < distance ? modDistance : distance;
                }
            }
            
            _rigidbody.position += move.normalized * distance;
        }
    }
}
