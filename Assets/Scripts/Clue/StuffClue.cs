using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 조작 가능한 단서
/// </summary>
public class StuffClue : Clue
{
    public Transform model;

    // 단서를 조작하기 위해 바닥으로부터 위로 이격 시켜야하는데 이때 이격시킬 정도
    public float controlPosY;

    private Vector3 orgPos;
    private Quaternion orgRot;   

    // 단서의 원래 위치를 저장한다.
    private void Awake()
    {
        orgPos = model.position;
        orgRot = model.rotation;
    }

    // 단서에 줌 인하거나 단서로부터 줌 아웃
    public override void Zoom(bool zoomIn, DialogueManager dialogueManager, Transform clueCam, GameObject stuffControlPanel)
    {
        if (zoomIn)
        {
            dialogueManager.LoadDialogue(dialogue);

            model.position += new Vector3(0, controlPosY, 0);
            //model.position = new Vector3(transform.position.x, controlPosY, transform.position.z);

            clueCam.position = camDummy.position;
            clueCam.rotation = camDummy.rotation;

            stuffControlPanel.SetActive(true);
            stuffControlPanel.GetComponent<StuffControlPanel>().Target = model;
        }
        else
        {
            model.position = orgPos;
            model.rotation = orgRot;
        }
    }
}
