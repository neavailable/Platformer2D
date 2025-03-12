using UnityEngine;


namespace Game
{
    public class QuitManager : MonoBehaviour
    {
        [SerializeField] private UI.QuitGame _quitGame;


        private void OnEnable()
        {
            _quitGame.GameQuit += QuitGame;
        }

        private void QuitGame()
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }
        
        private void OnDisable()
        {
            _quitGame.GameQuit -= QuitGame;
        }
    }	
}