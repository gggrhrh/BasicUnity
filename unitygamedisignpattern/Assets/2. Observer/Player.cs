using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health = 100;

    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            //체력 변경 이벤트
            EventManager.Instance.TriggerEvent("PlayerHealthChanged", _health);

            if(_health <= 0)
            {
                EventManager.Instance.TriggerEvent("PlayerDied");
            }
        }
    }

    private void TakeDamage(int damage)
    {
        Health -= damage;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }
}
