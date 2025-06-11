using UnityEngine;

public class Player : MonoBehaviour
{
    public DynamicJoystick joystick;

    float speed = 5f;
    float x;
    float y;

    void Start()
    {
        
    }

    void Update()
    {
        x = joystick.Horizontal;
        y = joystick.Vertical;
        if (x != 0 || y != 0)
        {
            Vector3 move = new Vector3(x, y, 0);
            transform.position += move * Time.deltaTime * speed;
        }
    }
}
