using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManager : MonoBehaviour
{
    public InteractableObjectManager interactableObjectManager;

    public GameObject player;

    public Transform placeHolder;
    private Dictionary<string, Place> placeDic = new Dictionary<string, Place>();

    private Place curPlace;

    private void Awake()
    {
        for (int i = 0; i < placeHolder.childCount; i++)
        {
            Place place = placeHolder.GetChild(i).GetComponent<Place>();
            placeDic.Add(place.PlaceName, place);
        }
    }

    private void Start()
    {
        // **
        Place city = placeDic["City"];
        interactableObjectManager.SetInteractableObjects(city.Clues, city.Npcs, city.Portals);
        curPlace = city;
    }

    // 장소 이동
    public void Teleport(GameObject portal)
    {
        // 로딩, 화면 전환
        Loading.instance.StartLoading(null);

        // 해당 포탈과 연결되어있는 장소 검색
        Portal portalScript = portal.GetComponent<Portal>();
        Place newPlace = placeDic[portalScript.PlaceName];

        // 연결된 포탈로 플레이어 이동
        player.transform.position = portalScript.ConnectedPortal.transform.position;

        // 새롭게 이동할 장소 활성화, 기존에 있던 장소 비활성화
        newPlace.gameObject.SetActive(true);
        curPlace.gameObject.SetActive(false);

        // interactableObjectManager에 새로운 장소로 업데이트        
        interactableObjectManager.SetInteractableObjects(newPlace.Clues, newPlace.Npcs, newPlace.Portals);

        curPlace = newPlace;
    }
}
