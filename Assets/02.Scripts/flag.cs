using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flag : MonoBehaviour
{
    public string nextSceneName = "EndScene"; // 전환할 씬의 이름

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null)
            {
                Debug.Log("최고점수 : " + playerController.ScorePoint);
                // 다음 씬으로 전환
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
