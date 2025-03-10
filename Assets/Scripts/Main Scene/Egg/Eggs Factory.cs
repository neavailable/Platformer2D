using UnityEngine;
using System.Collections.Generic;


namespace Egg
{
    public class EggsFactory : MonoBehaviour
    {
        [SerializeField] private List<Transform> _eggsPositions;
        [SerializeField] private GameObject _eggPrefab;
        [Range(1, 7), SerializeField] private int _eggsNumber;
        
        
        private void Start()
        {
            RegulateEggsNumber();
            
            InstantiateEggs();
        }

        private void RegulateEggsNumber()
        {
            if (_eggsNumber > _eggsPositions.Count)
            {
                _eggsNumber = _eggsPositions.Count;
            }
        }

        private void InstantiateEggs()
        {
            for (int i = 0; i < _eggsNumber; i++)
            {
                Instantiate
                (
                    _eggPrefab,
                    _eggsPositions[i].position,
                    Quaternion.identity
                );
            }
        }
    }	
}