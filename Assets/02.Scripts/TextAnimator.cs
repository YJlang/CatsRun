using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimator : MonoBehaviour
{
    public Text uiText; // ��� �ؽ�Ʈ UI
    public float scaleDuration = 0.5f; // ũ�� ��ȭ �ֱ�
    public float colorChangeInterval = 0.1f; // ���� ��ȭ ����
    public List<Color> colors; // ����� ���� ���

    private Vector3 originalScale; // ���� ũ��

    void Start()
    {
        if (uiText == null)
        {
            uiText = GetComponent<Text>();
        }

        // �ؽ�Ʈ�� �ʱ� ������ ��������� ����
        uiText.color = Color.yellow;

        originalScale = uiText.rectTransform.localScale;

        StartCoroutine(AnimateScale());
        //StartCoroutine(ChangeColor());
    }

    private IEnumerator AnimateScale()
    {
        while (true)
        {
            // ũ�� Ű���
            yield return ScaleTo(new Vector3(1.2f, 1.2f, 1.2f), scaleDuration);
            // ���� ũ��� ����
            yield return ScaleTo(originalScale, scaleDuration);
        }
    }

    private IEnumerator ScaleTo(Vector3 targetScale, float duration)
    {
        Vector3 initialScale = uiText.rectTransform.localScale;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            uiText.rectTransform.localScale = Vector3.Lerp(initialScale, targetScale, time / duration);
            yield return null;
        }

        uiText.rectTransform.localScale = targetScale;
    }

    private IEnumerator ChangeColor()
    {
        int colorIndex = 0;

        while (true)
        {
            uiText.color = colors[colorIndex];
            colorIndex = (colorIndex + 1) % colors.Count;
            yield return new WaitForSeconds(colorChangeInterval);
        }
    }
}
