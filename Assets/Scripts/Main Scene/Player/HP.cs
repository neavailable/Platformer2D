using System;
using UnityEngine;


namespace Player
{
    public class HP : MonoBehaviour
    {
        public Action PlayerDead;
        
        [Range(80, 150), SerializeField] private int _maxHP;
        private Enemy.Attack _attackPlayer;
        private int _hp;


        public void Constructor(Enemy.Attack attackPlayer)
        {
            _attackPlayer = attackPlayer;
            _attackPlayer.DamagePlayer += GetDamage;
        }
        
        private void Start()
        {
            _hp = _maxHP;
        }

        public void GetDamage(int damage)
        {
            _hp -= damage;
            Debug.Log(_hp);
            if (_hp <= 0)
            {
                _hp = 0;
                PlayerDead?.Invoke();
            }
        }

        private void OnDisable()
        {
            _attackPlayer.DamagePlayer -= GetDamage;
        }
    }	
}