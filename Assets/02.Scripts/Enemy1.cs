using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float Enemy1HP = 10.0f;
    private float speed = 2.1f;
    Transform playerTr;
    PlayerController player;
    public GameObject deadEffect;

    private void Start()
    {
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        // MoveTowards를 사용하여 플레이어를 일정한 속도로 따라갑니다.
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerTr.position, step);

        // 회전 로직을 유지합니다.
        transform.Rotate(Vector3.forward * speed * 200.0f * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Enemy1 HP : " + Enemy1HP);
            Enemy1HP -= 1f;
        }
        if (Enemy1HP < 0.0f)
        {
            Debug.Log("사망");
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("플레이어와 충돌");
            player.PlayerHPMinus();
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
