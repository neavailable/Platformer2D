using System;
using UnityEngine;


namespace UI 
{
    public class QuitGame : MonoBehaviour
    {
        public Action GameQuited;


        public void GameQuit()
        {
            GameQuited?.Invoke();
        }
    }	
}