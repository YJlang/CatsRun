using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverMode : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 프리팹
    public float bulletSpeed = 10.0f; // 총알 속도
    public float feverDuration = 3.0f; // 피버 모드 지속 시간
    public float fireInterval = 0.1f; // 총알 발사 간격

    private bool isFeverModeActive = false;

    /*void Update()
    {
        if (isFeverModeActive)
        {
            // 피버 모드가 활성화된 상태에서 Update에서 추가 동작이 필요한 경우 구현
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
            yield return new WaitForSeconds(fireInterval); // 총알 발사 간격
        }

        isFeverModeActive = false;
    }

    private void FireBulletsInAllDirections()
    {
        int bulletCount = 8; // 총알 개수 (360도 방향으로 나누기)
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (360.0f / bulletCount);
            Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.up; // 기준을 Vector3.up으로 변경
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}
