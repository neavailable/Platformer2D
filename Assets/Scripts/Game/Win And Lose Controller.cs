using UnityEngine;


namespace Game
{
    public class WinAndLoseController : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverUI;
        [SerializeField] private Player.HP _playerHP;
        

        private void OnEnable()
        {
            _playerHP.PlayerDead += GameOver;
        }
        
        private void Start()
        {
            _gameOverUI.SetActive(false);
        }

        private void GameOver()
        {
            _gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }

        private void OnDisable()
        {
            _playerHP.PlayerDead -= GameOver;
        }
    }	
}