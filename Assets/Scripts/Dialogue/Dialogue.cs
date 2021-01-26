using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public abstract class Dialogue : ScriptableObject
{
    public string dialogueName;
    protected Text contentText;

    public UnityAction onNext;
    public UnityAction onFinished;

    [HideInInspector] public int curIndex;
    protected Coroutine corTyping;

    public abstract void Init(Image bkgImage, Image speakerImage, Text speakerName, Text contentText, 
        DialogueManager dialogueManager, OptionManager optionManager, GameObject dialogueCanvas, GameObject controllerCanvas);

    // 글씨가 타이핑 되는 것처럼 보이는 효과. 한 글자씩 화면에 출력한다.
    protected IEnumerator CorTyping(string content)
    {
        contentText.text = "";

        char[] letters = content.ToCharArray();
        for (int i = 0; i < letters.Length; i++)
        {
            contentText.text += letters[i];
            yield return null;
        }

        curIndex++;
        corTyping = null;
    }
}
