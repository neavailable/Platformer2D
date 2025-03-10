using UnityEngine;


namespace Game
{
    public class WinAndLoseController : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverUI;
        [SerializeField] private Player.Player _player;
        

        private void OnEnable()
        {
            _player.PlayerDeath += GameOver;
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
            _player.PlayerDeath -= GameOver;
        }
    }	
}