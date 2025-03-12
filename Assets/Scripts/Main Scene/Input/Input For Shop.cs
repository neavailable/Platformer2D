using UnityEngine;
using UnityEngine.Serialization;


namespace UserInput
{
    [RequireComponent(typeof(RectTransform), typeof(Canvas))]

    public class InputForShop : MonoBehaviour
    {
        [SerializeField] private GameObject _shop;
        private bool _isOpen;


        private void Start()
        {
            _isOpen = false;
        }
        
        private void EveryFrameInputHandling()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                _isOpen = !_isOpen;
                Time.timeScale = _isOpen ? 0f : 1f;
                _shop.SetActive(_isOpen);
            }
        }
        
        private void Update() => EveryFrameInputHandling();
    }	
}