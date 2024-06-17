using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 25.0f;
    public float destroyTime = 3.0f;

    private void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy1" || collision.gameObject.tag == "Enemy2")
        {
            Destroy(this.gameObject);
        }
    }
}
