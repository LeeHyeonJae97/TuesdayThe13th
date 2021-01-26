using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
public class Portalteleport : MonoBehaviour
{
    public Door[] doors;
    private Door detected;

    /*
    public Text clueName;
    public Text description;
    public GameObject stuffControlPanel;

    
    public GameObject mainCam;
    public Transform clueCam;
    
    
    */
/*
    public Transform player;
    public GameObject controllerCanvas;
    public Button teleportButton;

    private void Update()
    {
        int index = -1;
        float minDist = 999999;

        for (int i = 0; i < doors.Length; i++)
        {
            float dist = (player.position - doors[i].transform.position).sqrMagnitude;
            if (dist < Player.detectRange * Player.detectRange && dist < minDist)
            {
                index = i;
                minDist = dist;
            }
        }
        if (index >= 0) Detected(doors[index]);
        else Detected(null);
    }

    public void Detected(Door door)
    {
        if (door == null && detected != null)
        {
            Debug.Log("Nothing");

            detected = null;
            teleportButton.interactable = false;
        }

        else if (door != null && detected != door)
        {
            Debug.Log("Detect");

            detected = door;
            teleportButton.interactable = true;
        }
    }

    public void teleport_button(bool value)
    {

        if (value && detected != null)
        {
            controllerCanvas.SetActive(false);
        }
        else
        {
            controllerCanvas.SetActive(true);
        }
    }
}
*/