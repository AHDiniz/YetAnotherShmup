using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class KamikazeMovement : MonoBehaviour
    {
        [SerializeField] private float timeToLockOn;
        [SerializeField] private float chaseSpeed;
        [SerializeField] private float lockOnSpeed;

        private Rigidbody2D _body;
        private bool _lockOn, _prevLockOn;
        private Vector2 _velocity;
        private float _timer;
        private GameObject _player;
        private Vector3 _lockOnDir;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _body = GetComponent<Rigidbody2D>();
            _prevLockOn = _lockOn = false;
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            _lockOn = _timer >= timeToLockOn;

            Transform pTransform = _player.transform;
            Vector3 dir = pTransform.position - transform.position;
            
            if (_prevLockOn != _lockOn)
            {
                _lockOnDir = dir;
                _lockOnDir.Normalize();
            }

            if (_lockOn)
            {
                _velocity = _lockOnDir * lockOnSpeed;
            }
            else
            {
                _velocity.y = -1;
                _velocity.x = dir.x * chaseSpeed;
                _velocity.Normalize();
                _velocity *= chaseSpeed;
            }

            _body.velocity = _velocity;
            _prevLockOn = _lockOn;
        }
    }
}