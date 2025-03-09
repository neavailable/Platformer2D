using System.Collections.Generic;
using UnityEngine;



namespace Background
{
    public class BackgroundsFactory : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _backgroundPrefabs;
        [SerializeField] private GameObject _moveBackground;
        [SerializeField] private Transform _playerTransform;
        
        
        private void Start()
        {
            InstantiateBackgrounds();
        }

        private Transform InstantiateBackground(GameObject backgroundPrefab)
        {
            return Instantiate
            (
                backgroundPrefab,
                backgroundPrefab.transform.position,
                Quaternion.identity
            ).transform;
        }

        private void SetParentForDaughter(MoveBackground parent, Transform daughter)
        {
            daughter.SetParent(parent.transform);
        }
        
        private void InstantiateBackgrounds()
        {
            Transform backgroundLeft, backgroundRight;

            MoveBackground moveBackground;
            
            foreach (GameObject backgroundPrefab in _backgroundPrefabs)
            {
                backgroundLeft  = InstantiateBackground(backgroundPrefab);
                backgroundRight = InstantiateBackground(backgroundPrefab);

                moveBackground = 
                    Instantiate(_moveBackground).GetComponent<MoveBackground>();
                moveBackground.Constructor
                (
                    backgroundLeft,
                    backgroundRight, 
                    _playerTransform
                );
                
                SetParentForDaughter(moveBackground, backgroundLeft);
                SetParentForDaughter(moveBackground, backgroundRight);
            }
        }
    }	
}