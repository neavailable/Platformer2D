using Player;
using UnityEngine;


[RequireComponent(typeof(PlayerAnimations), typeof(PlayerMovement))]

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
        if (_playerAnimations.CantSetAnimation())
        {
            Debug.Log("Attacking now");
            return;
        }


        if (Input.GetKey(KeyCode.A))
        {
            _playerAnimations.SetRunAnimation(flipLeft: true);
            _playerMovement.Move(direction: -1);
        }
        
        else if (Input.GetKey(KeyCode.D))
        {
            _playerAnimations.SetRunAnimation(flipLeft: false);
            _playerMovement.Move(direction: 1);
        }
        
        else if (Input.GetKeyDown(KeyCode.Space)) _playerMovement.Jump();

        else _playerAnimations.SetIdleAnimation();

    }

    private void EveryFrameInputHandling()
    {
        if (Input.GetKeyDown(KeyCode.Space)) _playerMovement.Jump();
    }

    private void FixedUpdate() => FixedInputHandling();
    
    private void Update() => EveryFrameInputHandling();
}	