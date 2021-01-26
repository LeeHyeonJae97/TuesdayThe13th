using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObject/Description Dialogue")]
public class DescriptionDialogue : Dialogue
{
    [System.Serializable]
    public struct Speak
    {
        public string content;
    }

    public Speak[] speaks;

    public override void Init(Image bkgImage, Image speakerImage, Text speakerName, Text contentText,
        DialogueManager dialogueManager, OptionManager optionManager, GameObject dialogueCanvas, GameObject controllerCanvas)
    {
        controllerCanvas.SetActive(false);
        dialogueCanvas.SetActive(true);

        curIndex = 0;

        this.contentText = contentText;

        bkgImage.gameObject.SetActive(false);
        speakerImage.gameObject.SetActive(false);
        speakerName.gameObject.SetActive(false);   

        onNext = () =>
        {
            if (corTyping == null)
            {
                // 대화가 전부 끝났다면 선택지를 선택하거나 대화를 종료한다.
                if (curIndex == speaks.Length && onFinished != null)
                    onFinished.Invoke();

                // 다음 대사가 남아있다면 다음 대사를 출력한다.
                else
                {
                    Speak speak = speaks[curIndex];

                    corTyping = dialogueManager.StartCoroutine(CorTyping(speak.content));
                }

            }

            // 현재 대사를 출력하고 있는 중이라면 출력하던 대사의 나머지 부분을 한번에 전부 출력한다.
            else
            {
                dialogueManager.StopCoroutine(corTyping);
                contentText.text = speaks[curIndex].content;
                curIndex++;
                corTyping = null;
            }
        };

        onFinished = () =>
        {
            dialogueCanvas.SetActive(false);
        };        
    }
}
