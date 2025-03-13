using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 0.45f;
    public GameObject explosion;
    public GameObject BossHit;

    void Start()
    {
      
    }


    void Update()
    {
        //Y축 이동
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        //미사일이 화면밖으로 나갔으면
        //미사일 지우자
        Destroy(gameObject);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //미사일과 적이 부딫혔다
        //if(collision.gameObject.tag == "Enemy")
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //폭발 이펙트 생성
            Instantiate(explosion, transform.position, Quaternion.identity);
            //죽는 소리
            SoundManager.instance.SoundDie();
            //점수 획득
            GameManager.instance.AddScore(10);
            //적지우기
            Destroy(collision.gameObject);
            
           
            //총알 지우기 자기자신
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Boss"))
        {
            Instantiate(BossHit, transform.position, Quaternion.identity);
            Boss boss = collision.GetComponent<Boss>();
            boss.TakeDamage(10);
            //총알 지우기 자기자신
            Destroy(gameObject);
        }
       

    }

}
