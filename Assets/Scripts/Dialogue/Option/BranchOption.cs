using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 대화 분기를 결정하는 옵션
/// </summary>
[CreateAssetMenu(fileName = "BranchOption", menuName = "ScriptableObject/BranchOption")]
public class BranchOption : Option
{
    public string[] dialogues;

    public override void Init(DialogueManager dialogueManager)
    {
        if (dialogueManager == null)
            return;

        onClicks = new UnityAction[contents.Length];
        for (int i = 0; i < onClicks.Length; i++)
        {
            int index = i;
            onClicks[index] = () => { dialogueManager.LoadDialogue(dialogues[index]); };
        }
    }
}
