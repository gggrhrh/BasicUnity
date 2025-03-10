using UnityEngine;

public class VariableExample : MonoBehaviour    //오브젝트에 붙여줘야 되는 상속클래스
{

    public int playerScore = 0;
    public float speed = 5.5f;
    public string playerName = "Hero";
    public bool isGameOver = false;
    

  
    void Start()
    {
        Debug.Log("Player Name : " + playerName);
        Debug.Log("Player Score : " + playerScore);
        Debug.Log("Speed : " + speed);
        Debug.Log("Is Game Over? : " + isGameOver);
    }

  
}
