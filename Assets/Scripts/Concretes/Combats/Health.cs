using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileVania.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int _health;

        public int MaxHealth => maxHealth;

        public event Action<int> OnHealthChanged;
        public event Action OnDeath;
        public bool IsDead => _health < 1;

        private void Awake()
        {
            _health = maxHealth;
        }

        public void TakeHit(Damage attacker)
        {
            if (IsDead) return;
            _health -= attacker.HitDamage;
            OnHealthChanged?.Invoke(_health);
            if (IsDead)
                OnDeath?.Invoke();
        }
    }
}

