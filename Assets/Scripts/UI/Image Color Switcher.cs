using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace UI
{
    [RequireComponent(typeof(Image))]
    
    public class ImageColorSwitcher : MonoBehaviour
    {
        [SerializeField] private ColorOptions _colorOptions;
        private List<Color> _colors;
        private Image _image;
        

        private void OnEnable()
        {
            _colors = new List<Color>() { Color.black, Color.green };
            _image = GetComponent<Image>();
            
            _colorOptions.ColorChanged += ChangeImageColor;
        }

        private void ChangeImageColor(int colorIndex)
        {
            Debug.Log(colorIndex);
            Debug.Log(_colors[colorIndex]);
            _image.color = _colors[colorIndex];
            Debug.Log(_image.color );
        }
        
        private void OnDisable()
        {
            _colorOptions.ColorChanged -= ChangeImageColor;
        }
    }	
}