using System;
using UnityEngine;


namespace Player
{
    public class Player : MonoBehaviour
    {
        public Action PlayerDeath;
        
        
        public void Suicide() => PlayerDeath?.Invoke();
    }
}