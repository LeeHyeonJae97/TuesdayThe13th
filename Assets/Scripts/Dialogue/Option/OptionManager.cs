using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 선택지에 따라 알맞은 일이 수행될 수 있도록 한다.
/// 선택지는 ScriptableObject의 형태로 Resources폴더에 저장되고 필요할때 동적으로 불러와 사용된다.
/// </summary>
public class OptionManager : MonoBehaviour
{
    public DialogueManager dialogueManager;

    //public GameObject optionCanvas;
    public GameObject dialoguePanel;
    public GameObject optionPanel;
    public GameObject[] buttons;

    public void LoadOption(Option option)
    {
        option.Init(dialogueManager);

        for (int i = 0; i < option.contents.Length; i++)
        {
            buttons[i].SetActive(true);
            buttons[i].GetComponent<Text>().text = option.contents[i];
            Button button = buttons[i].GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
            {
                optionPanel.SetActive(false);
                dialoguePanel.SetActive(true);
            });
            button.onClick.AddListener(option.onClicks[i]);
        }
        for (int i = option.contents.Length; i < buttons.Length; i++)
            buttons[i].SetActive(false);

        dialoguePanel.SetActive(false);
        optionPanel.SetActive(true);
        //optionCanvas.SetActive(true);
    }
}
