using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    public float delayBeforeDestroy = 0.001f; // 오브젝트 파괴 전의 딜레이

    void Start()
    {
        // AudioSource 컴포넌트를 가져옵니다.
        audioSource = GetComponent<AudioSource>();
    }

    // 트리거에 닿았을 때 호출되는 함수입니다.
    void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어가 트리거에 닿았는지 확인합니다.
        if (other.CompareTag("Player"))
        {
            // 오디오가 재생되지 않고 있다면 재생합니다.
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                StartCoroutine(DestroyAfterSound()); // 오디오 재생 후 오브젝트 파괴
            }
        }
    }

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(audioSource.clip.length + delayBeforeDestroy); // 오디오 클립 길이 + 딜레이만큼 대기
        Destroy(gameObject); // 게임 오브젝트 파괴
    }
}
