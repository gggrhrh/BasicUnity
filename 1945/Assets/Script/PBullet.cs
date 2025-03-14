using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float Speed = 4.0f;

    public GameObject Effect;

    void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);   
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            //이펙트 생성 및 삭제
            GameObject go = Instantiate(Effect, transform.position, Quaternion.identity);
            
            Destroy(go, 1f);

            //몬스터 삭제
            collision.gameObject.GetComponent<Monster>().Damage(10);


            Destroy(collision.gameObject);

            Destroy(gameObject);

        }
    }

}
