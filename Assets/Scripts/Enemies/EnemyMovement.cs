using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private AnimationCurve xMovement;
        [SerializeField] private AnimationCurve yMovement;

        private Rigidbody2D _body;
        private float _t = .0f;
        private Vector2 _velocity = new Vector2();

        private void Start()
        {
            _body = GetComponent<Rigidbody2D>();
        }

        public void Tick()
        {
            _t += Time.deltaTime;
            _velocity.x = xMovement.Evaluate(_t);
            _velocity.y = yMovement.Evaluate(_t);
            _body.velocity = _velocity;
        }
    }
}