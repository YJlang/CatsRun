using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverMode : MonoBehaviour
{
    public GameObject bulletPrefab; // �Ѿ� ������
    public float bulletSpeed = 10.0f; // �Ѿ� �ӵ�
    public float feverDuration = 3.0f; // �ǹ� ��� ���� �ð�
    public float fireInterval = 0.1f; // �Ѿ� �߻� ����

    private bool isFeverModeActive = false;

    /*void Update()
    {
        if (isFeverModeActive)
        {
            // �ǹ� ��尡 Ȱ��ȭ�� ���¿��� Update���� �߰� ������ �ʿ��� ��� ����
        }
    }*/

    public void ActivateFeverMode()
    {
        if (!isFeverModeActive)
        {
            StartCoroutine(FeverModeRoutine());
        }
    }

    private IEnumerator FeverModeRoutine()
    {
        isFeverModeActive = true;
        float endTime = Time.time + feverDuration;

        while (Time.time < endTime)
        {
            FireBulletsInAllDirections();
            yield return new WaitForSeconds(fireInterval); // �Ѿ� �߻� ����
        }

        isFeverModeActive = false;
    }

    private void FireBulletsInAllDirections()
    {
        int bulletCount = 8; // �Ѿ� ���� (360�� �������� ������)
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (360.0f / bulletCount);
            Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.up; // ������ Vector3.up���� ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}
