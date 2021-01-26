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
    public Image bkgImage;
    public Image speakerImage;
    public Text speakerName;
    public Text contentText;
    public GameObject controllerCanvas;

    private Dialogue curDialogue;

    private void Start()
    {
        //LoadDialogue("Dialogue_1");
    }

    public void LoadDialogue(Dialogue dialogue)
    {
        curDialogue = dialogue;
        curDialogue.Init(bkgImage, speakerImage, speakerName, contentText, this, optionManager, dialogueCanvas, controllerCanvas);

        NextSpeak();
    }

    // 다음 대사를 화면에 출력한다. 다이얼로그 화면의 '다음' 버튼 클릭시 호출된다.
    public void NextSpeak()
    {
        curDialogue.onNext.Invoke();
    }

}
