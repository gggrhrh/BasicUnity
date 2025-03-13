using UnityEngine;

public class launcher : MonoBehaviour
{
    public GameObject bullet;

    void Start()
    {
        InvokeRepeating("Shoot", 0.5f, 0.5f);
    }

    void Shoot()
    {
        //미사일 프리팹, 런쳐포지션, 방향값 안줌
        Instantiate(bullet, transform.position, Quaternion.identity);
        SoundManager.instance.PlayBulletSound();

    }


    void Update()
    {
        
    }
}
