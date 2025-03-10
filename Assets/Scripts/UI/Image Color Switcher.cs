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
            _image.color = _colors[colorIndex];
        }
        
        private void OnDisable()
        {
            _colorOptions.ColorChanged -= ChangeImageColor;
        }
    }	
}