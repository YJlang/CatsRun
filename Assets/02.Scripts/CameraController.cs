using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject Player;

    private void Start()
    {
        this.Player = GameObject.Find("cat");
    }

    private void LateUpdate()
    {
        Vector3 playerPos = this.Player.transform.position;
        Vector3 newPos = Vector3.forward * -10.0f;
        transform.position = new Vector3(playerPos.x, 0f, -10.0f);
    }
}
