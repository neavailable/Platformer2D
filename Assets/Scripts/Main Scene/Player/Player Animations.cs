using UnityEngine;


namespace Player
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Animator))]

    public class PlayerAnimations : MonoBehaviour
    {
        private const float _attackAnimationTime = 0.45f;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private States _currentState;
        private float _currentTime;
        

        private void Start()
        {
            _animator = GetComponentInParent<Animator>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _currentState = States.Idle;
            _currentTime = Time.time;
        }

        public void SetIdleAnimation()
        {   
            _currentState = States.Idle;
            SetCurrentAnimation();
        }
        
        public void SetRunAnimation(bool flipLeft)
        {
            Flip(flipLeft); 
            
            _currentState = States.Run;
            SetCurrentAnimation();
        }

        public void SetAttackAnimation()
        {
            _currentTime = Time.time;
            
            _currentState = States.Attack;
            SetCurrentAnimation();
        }
        
        public bool CantSetAnimation()
        {
            return IsAttacking();
        }
        
        private void Flip(bool flipLeft)
        {
            if (_spriteRenderer.flipX && !flipLeft)
            {
                _spriteRenderer.flipX = false;
            } 
            else if (!_spriteRenderer.flipX && flipLeft)
            {
                _spriteRenderer.flipX = true;
            }
        }
        
        private bool IsAttacking()
        {
            return _currentState == States.Attack
                   && Time.time - _currentTime <= _attackAnimationTime;
        }
        
        private void SetCurrentAnimation()
        {
            _animator.SetInteger("Current State", (int) _currentState);
        }
        
        private enum States { Idle, Run, Attack };
    }
}