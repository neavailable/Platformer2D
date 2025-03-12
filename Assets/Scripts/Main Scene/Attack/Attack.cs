using UnityEngine;
using Enemy;
using UnityEngine.Serialization;


namespace Attack
{
    [RequireComponent(typeof(PursuePlayer))]
    
    public class Attack : BaseAttack
    {
        [Range(10, 20), SerializeField] private int _damage;
        private PursuePlayer _pursuePlayer;
        private const int _attackAnimationDuration = 1;


        private void OnEnable()
        {
            _pursuePlayer = GetComponent<PursuePlayer>();
            _pursuePlayer.FoundPlayer += StartAttacking;
        }
        
        private void StartAttacking()
        {
            if (Time.time - CurrentTime < _attackAnimationDuration) return;

            CurrentTime = Time.time;
                
            DamagePlayer?.Invoke(_damage);
        }
        
        private void OnDisable()
        {
            _pursuePlayer.FoundPlayer -= StartAttacking;
        }
    }	
}