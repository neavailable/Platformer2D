using Player;
using UnityEngine;


namespace Attack
{    
    public class PlayerAttack : BaseAttack
    {
        [SerializeField] private Inventory.Inventory _inventory;
        private const float _attackAnimationTime = 0.5f;

        
        public void Attack()
        {
            if (Time.time - CurrentTime < _attackAnimationTime) return;

            CurrentTime = Time.time;
                
            Debug.Log(_inventory.CurrentWeapon.Damage);
            DamagePlayer?.Invoke(_inventory.CurrentWeapon.Damage);
        }
    }	
}