using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 단서를 조사한다. TraceClue는 카메라가 고정되어 고정된 시점에서 단순히 관찰만 할 수 있고
/// StuffClue는 단서를 직접 회전시켜 보면서 구체적으로 살펴볼 수 있다.
/// </summary>
public class DiscoveryClue : MonoBehaviour
{
    public GameObject discoveryCanvas;
    public GameObject stuffControlPanel;

    public Transform player;
    public GameObject mainCam;
    public Transform clueCam;
    public GameObject controllerCanvas;
    public Button interactButton;

    public DialogueManager dialogueManager;

    private GameObject clue;

    // 단서와 상호작용할 시 호출될 메소드를 전달한다.
    public void Init(GameObject[] clues)
    {
        for (int i = 0; i < clues.Length; i++)
            clues[i].GetComponent<InteractableObject>().Init(Discovery);
    }

    // 단서를 조사한다.
    public void Discovery(GameObject clue)
    {
        if (clue != null)
        {
            // 단서에 줌인
            clue.GetComponent<Clue>().Zoom(true, dialogueManager, clueCam, stuffControlPanel);

            // 카메라와 화면 UI 조정
            clueCam.gameObject.SetActive(true);
            discoveryCanvas.SetActive(true);
            mainCam.SetActive(false);
            player.gameObject.SetActive(false);
            controllerCanvas.SetActive(false);

            this.clue = clue;
        }
    }

    // 단서 조사를 그만두고 플레이어를 조작하는 상태로 돌아온다.
    public void UnDiscovery()
    {
        if(clue != null)
        {
            // 단서로부터 줌 아웃
            clue.GetComponent<Clue>().Zoom(false, dialogueManager, clueCam, stuffControlPanel);

            // 카메라와 화면 UI 조정
            clueCam.gameObject.SetActive(false);
            discoveryCanvas.SetActive(false);
            mainCam.SetActive(true);
            player.gameObject.SetActive(true);
            controllerCanvas.SetActive(true);

            clue = null;
        }
    }
}
