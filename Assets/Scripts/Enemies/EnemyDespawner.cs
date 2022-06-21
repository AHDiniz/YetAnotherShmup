using UnityEngine;

namespace Shmup.Enemies
{
    public class EnemyDespawner : MonoBehaviour
    {
        [SerializeField] private LayerMask enemyLayer;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.layer == enemyLayer)
            {
                col.gameObject.SetActive(false);
            }
        }
    }
}