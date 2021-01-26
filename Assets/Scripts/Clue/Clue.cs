using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class Clue : InteractableObject
{
    public Dialogue dialogue;    
    public Transform camDummy; //** position과 rotation으로 분리

    public abstract void Zoom(bool zoomIn, DialogueManager dialogueManager, Transform clueCam, GameObject stuffControlPanel);
}
