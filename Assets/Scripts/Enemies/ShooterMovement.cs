using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Enemies
{
    public class ShooterMovement : MonoBehaviour
    {
        [SerializeField] private Vector2 waitTimeRange = new Vector2();
        [SerializeField] private EnemyMovement goDownMovement;
        [SerializeField] private EnemyMovement shootingMovement;

        private float _waitTime, _timer;

        private void Start()
        {
            _waitTime = Random.Range(waitTimeRange.x, waitTimeRange.y);
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _waitTime)
                shootingMovement.Tick();
            else
                goDownMovement.Tick();
        }
    }
}