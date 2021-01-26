using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObject/Story Dialogue")]
public class StoryDialogue : Dialogue
{
    [System.Serializable]
    public struct Speak
    {
        public Sprite bkg;
        public string content;
    }

    public Speak[] speaks;

    public override void Init(Image bkgImage, Image speakerImage, Text speakerName, Text contentText,
        DialogueManager dialogueManager, OptionManager optionManager,GameObject dialogueCanvas, GameObject controllerCanvas)
    {
        dialogueCanvas.SetActive(true);
        controllerCanvas.SetActive(false);

        curIndex = 0;

        this.contentText = contentText;

        bkgImage.gameObject.SetActive(true);
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
                    // 대사, 말하는 사람의 이미지를 출력
                    Speak speak = speaks[curIndex];

                    if (speak.bkg != null) speakerImage.sprite = speak.bkg;                    
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
            controllerCanvas.SetActive(true);

            Finish();
        };
    }

    protected virtual void Finish()
    {
        // 각각에 맞춰 StoryDialogue를 상속하여 구현

        // 1. 챕터가 시작되면서 진행되는 스토리 다이얼로그는 끝나면서 플레이어 조작이 가능하도록 해야한다.
        // 2. 챕터가 끝나면서 진행되는 나래이션 형식의 스토리 다이얼로그는 끝나면서 챕터가 끝나고 챕터 선택씬으로 바뀌어야한다.        
    }
}
