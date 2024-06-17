using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverItem : MonoBehaviour
{
    private float speed = 0.1f;
    public GameObject FeverEffect;
    private Transform playerTr;

    private void Start()
    {
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerTr.position, Time.deltaTime * speed);
        transform.Rotate(Vector3.forward * speed * 100.0f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(FeverEffect, transform.position, Quaternion.identity);
            FeverMode feverMode = collision.GetComponent<FeverMode>();
            if (feverMode != null)
            {
                feverMode.ActivateFeverMode();
            }
            Destroy(this.gameObject);
        }
    }
}
