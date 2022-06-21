using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shmup.Input;

namespace Shmup.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float flightSpeed;

        private PlayerInput _input;
        private Rigidbody2D _body;

        private void Start()
        {
            _body = GetComponent<Rigidbody2D>();
            _input = new PlayerInput();
        }

        private void Update()
        {
            _input.UpdateInputs();
            _body.velocity = _input.Movement * flightSpeed;
        }
    }
}