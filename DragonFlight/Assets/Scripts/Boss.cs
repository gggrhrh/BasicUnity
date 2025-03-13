using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject Bossexplosion;

    float moveSpeed = 1f;
    float Hp = 300f;

    void Start()
    {
    
    }

    void Update()
    {
        Move();
        
    }
    
    void Move()
    {
        if (transform.position.y <= 3.5)
            return;

        transform.position += Vector3.down * Time.deltaTime * moveSpeed;
    }

    public void TakeDamage(int damage)
    {
        Hp -= damage;

        if(Hp <= 0)
        {
            SpawnManager.inst.DeathBoss();
            //Æø¹ß ÀÌÆåÆ® »ý¼º
            Instantiate(Bossexplosion, transform.position, Quaternion.identity);
            //Á×´Â ¼Ò¸®
            SoundManager.instance.SoundDie();
            //Á¡¼ö È¹µæ
            GameManager.instance.AddScore(100);
            //º¸½º Á×À½ »èÁ¦
            Destroy(gameObject);
        }
    }


}
