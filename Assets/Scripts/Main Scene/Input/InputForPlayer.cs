using Attack;
using Player;
using UnityEngine;


namespace UserInput
{
    [RequireComponent(typeof(PlayerAnimations), typeof(PlayerMovement))]
    [RequireComponent(typeof(InputForPlayer))]

    public class InputForPlayer : MonoBehaviour
    {
        private PlayerAnimations _playerAnimations;
        private PlayerMovement _playerMovement;
        

        private void Start()
        {
            _playerAnimations = GetComponent<PlayerAnimations>();
            _playerMovement   = GetComponent<PlayerMovement>();
        }

        private void FixedInputHandling()
        {
            if (Input.GetKey(KeyCode.A))
            {
                _playerAnimations.SetRunAnimation(flipedLeft: true);
                _playerMovement.Move(direction: -1);
            }

            else if (Input.GetKey(KeyCode.D))
            {
                _playerAnimations.SetRunAnimation(flipedLeft: false);
                _playerMovement.Move(direction: 1);
            }

            else if (Input.GetKeyDown(KeyCode.Space)) _playerMovement.Jump();

            else _playerAnimations.SetIdleAnimation();
        }

        private void EveryFrameInputHandling()
        {
            if (Input.GetKeyDown(KeyCode.Space)) _playerMovement.Jump();
            
            else if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(_playerAnimations.SetAttackAnimation());
            }
        }

        private void FixedUpdate() => FixedInputHandling();

        private void Update() => EveryFrameInputHandling();
    }
}