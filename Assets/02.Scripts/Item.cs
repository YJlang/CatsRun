using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    PlayerController player;
    public GameObject ItemEffect;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
    public void Init(Vector3 pos)
    {
        SetPos(pos);
    }
    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }

    public Vector3 GetPos()
    {
        return transform.position;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        player.ScoreUp();
        Instantiate(ItemEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
