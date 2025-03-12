using System;
using UnityEngine;
using UnityEngine.Serialization;


namespace Attack
{
    public class BaseAttack : MonoBehaviour
    {
        public Action<int> DamagePlayer;
        
        protected float CurrentTime;
    }	
}