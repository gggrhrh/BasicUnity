using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    Vector3 moveDir;
    public float moveSpeed = 1.0f;

    void Start()
    {
        Debug.Log(moveDir);
    }

    void Update()
    {
        //Y축 이동
        transform.Translate(moveDir * Time.deltaTime * moveSpeed);
    }

    public void SetMoveDir(Vector3 movedir)
    {
        moveDir = movedir;
    }

    private void OnBecameInvisible()
    {
        //미사일이 화면밖으로 나갔으면
        //미사일 지우자
        Destroy(gameObject);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            player.TakeDamage();

            Destroy(gameObject);
        }
    }

}
