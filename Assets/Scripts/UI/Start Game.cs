using System;
using UnityEngine;


namespace UI 
{
    public class StartGame : MonoBehaviour
    {
        public Action GameStarted;


        public void GameStart()
        {
            GameStarted?.Invoke();
        }
    }	
}