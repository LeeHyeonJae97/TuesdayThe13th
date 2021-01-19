using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Clue : MonoBehaviour
{
    public string clueName;
    public string description;
    public Transform camDummy; //** position과 rotation으로 분리

    public abstract void Zoom(bool zoomIn, Transform clueCam, GameObject discoveryCanvas, Text clueNameText, Text descriptionText, GameObject stuffControlPanel);
}


