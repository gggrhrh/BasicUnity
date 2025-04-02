using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 5f;
    private float _timer;

    void Start()
    {
        
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if( _timer > spawnInterval )
        {
            SpawnRandomEnemy();
            _timer = 0;
        }
    }

    private void SpawnRandomEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));

        EnemyType randomType = (EnemyType)Random.Range(0, 3);

        IEnemy enemy = EnemyFactory.Instance.CreateEnemy(randomType, spawnPosition);
        Debug.Log($"{randomType} 적이 {spawnPosition}에 생성되었습니다.");
    }
}
