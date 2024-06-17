using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeAmount = 0.5f;
    private float shakeTime;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if(shakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * shakeAmount + initialPosition;
            shakeTime -= Time.deltaTime;
        }
        else
        {
            shakeTime = 0.0f;
            transform.position = initialPosition;
        }
    }

    public void VibrateForTime(float time)
    {
        shakeTime = time;
    }
}
