using System;
using Shop;
using UnityEngine;
using UnityEngine.Serialization;


namespace Player
{
    public class Wallet : MonoBehaviour
    {
        public Action<int> MoneyChanged;
        public int MaxMoney => _maxMoney;

        [Range(10, 30), SerializeField] private int _maxMoney;
        [SerializeField] private Shop.Shop _shop;
        private int _money;


        private void OnEnable()
        {
            _shop.WeaponBought += BuyWeapon;
        }
        
        private void Start()
        {
            _money = _maxMoney;   
        }

        private void BuyWeapon(Weapon weapon)
        {
            if (_money - weapon.Price < 0) return;
            
            _money -= weapon.Price;
            MoneyChanged?.Invoke(_money);
        }
        
        private void OnDisable()
        {
            _shop.WeaponBought -= BuyWeapon;
        }
    }
}