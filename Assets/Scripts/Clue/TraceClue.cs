using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 단순히 관찰만 가능한 단서
/// </summary>
public class TraceClue : Clue
{
    // 단서에 줌인
    public override void Zoom(bool zoomIn, DialogueManager dialogueManager, Transform clueCam, GameObject stuffControlPanel)
    {
        if (zoomIn)
        {
            dialogueManager.LoadDialogue(dialogue);

            clueCam.position = camDummy.position;
            clueCam.rotation = camDummy.rotation;

            stuffControlPanel.SetActive(false);            
        }
    }
}
