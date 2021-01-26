using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 상호작용 가능한 오브젝트들을 관리한다.
/// </summary>
public class InteractableObjectManager : MonoBehaviour
{
    private List<GameObject> interactableObjects = new List<GameObject>();

    public DiscoveryClue discoveryClue;
    public InteractNpc interactNpc;
    public PlaceManager placeManager;

    public Transform player;

    public Button interactButton;

    private InteractableObject target;

    // 상호작용 가능한 모든 오브젝트들과 플레이어의 거리를 비교한다.
    // 일정 거리 내 가장 가까운 오브젝트와 상호작용할 수 있도록 한다.
    private void Update()
    {
        int index = -1;
        float minDist = Player.detectRange * Player.detectRange;

        for (int i = 0; i < interactableObjects.Count; i++)
        {
            if (interactableObjects[i].activeInHierarchy)
            {
                Vector3 offset = player.position - interactableObjects[i].transform.position;                
                offset.y = 0;
                float dist = offset.sqrMagnitude;
                if (dist < minDist)
                {
                    index = i;
                    minDist = dist;
                }
            }
        }

        Detected(index >= 0 ? interactableObjects[index].GetComponent<InteractableObject>() : null);        
    }

    private void Detected(InteractableObject target)
    {
        // 일정 거리 내 상호작용 가능한 오브젝트가 존재하는 경우
        if (this.target != null && target == null)
        {
            //Debug.Log("Nothing");

            this.target = null;

            //**
            interactButton.GetComponent<Image>().color = Color.white;

            interactButton.interactable = false;


            //interactButton.GetComponent<Image>().sprite = orgImage;
        }

        // 일정 거리 내 상호작용 가능한 오브젝트가 존재하지 않는 경우
        else if (this.target != target && target != null)
        {
            //Debug.Log("Detect");

            this.target = target;

            //**
            interactButton.GetComponent<Image>().color = target.interactButtonColor;

            interactButton.interactable = true;


            //interactButton.GetComponent<Image>().sprite = target.interactableButton;
        }
    }

    // 상호작용 버튼을 클릭할 시 호출된다.
    public void Interact() => target.GetComponent<InteractableObject>().Interact();

    // 현재 플레이어가 있는 장소의 오든 단서, NPC, 포탈을 거리 비교 대상에 추가한다.
    // 포탈을 사용해 장소를 옮길 시 호출된다.
    public void SetInteractableObjects(GameObject[] clues, GameObject[] npcs, GameObject[] portals)
    {
        interactableObjects = new List<GameObject>();

        // 단서 추가
        if(clues != null)
        {
            interactableObjects.AddRange(clues);
            for (int i = 0; i < clues.Length; i++)
                clues[i].GetComponent<InteractableObject>().Init(discoveryClue.Discovery);
        }

        // NPC 추가
        if (npcs != null)
        {
            interactableObjects.AddRange(npcs);

            for (int i = 0; i < npcs.Length; i++)
            {
                npcs[i].GetComponent<InteractableObject>().Init(interactNpc.Talk);
            }
        }

        // 포탈 추가
        if(portals != null)
        {
            interactableObjects.AddRange(portals);
            for (int i = 0; i < portals.Length; i++)
                portals[i].GetComponent<InteractableObject>().Init(placeManager.Teleport);
        }
    }
}
