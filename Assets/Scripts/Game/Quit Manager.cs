using UnityEngine;


namespace Game
{
    public class QuitManager : MonoBehaviour
    {
        [SerializeField] private UI.QuitGame _quitGame;


        private void OnEnable()
        {
            _quitGame.GameQuited += QuitGame;
        }

        private void QuitGame()
        {
            Debug.Log("Quit Game");
        }
        
        private void OnDisable()
        {
            _quitGame.GameQuited -= QuitGame;
        }
    }	
}