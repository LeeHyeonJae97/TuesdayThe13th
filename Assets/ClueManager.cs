using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueManager : MonoBehaviour
{
    public Clue[] clues;
    private Clue detected;

    public GameObject discoveryCanvas;
    public Text clueName;
    public Text description;
    public GameObject stuffControlPanel;

    public Transform player;
    public GameObject mainCam;
    public Transform clueCam;
    public GameObject controllerCanvas;
    public Button discoveryButton;

    private void Update()
    {
        int index = -1;
        float minDist = 999999;

        for (int i = 0; i < clues.Length; i++)
        {
            float dist = (player.position - clues[i].transform.position).sqrMagnitude;
            if (dist < Player.detectRange * Player.detectRange && dist < minDist)
            {
                index = i;
                minDist = dist;
            }
        }
        if (index >= 0) Detected(clues[index]);
        else Detected(null);
    }

    public void Detected(Clue clue)
    {
        if (clue == null && detected != null)
        {
            //Debug.Log("Nothing");

            detected = null;
            discoveryButton.interactable = false;
        }

        else if (clue != null && detected != clue)
        {
            //Debug.Log("Detect");

            detected = clue;
            discoveryButton.interactable = true;
        }
    }

    public void Discovery(bool value)
    {
        if (value && detected != null)
        {
            detected.Zoom(true, clueCam, discoveryCanvas, clueName, description, stuffControlPanel);

            mainCam.SetActive(false);
            player.gameObject.SetActive(false);
            controllerCanvas.SetActive(false);
        }
        else
        {
            detected.Zoom(false, clueCam, discoveryCanvas, clueName, description, stuffControlPanel);

            mainCam.SetActive(true);
            player.gameObject.SetActive(true);
            controllerCanvas.SetActive(true);
        }
    }
}
