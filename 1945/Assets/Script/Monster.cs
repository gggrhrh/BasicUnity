using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Speed = 3;
    public float Delay = 1f;
    public Transform ms1;
    public Transform ms2;
    public GameObject bullet;
    public GameObject item;

    void Start()
    {
        Invoke("CreateBullet", Delay);
    }

    void CreateBullet()
    {
        Instantiate(bullet, ms1.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);

        //���ȣ��
        Invoke("CreateBullet", Delay);
    }
    


    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void Damage(int attack)
    {
        ItemDrop();
        Destroy(gameObject);
    }

    public void ItemDrop()
    {
        Instantiate(item, transform.position, Quaternion.identity);
    }

}
