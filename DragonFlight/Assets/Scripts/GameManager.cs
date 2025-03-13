using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text ScoreText;
    public Text StartText;

    int Score = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    void Start()
    {
        StartCoroutine("StartGame");
    }

    IEnumerator StartGame()
    {
        int i = 3;
        
        while(i > 0)
        {
            StartText.text = i.ToString();

            yield return new WaitForSeconds(1);

            i--;

            if(i ==0)
            {
                StartText.gameObject.SetActive(false);
            }
        }
    }


    void Update()
    {

    }

    public void AddScore(int num)
    {
        Score += num;
        ScoreText.text = "Score : " + Score;
    }
}
