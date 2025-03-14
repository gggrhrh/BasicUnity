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
            //����Ʈ ���� �� ����
            GameObject go = Instantiate(Effect, transform.position, Quaternion.identity);
            
            Destroy(go, 1f);

            //���� ����
            collision.gameObject.GetComponent<Monster>().Damage(10);


            Destroy(collision.gameObject);

            Destroy(gameObject);

        }
    }

}
