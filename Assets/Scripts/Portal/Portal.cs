using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 포탈을 통해 다른 장소로 이동할 수 있다.
/// </summary>
public class Portal : InteractableObject
{
    // 포탈과 연결된 장소
    [SerializeField] private string placeName;
    public string PlaceName { get { return placeName; } }

    // 포탈과 연결된 포탈. 포탈과 연결된 장소가 여러 포탈을 포함하고 있을 수 있기 때문에 장소와 포탈 전부 저장한다.
    [SerializeField] private GameObject connectedPortal;
    public GameObject ConnectedPortal { get { return connectedPortal; } }
}
