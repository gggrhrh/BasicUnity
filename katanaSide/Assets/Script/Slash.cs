using UnityEngine;

public class Slash : MonoBehaviour
{
    private GameObject p;
    Vector2 MousePos;
    Vector3 dir;



    float angle;
    Vector3 dirNo;



    public Vector3 direction = Vector3.right;


    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player");

        Transform tr = p.GetComponent<Transform>();
        MousePos = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);
        Vector3 Pos = new Vector3(MousePos.x, MousePos.y, 0);
        dir = Pos - tr.position;


        //바라보는 각도 구하기
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;



    }


    void Update()
    {
        //회전적용
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        transform.position = p.transform.position;
    }


    public void Des()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyMissile>() != null)
        {
            EnemyMissile missile = collision.gameObject.GetComponent<EnemyMissile>();
            SpriteRenderer missileSprite = collision.gameObject.GetComponent<SpriteRenderer>();

            //현재 방향의 정반대 방향으로 설정
            Vector2 reverseDir = -missile.GetDirection();

            //미사일의 새로운 방향
            missile.SetDirection(reverseDir);

            //스프라이트 변경
            missileSprite.flipX = !missileSprite.flipX;
        }
    }


}
