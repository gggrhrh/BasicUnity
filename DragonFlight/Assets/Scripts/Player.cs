using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    int hp = 3;

    void Start()
    {

    }

    void Update()
    {
        MoveControl();
    }

    void MoveControl()
    {
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        transform.Translate(distanceX, 0, 0);
    }

    public void TakeDamage()
    {
        hp--;

        if (hp <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Destroy(gameObject);
    }

}
