using UnityEngine;

public class Homing : MonoBehaviour
{
    public GameObject target;   //
    public float Speed = 3f;
    Vector2 dir;
    Vector2 dirNo;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        dir = target.transform.position - transform.position;
        dirNo = dir.normalized;
    }

    void Update()
    {
        transform.Translate(dirNo * Speed * Time.deltaTime);

        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }    
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
