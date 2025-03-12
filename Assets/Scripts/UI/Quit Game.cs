using System;
using UnityEngine;


namespace UI 
{
    public class QuitGame : MonoBehaviour
    {
        public Action GameQuit;


        public void OnGameQuit()
        {
            GameQuit?.Invoke();
        }
    }	
}