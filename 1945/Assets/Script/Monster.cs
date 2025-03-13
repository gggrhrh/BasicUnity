using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Speed = 3;
    public float Delay = 1f;
    public Transform ms1;
    public Transform ms2;
    public GameObject bullet;


    void Start()
    {
        Invoke("CreateBullet", Delay);
    }

    void CreateBullet()
    {
        Instantiate(bullet, ms1.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);

        //¿Á±Õ»£√‚
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

}
