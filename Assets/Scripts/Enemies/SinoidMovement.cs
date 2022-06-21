using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Enemies
{
    public class SinoidMovement : MonoBehaviour
    {
        [SerializeField] private EnemyMovement movement;

        private void Update()
        {
            movement.Tick();
        }
    }
}