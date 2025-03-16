using System;
using UnityEngine;


namespace HP
{
    public class Hp : MonoBehaviour
    {
        public Action CharacterDead;

        private Attack.BaseAttack _attackPlayer;
        [Range(10, 150), SerializeField] private int _maxHP;
        private int _currentHP;

        
        public void Constructor(Attack.Attack attackPlayer)
        {
            _attackPlayer = attackPlayer;
            _attackPlayer.DamagePlayer += GetDamage;
        }
        
        protected void Start()
        {
            _currentHP = _maxHP;
        }

        protected void GetDamage(int damage)
        {
            _currentHP -= damage;
            if (_currentHP < 0)
            {
                _currentHP = 0;
                CharacterDead?.Invoke();
            }
        }
        
        private void OnDisable()
        {
            if (_attackPlayer) _attackPlayer.DamagePlayer -= GetDamage;
        }
    }	
}