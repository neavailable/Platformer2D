using System;
using System.Collections.Generic;
using Shop;
using UnityEngine;


namespace Player
{
    public class Inventory : MonoBehaviour
    {
        public Action<Weapon> ChangedWeapon;
        public Weapon CurrentWeapon { get; private set; }

        [SerializeField] private Shop.Shop _shop;
        private List<Weapon> _weapons;


        private void OnEnable()
        {
            _shop.WeaponBought += AddWeapon;
        }

        private void Start()
        {
            _weapons = new List<Weapon>();
        }

        public void SetCurrentWeapon(int index)
        {
            if (index - 1 >= _weapons.Count) return;
            
            CurrentWeapon = _weapons[index - 1];
            ChangedWeapon?.Invoke(CurrentWeapon);
        }
        
        private void AddWeapon(Weapon weapon)
        {
            _weapons.Add(weapon);
        }
        
        private void OnDisable()
        {
            _shop.WeaponBought -= AddWeapon;
        }
    }	
}