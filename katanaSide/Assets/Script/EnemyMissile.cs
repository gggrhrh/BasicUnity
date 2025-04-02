using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 3f;
    public int damage = 10;
    private Vector2 direction;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    public Vector2 GetDirection()
    {
        return direction;
    }


    void Update()
    {
        float timeScale = TimeController.Instance.GetTimeScale();
        
        transform.Translate(direction * speed * Time.deltaTime * timeScale);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
        else if (other.CompareTag("Enemy"))
        {
            ShootingEnemy enemy = other.GetComponent<ShootingEnemy>();
            if (enemy != null)
                enemy.PlayDeathAnimation();
        }

    }
}
