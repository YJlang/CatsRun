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
    public Transform playerTr; // �÷��̾��� Transform
    public float minDistance = 5.0f; // �÷��̾���� �ּ� �Ÿ�
    public float spawnInterval = 3.0f; // ������ ���� ����
    public float spawnRangeY = 5.0f; // �������� ������ Y�� ����
    public float feverItemSpawnInterval = 5.0f; // FeverItem ���� ����

    private void Start()
    {
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        // �� ���� Ÿ�̸� ������Ʈ
        stage01Time += Time.deltaTime;

        if (stage01Time > spawnInterval)
        {
            Vector3 spawnPosition = GetRightSpawnPosition();
            Instantiate(enemy1, spawnPosition, Quaternion.identity);
            stage01Time = 0.0f;
        }

        // FeverItem ���� Ÿ�̸� ������Ʈ �� ���� ���� Ȯ��
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

        // �÷��̾��� �����ʿ��� ���� �Ÿ� �̻� ������ ��ġ�� ����
        float offsetX = Random.Range(minDistance, minDistance + 5);
        float offsetY = Random.Range(0, spawnRangeY); // Y�࿡�� �÷��̾�� ������ ���� ����

        spawnPosition += new Vector3(offsetX, offsetY, 0);

        return spawnPosition;
    }
}
