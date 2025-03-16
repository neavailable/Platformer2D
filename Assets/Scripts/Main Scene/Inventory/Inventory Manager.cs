using System.Collections.Generic;
using Shop;
using UnityEngine;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private Shop.Shop _shop;
        public List<Weapon> Weapons { get; private set; }


        private void OnEnable()
        {
            Weapons = new List<Weapon>();
            _shop.WeaponBought += AddWeapon;
        }

        private void AddWeapon(Weapon weapon)
        {
            Weapons.Add(weapon);
        }

        private void OnDisable()
        {
            _shop.WeaponBought -= AddWeapon;
        }
    }
}
