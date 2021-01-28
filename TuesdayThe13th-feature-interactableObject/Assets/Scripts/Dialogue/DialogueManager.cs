using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 특정 다이얼로그를 불러와 화면에 출력한다.
/// 다이얼로그는 ScriptableObject의 형태로 Resources폴더에 저장되고 필요할때 동적으로 불러와 사용된다.
/// </summary>

public class DialogueManager : MonoBehaviour
{   
    public OptionManager optionManager;

    public GameObject dialogueCanvas;
    public Image speakerImage;
    public Text speakerText;
    public Text contentText;
    public GameObject controllerCanvas;

    private Dialogue curDialogue;
    private int curIndex;

    private Coroutine corTyping;

    private void Start()
    {
        //LoadDialogue("Dialogue_1");
    }

    // Resources폴더에 저장된 다이얼로그를 불러온다.
    public void LoadDialogue(string fileName)
    {
        curIndex = 0;
        curDialogue = null;

        curDialogue = (Dialogue)Resources.Load("Dialogues/" + fileName);
        if (curDialogue != null)
        {
            controllerCanvas.SetActive(false);
            dialogueCanvas.SetActive(true);
            NextSpeak();
        }
        else Debug.LogError("Error");
    }

    // 다음 대사를 화면에 출력한다. 다이얼로그 화면의 '다음' 버튼 클릭시 호출된다.
    public void NextSpeak()
    {
        // 현재 대사를 출력하고 있는 중이 아니라면 다음 대사를 출력한다.
        if (corTyping == null)
        {
            // 대화가 전부 끝났다면 선택지를 선택하거나 대화를 종료한다.
            if (curIndex == curDialogue.mainSpeaks.Length) EndDialogue();

            // 다음 대사가 남아있다면 다음 대사를 출력한다.
            else
            {
                // 대사, 말하는 사람의 이미지를 출력
                Dialogue.Speak speak = curDialogue.mainSpeaks[curIndex];               
                if (speak.image == null) speakerImage.gameObject.SetActive(false);
                else
                {
                    speakerImage.sprite = speak.image;
                    speakerImage.gameObject.SetActive(true);
                }
                speakerText.text = speak.speaker;
                corTyping = StartCoroutine(CorTyping(speak.content));
            }
        }

        // 현재 대사를 출력하고 있는 중이라면 출력하던 대사의 나머지 부분을 한번에 전부 출력한다.
        else
        {
            StopCoroutine(corTyping);
            contentText.text = curDialogue.mainSpeaks[curIndex].content;
            curIndex++;
            corTyping = null;
        }
    }

    // 글씨가 타이핑 되는 것처럼 보이는 효과. 한 글자씩 화면에 출력한다.
    private IEnumerator CorTyping(string content)
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

    // 마지막 대사가 출력된 후 호출된다.
    private void EndDialogue()
    {
        // 선택지가 존재한다면 선택지를 선택할 수 있도록 한다.
        if(curDialogue.option != null)
        {
            optionManager.LoadOption(curDialogue.option);
            dialogueCanvas.SetActive(false);
        }

        // 선택지가 없다면 바로 대화를 종료한다.
        else
        {
            controllerCanvas.SetActive(true);
            dialogueCanvas.SetActive(false);
        }
    }
}
