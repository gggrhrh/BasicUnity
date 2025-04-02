using UnityEngine;

public class GameManager : MonoBehaviour
{
    //1. 싱글톤(Singleton) 패턴
    //싱글톤 패턴은 클래스의 인스턴스가 오직 하나만 생성되고, 어디서든 그 인스턴스에
    //접근할 수 있게 하는 패턴입니다. Unity에서는 게임 매니저, 오디어 매니저 등에 주로 사용됩니다.

    //싱글톤 인스턴스를 저장할 정적 변수
    private static GameManager _instance;
    //외부에서 인스턴스에 접글할 수 있는 프로퍼티
    public static GameManager Instance 
    { 
        get 
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<GameManager>();

                if(_instance == null)
                {
                    GameObject singletonObject = new GameObject("GameManager");
                    _instance = singletonObject.AddComponent<GameManager>();
                }
                
            }
            return _instance;
           
        } 
    }

    private void Awake()
    {
        _instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private int _score = 0;
    
    public int Score => _score;

    public void AddScore(int points)
    {
        _score += points;
        Debug.Log($"Score updatede : {_score}");
    }

}
