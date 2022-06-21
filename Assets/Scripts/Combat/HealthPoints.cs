using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Shmup.Combat
{
    public class HealthPoints : MonoBehaviour
    {
        [SerializeField] private int maxHP;
        [SerializeField] private UnityEvent OnDeath;

        private int _currentHP;

        public int CurrentHP { get => _currentHP; }
        public int MaxHP { get => maxHP; }

        public void Hit(int damage)
        {
            _currentHP -= damage;
            _currentHP = Mathf.Clamp(_currentHP, 0, maxHP);
        }

        public void Update()
        {
            if (_currentHP == 0)
                OnDeath.Invoke();
        }
    }
}