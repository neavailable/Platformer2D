using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


namespace Health
{
    [RequireComponent(typeof(Image), typeof(HealthChanged))]
    
    public class HealthBar : MonoBehaviour
    {
        [Range(0.01f, 0.1f), SerializeField] private float _hpChangerSpeed;
        private const int _percentK = 100;
        private HealthChanged _healthChange;
        private Image _healthImage;
        private float _hpTarget;
        

        private void OnEnable()
        {
            _healthChange = GetComponent<HealthChanged>();
            _healthChange.HealthChange += UpdateHealthTarget;
        }

        private void Start()
        {
            _healthImage = GetComponent<Image>();
            _hpTarget = _healthImage.fillAmount;
        }

        private void UpdateHealthTarget(int hpNumber)
        {
            _hpTarget = _healthImage.fillAmount + (float) hpNumber / _percentK;
        }

        private void ChangeHp()
        {
            // тут через неточність чисел float може виникнути баг,
            // коли ми безкінечно додаємо та відмнімаємо hpChangerSpeed
            // тому перевіряю по діапазону
            const float range = 0.01f;
            if 
            (
                _healthImage.fillAmount - range < _hpTarget && 
                _healthImage.fillAmount + range > _hpTarget
            )
            {
                Debug.Log(_healthImage.fillAmount);
                return;
            }
            
            
            if (_healthImage.fillAmount > _hpTarget)
            {
                _healthImage.fillAmount -= _hpChangerSpeed * Time.fixedDeltaTime;
            }
            
            else if (_healthImage.fillAmount < _hpTarget)
            {
                _healthImage.fillAmount += _hpChangerSpeed * Time.fixedDeltaTime;
            }
        }
        
        private void FixedUpdate()
        {
            ChangeHp();
        }
        
        private void OnDisable()
        {
            _healthChange.HealthChange -= UpdateHealthTarget;
        }
    }	
}