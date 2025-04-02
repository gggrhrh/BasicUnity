using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Enemy _enemy;

    void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _enemy.SetMovementStarategy(new StraightMovement());
            Debug.Log("직선 이동 전략으로 변경");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            _enemy.SetMovementStarategy(new ZigZagMovement());
            Debug.Log("지그재그 이동 전략으로 변경");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _enemy.SetMovementStarategy(new CircularMovement());
            Debug.Log("원형 이동 전략으로 변경");
        }


    }
}
