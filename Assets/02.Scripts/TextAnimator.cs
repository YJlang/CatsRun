using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimator : MonoBehaviour
{
    public Text uiText; // 대상 텍스트 UI
    public float scaleDuration = 0.5f; // 크기 변화 주기
    public float colorChangeInterval = 0.1f; // 색상 변화 간격
    public List<Color> colors; // 사용할 색상 목록

    private Vector3 originalScale; // 원래 크기

    void Start()
    {
        if (uiText == null)
        {
            uiText = GetComponent<Text>();
        }

        // 텍스트의 초기 색상을 노란색으로 설정
        uiText.color = Color.yellow;

        originalScale = uiText.rectTransform.localScale;

        StartCoroutine(AnimateScale());
        //StartCoroutine(ChangeColor());
    }

    private IEnumerator AnimateScale()
    {
        while (true)
        {
            // 크기 키우기
            yield return ScaleTo(new Vector3(1.2f, 1.2f, 1.2f), scaleDuration);
            // 원래 크기로 복구
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
