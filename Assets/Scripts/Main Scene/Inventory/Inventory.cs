using System;
using System.Collections.Generic;
using Shop;
using UnityEngine;


namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        public Action<Weapon> ChangedWeapon;
        public Weapon CurrentWeapon { get; private set; }

        [SerializeField] private InventoryManager _inventoryManager;


        
        public void SetFirstCurrentWeapon()
        {              
            InvokeChangedWeapon(currentWeaponIndex : 1);
        }

        public void SetSecondCurrentWeapon()
        {   
            InvokeChangedWeapon(currentWeaponIndex : 2);
        }


        private void InvokeChangedWeapon(int currentWeaponIndex)
        {
           if (_inventoryManager.Weapons.Count < currentWeaponIndex) return;
                                 
            ChangedWeapon?.Invoke
            (
                CurrentWeapon = _inventoryManager.Weapons[currentWeaponIndex - 1]
            );
        }
    }	
}