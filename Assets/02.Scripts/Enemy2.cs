using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float Enemy2HP = 8.0f;
    public float speed = 2.0f; // ���� �̵� �ӵ�
    private Transform playerTransform;
    public GameObject deadEffect;
    PlayerController player;

    void Start()
    {
        // "Player" �±׸� ���� ���� ������Ʈ�� Transform�� ã���ϴ�.
        playerTransform = GameObject.FindWithTag("Player").transform;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        // �÷��̾��� ��ġ�� �̵�
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // �÷��̾ �����ϵ��� ȸ��
        if (playerTransform.position.x > transform.position.x)
        {
            // �÷��̾ �����ʿ� ���� ��
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else
        {
            // �÷��̾ ���ʿ� ���� ��
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
            Debug.Log("���");
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("�÷��̾�� �浹");
            player.PlayerHPMinus();
            player.SpinPlayer();
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
