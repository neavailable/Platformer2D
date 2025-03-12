using System;
using UnityEngine;


namespace Shop 
{
    [RequireComponent(typeof(Weapon))]
    
    public class Sell : MonoBehaviour
    {
        public Action<Weapon> SellAction;

        private Weapon weapon;


        private void Start()
        {
            weapon = GetComponent<Weapon>();
        }
        
        public void OnSell()
        {
            weapon.Buy();
            SellAction?.Invoke(weapon);
        }
    }	
}