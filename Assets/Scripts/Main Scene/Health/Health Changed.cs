using System;
using UnityEngine;


namespace Health
{
    public class HealthChanged : MonoBehaviour
    {
        public Action<int> HealthChange; 
        
        private const int _hpNumber = 10; 
        
        
        public void IncreaseHealth()
        {
            HealthChange?.Invoke(_hpNumber);
        }
        
        public void ReduceHealth()
        {
            HealthChange?.Invoke(-_hpNumber);
        }
    }	
}