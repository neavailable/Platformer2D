using Player;
using UnityEngine;


namespace Attack
{
    [RequireComponent(typeof(Inventory))]
    
    public class PlayerAttack : BaseAttack
    {
        private Inventory _inventory;
        private const float _attackAnimationTime = 0.5f;


        private void Start()
        {
            _inventory = GetComponent<Inventory>();
        }
        
        public void Attack()
        {
            if (Time.time - CurrentTime < _attackAnimationTime) return;

            CurrentTime = Time.time;
                
            Debug.Log(_inventory.CurrentWeapon.Damage);
            DamagePlayer?.Invoke(_inventory.CurrentWeapon.Damage);
        }
    }	
}