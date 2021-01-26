using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : InteractableObject
{
    // NPC의 이름
    [SerializeField] private string npcName;
    public string NpcName { get { return npcName; } }

    // NPC와의 대화 이름
    [SerializeField] private Dialogue dialogue;
    public Dialogue Dialogue { get { return dialogue; } }  
}
