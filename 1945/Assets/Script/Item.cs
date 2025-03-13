using UnityEngine;

public class Item : MonoBehaviour
{
    //아이템 가속 속도
    public float ItemVelocity = 20f;
    Rigidbody2D rig = null;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector3(ItemVelocity, ItemVelocity, 0f));
        Destroy(gameObject, 3f);
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.Upgrade();

            Destroy(gameObject);
        }
    }
}
