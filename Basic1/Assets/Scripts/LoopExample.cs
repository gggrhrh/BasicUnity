using UnityEngine;

public class LoopExample : MonoBehaviour
{

    void Start()
    {

        //for(int i = 1; i <=10; i++)
        //{
        //    Debug.Log("Count : " + i);
        //}

        int counter = 0;
        while(counter <5)
        {
            Debug.Log("While Count : " + counter);
            counter++;
        }


    }


}
