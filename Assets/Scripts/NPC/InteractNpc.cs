using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NPC와 상호작용한다. 대화만 가능하다. (다른 일이 필요할지도???)
/// </summary>
public class InteractNpc : MonoBehaviour
{
    public DialogueManager dialogueManager;

    public void Init(GameObject[] npcs)
    {
        for (int i = 0; i < npcs.Length; i++)
            npcs[i].GetComponent<InteractableObject>().Init(Talk);
    }

    // DialogueManager에서 다이얼로그를 불러와 대화를 시작한다.
    public void Talk(GameObject npc)
    {
        dialogueManager.LoadDialogue(npc.GetComponent<Npc>().Dialogue);
    }
}
