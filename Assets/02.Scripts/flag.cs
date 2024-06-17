using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flag : MonoBehaviour
{
    public string nextSceneName = "EndScene"; // ��ȯ�� ���� �̸�

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null)
            {
                Debug.Log("�ְ����� : " + playerController.ScorePoint);
                // ���� ������ ��ȯ
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
