using System;
using System.Collections;
using UnityEngine;


namespace Enemy
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Animator), typeof(PursuePlayer))]
    
    public class Animations : MonoBehaviour
    {
        private PursuePlayer _pursuePlayer;
        private Animator _animator;
        private const int _damageAnimationDuration = 1;
        private float currentTime;
        
        private void OnEnable()
        {
            _pursuePlayer = GetComponent<PursuePlayer>();
            _pursuePlayer.FoundPlayer += StartAttackAnimation;
            currentTime = 0;
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        
        private void StartAttackAnimation()
        {
            if (Time.time - currentTime < _damageAnimationDuration) return;
            
            currentTime = Time.time;
            _animator.SetBool("Is Attacking", true);
        }
        
        private void OnDisable()
        {
            _pursuePlayer.FoundPlayer -= StartAttackAnimation;
        } 
    }	
}