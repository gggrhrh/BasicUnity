using System.Collections;
using UnityEngine;

public class CoroutineStudy : MonoBehaviour
{

    // C# 유니티 코루틴(Coroutine) 정리
    //코루틴은 일반적인 함수와 달리 실행을 멈췄다가 다시 이어서 실행할 수 있는 기능이야.
    //이를 이용하면 일정 시간 후 실행되거나, 특정 조건을 기다리는 동의 기능을 쉽게 구현할 수 있다.!

    void Start()
    {
        //  StartCoroutine("ExampleCoroutine");
        StartCoroutine(ExampleCoroutine());
    }


    IEnumerator ExampleCoroutine()
    {
        while (true)
        {
            Debug.Log("매 1초마다 실행!");
            yield return new WaitForSeconds(1f);   //2초대기
        }
    }

}
