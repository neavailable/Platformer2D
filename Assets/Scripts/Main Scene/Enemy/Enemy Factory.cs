using System.Collections;
using UnityEngine;


namespace Enemy
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private Transform _firstSpawnPoint, _secondSpawnPoint;
        [SerializeField] private Transform _playerTransform;
        [Range(2, 4), SerializeField] private int _enemiesInWave;
        [Range(7f, 10f), SerializeField] private float _breakBetweenWaves;
        

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
            float randomValue;
            Vector3 randomPosition;

            while (true)
            {
                for (int i = 0; i < _enemiesInWave; ++i)
                {
                    randomValue = Random.Range(0f, 1f);
                    randomPosition = Vector3.Lerp
                    (
                        _firstSpawnPoint.position,
                        _secondSpawnPoint.position,
                        randomValue
                    );

                    GameObject enemy = InstantiateEnemy(randomPosition);
                    
                    PursuePlayer pursuePlayer = enemy.GetComponent<PursuePlayer>();
                    Player.HP playerHP = _playerTransform.GetComponent<Player.HP>();
                    Attack enemyAttack = enemy.GetComponent<Attack>();
                    
                    pursuePlayer.Constructor(_playerTransform);
                    playerHP.Constructor(enemyAttack);
                }
                

                yield return new WaitForSeconds(_breakBetweenWaves);
            }
        }
    }	
    
}