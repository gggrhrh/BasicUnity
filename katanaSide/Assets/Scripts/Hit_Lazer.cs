using UnityEngine;

public class Hit_Lazer : MonoBehaviour
{
    float Speed = 50f;
    Vector2 MousePos;
    Transform tr;
    Vector3 dir;

    float angle;
    Vector3 dirNo;

    void Start()
    {
        tr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        MousePos = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);        //스크린 좌표를 월드 좌표로 변환
        Vector3 Pos = new Vector3(MousePos.x, MousePos.y, 0);
        dir = Pos - tr.position;    //방향 벡터
        
      
        //방향회전
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //단위벡터
        dirNo = new Vector3(dir.x, dir.y, 0).normalized;

        Destroy(gameObject, 4f);
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.position += dirNo * Speed * Time.deltaTime;
    }
}
