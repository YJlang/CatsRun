using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float stage01Time = 0.0f;
    private float feverItemTime = 0.0f;
    private int feverItemCount = 0;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject feverItem;
    public Transform playerTr; // 플레이어의 Transform
    public float minDistance = 5.0f; // 플레이어와의 최소 거리
    public float spawnInterval = 3.0f; // 프리팹 생성 간격
    public float spawnRangeY = 5.0f; // 프리팹이 생성될 Y축 범위
    public float feverItemSpawnInterval = 5.0f; // FeverItem 생성 간격

    private void Start()
    {
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        // 적 생성 타이머 업데이트
        stage01Time += Time.deltaTime;

        if (stage01Time > spawnInterval)
        {
            Vector3 spawnPosition = GetRightSpawnPosition();
            Instantiate(enemy1, spawnPosition, Quaternion.identity);
            stage01Time = 0.0f;
        }

        // FeverItem 생성 타이머 업데이트 및 제한 조건 확인
        if (feverItemCount < 2)
        {
            feverItemTime += Time.deltaTime;

            if (feverItemTime > feverItemSpawnInterval)
            {
                Vector3 spawnPosition = GetRightSpawnPosition();
                Instantiate(feverItem, spawnPosition, Quaternion.identity);
                Instantiate(enemy2, spawnPosition, Quaternion.identity);
                feverItemTime = 0.0f;
                feverItemCount++;
            }
        }
    }

    private Vector3 GetRightSpawnPosition()
    {
        Vector3 spawnPosition = playerTr.position;

        // 플레이어의 오른쪽에서 일정 거리 이상 떨어진 위치에 생성
        float offsetX = Random.Range(minDistance, minDistance + 5);
        float offsetY = Random.Range(0, spawnRangeY); // Y축에서 플레이어보다 무조건 위로 생성

        spawnPosition += new Vector3(offsetX, offsetY, 0);

        return spawnPosition;
    }
}
