using System;
using System.Collections.Generic;
using UnityEngine;


namespace Shop
{
    public class Shop : MonoBehaviour
    {
        public Action<Weapon> WeaponBought;
        
        [SerializeField] private List<Sell> _sells;


        private void OnEnable()
        {
            foreach (Sell sell in _sells) sell.SellAction += OnWeaponBought;
        }

        private void OnWeaponBought(Weapon weapon)
        {
            WeaponBought?.Invoke(weapon);
        }
        
        private void OnDisable()
        {
            foreach (Sell sell in _sells) sell.SellAction -= OnWeaponBought;
        }
    }	
}