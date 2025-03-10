using UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Game
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private StartGame _startGame;
        [SerializeField] private AboutUs _aboutUs;
        [SerializeField] private SceneAsset _mainScene, _aboutUsScene;
        

        private void OnEnable()
        {
            _startGame.GameStarted += LoadMainScene;
            _aboutUs.ShowAboutUs   += LoadAboutUsScene;
        }

        private void LoadMainScene()
        {
            SceneManager.LoadScene(_mainScene.name);
        }
        
        private void LoadAboutUsScene()
        {
            SceneManager.LoadScene(_aboutUsScene.name);
        }
        
        private void OnDisable()
        {
            _startGame.GameStarted -= LoadMainScene;
            _aboutUs.ShowAboutUs   -= LoadAboutUsScene;
        }
    }	
}