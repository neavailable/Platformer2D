using System;
using System.Collections;
using UnityEngine;


namespace Enemy
{
    [RequireComponent(typeof(PursuePlayer))]
    
    public class Attack : MonoBehaviour
    {
        public Action<int> DamagePlayer;
        
        [Range(10, 20), SerializeField] private int _damage;
        private PursuePlayer _pursuePlayer;
        private const int _damageAnimationDuration = 1;
        private float currentTime;


        private void OnEnable()
        {
            _pursuePlayer = GetComponent<PursuePlayer>();
            _pursuePlayer.FoundPlayer += StartAttacking;
        }
        
        private void StartAttacking()
        {
            if (Time.time - currentTime < _damageAnimationDuration) return;

            currentTime = Time.time;
                
            DamagePlayer?.Invoke(_damage);
        }
        
        private void OnDisable()
        {
            _pursuePlayer.FoundPlayer -= StartAttacking;
        }
    }	
}