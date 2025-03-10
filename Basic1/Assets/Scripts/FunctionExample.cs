using UnityEngine;

public class FunctionExample : MonoBehaviour
{
    public void SayHello()
    {
        Debug.Log("Hello! Unity");
    }

    int AdDNumbers(int a, int b)
    {
        return a + b;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SayHello();
        int total = AdDNumbers(3, 5);
        Debug.Log($"Total : {total}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
