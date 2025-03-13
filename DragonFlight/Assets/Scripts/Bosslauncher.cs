using UnityEngine;

public class Bosslauncher : MonoBehaviour
{
    public GameObject Enemybullet;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if(player != null)
        {
            InvokeRepeating("Shoot1", 5f, 1f);
            InvokeRepeating("Shoot2", 5.5f, 3.5f);
        }
       
    }

    void Shoot1()
    {
        Vector3 moveDir = player.transform.position - transform.position;
        moveDir.y = -moveDir.y;
        moveDir.z = 0f;

        //미사일 프리팹, 런쳐포지션, 방향값 안줌
        GameObject bullet = Instantiate(Enemybullet);
        bullet.transform.position = transform.position;
        Enemybullet Ebullet = bullet.GetComponent<Enemybullet>();
        Ebullet.SetMoveDir(moveDir);
        SoundManager.instance.PlayBulletSound();
    }

    void Shoot2()
    {
        for (int i = 0; i < 9; i++)
        {
            Vector3 moveDir = Vector3.zero;
            moveDir.x = -4 + i;
            moveDir.y = 3;

            GameObject bullet = Instantiate(Enemybullet);
            bullet.transform.position = transform.position;
            Enemybullet Ebullet = bullet.GetComponent<Enemybullet>();
            Ebullet.SetMoveDir(moveDir);
        }
    }

    void Update()
    {
        
    }
}
