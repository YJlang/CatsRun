using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float Enemy2HP = 8.0f;
    public float speed = 2.0f; // 적의 이동 속도
    private Transform playerTransform;
    public GameObject deadEffect;
    PlayerController player;

    void Start()
    {
        // "Player" 태그를 가진 게임 오브젝트의 Transform을 찾습니다.
        playerTransform = GameObject.FindWithTag("Player").transform;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        // 플레이어의 위치로 이동
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // 플레이어를 응시하도록 회전
        if (playerTransform.position.x > transform.position.x)
        {
            // 플레이어가 오른쪽에 있을 때
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else
        {
            // 플레이어가 왼쪽에 있을 때
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Enemy1 HP : " + Enemy2HP);
            Enemy2HP -= 1f;
        }
        if (Enemy2HP < 0.0f)
        {
            Debug.Log("사망");
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("플레이어와 충돌");
            player.PlayerHPMinus();
            player.SpinPlayer();
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
