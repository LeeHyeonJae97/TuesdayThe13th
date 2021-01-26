using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Loading : MonoBehaviour
{
    // 싱글톤
    public static Loading instance;

    public Text loadingText;
    private string[] texts = { "Loading.", "Loading..", "Loading..." };

    public float time;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        gameObject.SetActive(false);
    }

    // 로딩 시작
    public void StartLoading(UnityAction onFinished)
    {
        gameObject.SetActive(true);

        StartCoroutine(CorLoading(onFinished));
        StartCoroutine(CorLoadingText());
    }

    // 실제 로딩에 필요한 시간을 계산한다.
    private IEnumerator CorLoading(UnityAction onFinished)
    {
        yield return new WaitForSecondsRealtime(time);
        gameObject.SetActive(false);

        StopAllCoroutines();

        if (onFinished != null) onFinished.Invoke();
    }

    // 로딩 진행 중 효과. 글씨를 계속해서 변경시켜 로딩이 진행되고 있음을 알게 한다.
    private IEnumerator CorLoadingText()
    {
        WaitForSecondsRealtime interval = new WaitForSecondsRealtime(0.5f);
        int index = 0;

        while (true)
        {
            index += 1;
            if (index >= texts.Length) index = 0;

            loadingText.text = texts[index];

            yield return interval;
        }
    }
}
