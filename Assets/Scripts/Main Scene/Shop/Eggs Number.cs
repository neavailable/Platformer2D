using TMPro;
using UnityEngine;


namespace Shop
{
    [RequireComponent(typeof(TMP_Text))]
    
    public class EggsNumber : MonoBehaviour
    {
        [SerializeField] private Player.Wallet _wallet;
        private TMP_Text _text;

        
        private void OnEnable()
        {
            _wallet.MoneyChanged += ChangeEggsNumber;
        }

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
            _text.text = _wallet.MaxMoney.ToString();
        }
        
        private void ChangeEggsNumber(int eggs)
        {
            _text.text = eggs.ToString();
        }
        
        private void OnDisable()
        {
            _wallet.MoneyChanged -= ChangeEggsNumber;
        }
    }	
}