using UnityEngine;
using static UnityEngine.Input;

namespace Shmup.Input
{
    public class PlayerInput
    {
        private Vector2 _movement;
        private bool _jump, _jumpLift, _attack;

        public Vector2 Movement { get => _movement; }
        public bool Jump { get => _jump; }
        public bool JumpLift { get => _jumpLift; }
        public bool Attack { get => _attack; }

        public void UpdateInputs()
        {
            _movement.Set(GetAxis("Horizontal"), GetAxis("Vertical"));
            _jump = GetButton("Jump");
            _attack = GetButton("Fire2");
        }
    }
}
