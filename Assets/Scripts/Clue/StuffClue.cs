using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StuffClue : Clue
{
    public float controlPosY;

    private Vector3 orgPos;
    private Quaternion orgRot;

    private void Awake()
    {
        orgPos = transform.position;
        orgRot = transform.rotation;
    }

    public override void Zoom(bool zoomIn, Transform clueCam, GameObject discoveryCanvas, Text clueNameText, Text descriptionText, GameObject stuffControlPanel)
    {
        clueCam.gameObject.SetActive(zoomIn);
        discoveryCanvas.SetActive(zoomIn);

        if (zoomIn)
        {
            transform.position = new Vector3(transform.position.x, controlPosY, transform.position.z);

            clueCam.position = camDummy.position;
            clueCam.rotation = camDummy.rotation;

            clueNameText.text = clueName;
            descriptionText.text = description;
            stuffControlPanel.SetActive(true);
            stuffControlPanel.GetComponent<StuffControlPanel>().Target = transform;
        }
        else
        {
            transform.position = orgPos;
            transform.rotation = orgRot;
        }
    }
}
