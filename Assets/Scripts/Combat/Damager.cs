using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Combat
{
    public class Damager : MonoBehaviour
    {
        [SerializeField] private int damagePoints;
        [SerializeField] private LayerMask targetLayer;

        public int DamagePoints { get => damagePoints; }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (gameObject.layer == targetLayer)
            {
                HealthPoints hp = col.gameObject.GetComponent<HealthPoints>();

                if (hp != null)
                {
                    hp.Hit(damagePoints);
                }
            }
        }
    }
}