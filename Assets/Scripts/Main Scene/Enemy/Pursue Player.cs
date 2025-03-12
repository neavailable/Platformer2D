using System;
using System.Collections;
using UnityEngine;


namespace Enemy
{
    public class PursuePlayer : MonoBehaviour
    {
        public Action FoundPlayer;
        
        [Range(1f, 10f), SerializeField] private float _speed;
        private Transform _playerTransform;
        private bool _foundPlayer;


        public void Constructor(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }
        
        private void Start()
        {
            _foundPlayer = false;
        }
        
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<Player.Player>(out Player.Player _))
            {
                _foundPlayer = true;
                FoundPlayer?.Invoke();
            }
        }
        
        private void GoToPlayer()
        {
            float newX = Vector2.MoveTowards
            (
                transform.position,
                _playerTransform.position,
                _speed * Time.fixedDeltaTime
            ).x;
            transform.position = new Vector2(newX, transform.position.y);
        }
        
        private void FixedUpdate()
        {
            if (_foundPlayer) return;
            
            GoToPlayer();
        }
    }	
}