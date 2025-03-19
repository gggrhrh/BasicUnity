using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Monster;
    public GameObject Monster2;
    public GameObject Boss;
    
    public float ss = -2;   //몬스터 생성 x값 처음
    public float es = 2;    //몬스터 생성 x값 끝
    public float StartTime = 1;
    public float SpawnStop = 10;

    bool swi = true;
    bool swi2 = true;

    [SerializeField]
    GameObject textBossWarning;

    private void Awake()
    {
        textBossWarning.SetActive(false);
    }



    void Start()
    {
        StartCoroutine("RandomSpawn");
        Invoke("Stop", SpawnStop);
    }

    IEnumerator RandomSpawn()
    {
        while (swi)
        {
            yield return new WaitForSeconds(StartTime);

            float x = Random.Range(ss, es);

            Instantiate(Monster, new Vector2(x, transform.position.y), Quaternion.identity);         

        }
    }

    IEnumerator RandomSpawn2()
    {
        while (swi2)
        {
            yield return new WaitForSeconds(StartTime + 2);

            float x = Random.Range(ss, es);

            Instantiate(Monster2, new Vector2(x, transform.position.y), Quaternion.identity);

        }
    }

    void Stop()
    {
        swi = false;
        StopCoroutine("RandomSpawn");

        StartCoroutine("RandomSpawn2");

        Invoke("Stop2", SpawnStop + 20);
    }

    void Stop2()
    {
        swi2 = false;
        StopCoroutine("RandomSpawn2");
        textBossWarning.SetActive(true);
        StartCoroutine("Shake");
        //보스 나오기
        Vector3 pos = new Vector3(0, 3, 0);

        GameObject go = Instantiate(Boss, pos, Quaternion.identity);
    }

    IEnumerator Shake()
    {
        int shakeCnt = 15;
        while (shakeCnt > 0)
        {
            CameraShake.instance.CameraShakeShow();
            yield return new WaitForSeconds(0.1f);
            shakeCnt--;
        }
    }

}
