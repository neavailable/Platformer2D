using System.Collections;
using Shop;
using UnityEngine;


namespace Player
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
    [RequireComponent(typeof(Inventory))]
        
    public class PlayerAnimations : MonoBehaviour
    {
        private const float _attackAnimationTime = 0.5f;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private Inventory _inventory;
        private States _currentState;
        private Weapons _currentWeapon;
        private float _currentTime;

        
        public IEnumerator SetAttackAnimation()
        {
            if (!ShouldAttack()) yield return null;
            

            _currentTime = Time.time;
            
            SetCurrentAnimation(States.Attack);
            SetWeaponAnimation();
            
            yield return new WaitForSeconds(_attackAnimationTime);
            _currentState = States.Idle;
        }
        
        public void SetRunAnimation(bool flipedLeft)
        {
            if (_currentState == States.Attack) return;

            Flip(flipedLeft);
            SetCurrentAnimation(States.Run);
        }
        
        public void SetIdleAnimation()
        {
            if (_currentState == States.Attack) return;
            
            SetCurrentAnimation(States.Idle);
        }
        
        private void OnEnable()
        {
            _inventory = GetComponent<Inventory>();
            _inventory.ChangedWeapon += SetCurrentWeapon;
        }
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _currentState = States.Idle;
            _currentWeapon = Weapons.Empty;
            _currentTime = Time.time;
        }

        private bool ShouldAttack()
        {
            return _currentState != States.Attack &
                   Time.time - _currentTime >= _attackAnimationTime;
        }
        
        private void Flip(bool flipedLeft)
        {
            if (_spriteRenderer.flipX && !flipedLeft)
            {
                _spriteRenderer.flipX = false;
            } 
            
            else if (!_spriteRenderer.flipX && flipedLeft)
            {
                _spriteRenderer.flipX = true;
            }
        }
        
        private void SetCurrentAnimation(States newState)
        {
            _currentState = newState;
            _animator.SetInteger("Current State", (int) _currentState);
        }
        
        private void SetWeaponAnimation()
        {
            _animator.SetInteger("Current Weapon", (int) _currentWeapon);
        }

        private void SetCurrentWeapon(Weapon weapon)
        {
            if (weapon == null) return;
           
            if (weapon is Spear)
            {
                _currentWeapon = Weapons.Spear;
            }
            
            else if (weapon is Sword)
            {
                _currentWeapon = Weapons.Sword;
            }
        }
        
        private void OnDisable()
        {
            _inventory.ChangedWeapon -= SetCurrentWeapon;
        }
        
        private enum States { Idle, Run, Attack }
        private enum Weapons { Empty, Spear, Sword }
    }
}