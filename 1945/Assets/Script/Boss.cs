using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss : MonoBehaviour
{
    int flag = 1;
    int speed = 2;

    public GameObject mb;
    public GameObject mb2;
    public Transform pos1;
    public Transform pos2;

    void Start()
    {
        StartCoroutine(BossMissaile());
        StartCoroutine(CircleFire());
    }

    IEnumerator BossMissaile()
    {
        while (true)
        {
            Instantiate(mb, pos1.position, Quaternion.identity);
            Instantiate(mb, pos2.position, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator CircleFire()
    {
        float attackRate = 3;

        int count = 30;

        float intervalAngle = 360 / count;

        float weightAngle = 0f;
        while (true)
        {

            for (int i = 0; i < count; ++i)
            {
                //�߻�ü ����
                GameObject clone = Instantiate(mb2, transform.position, Quaternion.identity);

                //�߻�ü �̵� ����(����)
                float angle = weightAngle + intervalAngle * i;
                //�߻�ü �̵� ����(����)
                //Cos(����)���� ������ ���� ǥ���� ���� pi/180�� ����
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                //sin(����)���� ������ ���� ǥ���� ���� pi/180�� ����
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                //�߻�ü �̵� ���� ����
                clone.GetComponent<BossBullet>().Move(new Vector2(x, y));
            }
            //�߻�ü�� �����Ǵ� ���� ���� ������ ���Ѻ���
            weightAngle += 1;

            //3�ʸ��� �̻��� �߻�
            yield return new WaitForSeconds(attackRate);

        }
    }

    private void Update()
    {
        if (transform.position.x >= 1)
            flag *= -1;
        if (transform.position.x <= -1)
            flag *= -1;

        transform.Translate(flag * Vector2.right * Time.deltaTime * speed);
    }

}
