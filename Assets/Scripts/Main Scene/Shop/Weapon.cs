using UnityEngine;


namespace Shop
{
    public abstract class Weapon : MonoBehaviour
    {
        public int Price { get; protected set; }
        public int Damage { get; protected set; }

        private bool _isBought = false;

        
        public void Buy()
        {
            if (!_isBought) _isBought = true;
        }
    }
}