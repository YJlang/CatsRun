using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    public float delayBeforeDestroy = 0.001f; // ������Ʈ �ı� ���� ������

    void Start()
    {
        // AudioSource ������Ʈ�� �����ɴϴ�.
        audioSource = GetComponent<AudioSource>();
    }

    // Ʈ���ſ� ����� �� ȣ��Ǵ� �Լ��Դϴ�.
    void OnTriggerEnter2D(Collider2D other)
    {
        // �÷��̾ Ʈ���ſ� ��Ҵ��� Ȯ���մϴ�.
        if (other.CompareTag("Player"))
        {
            // ������� ������� �ʰ� �ִٸ� ����մϴ�.
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                StartCoroutine(DestroyAfterSound()); // ����� ��� �� ������Ʈ �ı�
            }
        }
    }

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(audioSource.clip.length + delayBeforeDestroy); // ����� Ŭ�� ���� + �����̸�ŭ ���
        Destroy(gameObject); // ���� ������Ʈ �ı�
    }
}
