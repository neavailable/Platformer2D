using System;
using TMPro;
using UnityEngine;


namespace UI
{
    [RequireComponent(typeof(TMP_Dropdown))]
    
    public class ColorOptions : MonoBehaviour
    {
        public Action<int> ColorChanged;
        
        private TMP_Dropdown _dropdown;

        
        private void Start()
        {
            _dropdown = GetComponent<TMP_Dropdown>();    
        }

        public void OnColorChanged()
        {
            Debug.Log(_dropdown.value);
            ColorChanged?.Invoke(_dropdown.value);
        }
    }	
}