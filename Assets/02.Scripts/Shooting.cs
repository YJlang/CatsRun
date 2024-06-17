using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooting : MonoBehaviour
{

    private Transform spPoint;
    public GameObject BulletPrefab;
    public float bulletCollTime = 0.23f;
    private float bulTime = 0.0f;

    private void Start()
    {
        spPoint = GameObject.Find("spPoint").transform;
    }

    private void Update()
    {
        Vector3 mPosition = Input.mousePosition;
        Vector3 oPosition = transform.position;
        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);

        float dy = target.y - oPosition.y;
        float dx = target.x - oPosition.x;
        float rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);

        #region ÃÑ¾Ë¹ß»ç
        bulTime += Time.deltaTime;
        if(bulTime > bulletCollTime)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Instantiate(BulletPrefab, spPoint.position, spPoint.rotation);
                bulletCollTime = 0.0f;
            }
        }
        #endregion
    }
}
