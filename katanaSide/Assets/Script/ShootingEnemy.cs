using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [Header("적 캐릭터 속성")]
    public float detectionRange = 10f;
    public float shootingInterval = 2f;
    public GameObject missilePrefab;

    [Header("참조 컴포넌트")]
    public Transform firePoint;
    private Transform player;
    private float shootTimer;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        shootTimer = shootingInterval;  //타이머 초기화
    }

    void Update()
    {
        if(player == null)  return;

        //플레이어와의 거리 계산
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if(distanceToPlayer <= detectionRange)
        {
            //플레이어 방향으로 스프라이트 회전
            spriteRenderer.flipX = player.position.x < transform.position.x;

            //미사일 발사 로직
            shootTimer -= Time.deltaTime;
            if(shootTimer <= 0)
            {
                Shoot();
                shootTimer = shootingInterval;
            }

        }

    }

    void Shoot()
    {
        GameObject missile = Instantiate(missilePrefab, firePoint.position, Quaternion.identity);

        //미사일 방향 설정
        Vector2 direction = (player.position - firePoint.position).normalized;
        missile.GetComponent<EnemyMissile>().SetDirection(direction);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

}
