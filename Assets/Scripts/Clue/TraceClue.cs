using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraceClue : Clue
{
    public override void Zoom(bool zoomIn, Transform clueCam, GameObject discoveryCanvas, Text clueNameText, Text descriptionText, GameObject stuffControlPanel)
    {
        clueCam.gameObject.SetActive(zoomIn);
        discoveryCanvas.SetActive(zoomIn);

        if (zoomIn)
        {
            clueCam.position = camDummy.position;
            clueCam.rotation = camDummy.rotation;

            clueNameText.text = clueName;
            descriptionText.text = description;
            stuffControlPanel.SetActive(false);            
        }
    }
}
