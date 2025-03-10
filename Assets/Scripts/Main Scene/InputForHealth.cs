using UnityEngine;


[RequireComponent(typeof(Health.HealthChanged))]

public class InputForHealth : MonoBehaviour
{
    private Health.HealthChanged _helthChange;


    private void Start()
    {
        _helthChange = GetComponent<Health.HealthChanged>();
    }

    private void EveryFrameInputHandling()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) _helthChange.IncreaseHealth();
        
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) _helthChange.ReduceHealth();
    }

    private void Update()
    {
        EveryFrameInputHandling();
    }
}	