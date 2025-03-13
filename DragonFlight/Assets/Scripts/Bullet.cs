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
        //Y�� �̵�
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        //�̻����� ȭ������� ��������
        //�̻��� ������
        Destroy(gameObject);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�̻��ϰ� ���� �΋H����
        //if(collision.gameObject.tag == "Enemy")
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //���� ����Ʈ ����
            Instantiate(explosion, transform.position, Quaternion.identity);
            //�״� �Ҹ�
            SoundManager.instance.SoundDie();
            //���� ȹ��
            GameManager.instance.AddScore(10);
            //�������
            Destroy(collision.gameObject);
            
           
            //�Ѿ� ����� �ڱ��ڽ�
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Boss"))
        {
            Instantiate(BossHit, transform.position, Quaternion.identity);
            Boss boss = collision.GetComponent<Boss>();
            boss.TakeDamage(10);
            //�Ѿ� ����� �ڱ��ڽ�
            Destroy(gameObject);
        }
       

    }

}
