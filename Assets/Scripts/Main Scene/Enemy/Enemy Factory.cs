using System.Collections;
using UnityEngine;
using HP;


namespace Enemy
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private Transform _firstSpawnPoint, _secondSpawnPoint;
        [SerializeField] private Transform _playerTransform;
        [Range(2, 4), SerializeField] private int _enemiesInWave;
        [Range(7f, 30f), SerializeField] private float _breakBetweenWaves;
        

        private void Start()
        {
            StartCoroutine(InstantiateEnemies());
        }

        private GameObject InstantiateEnemy(Vector2 position)
        {
            return Instantiate
            (
                _enemyPrefab,
                position, 
                Quaternion.identity
            );
        }
        
        private IEnumerator InstantiateEnemies()
        {
            while (true)
            {
                for (int i = 0; i < _enemiesInWave; ++i)
                {
                    float randomValue = Random.Range(0f, 1f);
                    Vector3 randomPosition = Vector3.Lerp
                    (
                        _firstSpawnPoint.position,
                        _secondSpawnPoint.position,
                        randomValue
                    );

                    GameObject enemy = InstantiateEnemy(randomPosition);
                    
                    PursuePlayer pursuePlayer = enemy.GetComponent<PursuePlayer>();
                    Hp playerPlayerHp = _playerTransform.GetComponent<Hp>();
                    Attack.Attack enemyAttack = enemy.GetComponent<Attack.Attack>();
                    
                    pursuePlayer.Constructor(_playerTransform);
                    playerPlayerHp.Constructor(enemyAttack);
                }
                

                yield return new WaitForSeconds(_breakBetweenWaves);
            }
        }
    }	
}