using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Boss;
    bool isBoss = false;
    float CoolBoss = 15f;

    public static SpawnManager inst;

    private void Awake()
    {
        if (inst == null)
            inst = this;
    }

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 0.5f);
        if (isBoss == false)
        {
            Invoke("SpawnBoss", 7);
        }
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-2f, 2f);

        Instantiate(Enemy, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
    }

    void SpawnBoss()
    {
        if (isBoss == true)
            return;

        Instantiate(Boss, new Vector3(0f, 7f, 0f), Quaternion.identity);
        isBoss = true;
    }

    public void DeathBoss()
    {
        isBoss = false;
    }

    void Update()
    {
        
    }
}
