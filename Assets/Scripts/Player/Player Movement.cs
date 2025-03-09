using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Range(3f, 7f), SerializeField] private float _speed;
        [Range(7f, 10f), SerializeField] private float _jumpForce;
        private Rigidbody2D _rigidbody;
        private bool _onGround;
    
        
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        public void Move(int direction)
        {
            transform.position += 
                Vector3.right * (direction * _speed * Time.fixedDeltaTime);
        }

        public void Jump()
        {
            if (!_onGround) return;
            
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D collider) => _onGround = true;
        
        private void OnTriggerExit2D(Collider2D collider) => _onGround = false;
    }
}