using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 외부 도시를 포함한 플레이어가 이동할 수 있는 모든 장소
/// </summary>
public class Place : MonoBehaviour
{
    [SerializeField] private string placeName;
    public string PlaceName { get { return placeName; } }

    // 해당 장소의 모든 단서, NPC, 포탈을 참조한다.
    public Transform clueHolder, npcHolder, portalHolder;
    public GameObject[] Clues { get; private set; }
    public GameObject[] Npcs { get; private set; }
    public GameObject[] Portals { get; private set; }

    private void Awake()
    {
        Clues = new GameObject[clueHolder.childCount];
        for (int i = 0; i < clueHolder.childCount; i++)
            Clues[i] = clueHolder.GetChild(i).gameObject;

        Npcs = new GameObject[npcHolder.childCount];
        for (int i = 0; i < npcHolder.childCount; i++)
            Npcs[i] = npcHolder.GetChild(i).gameObject;

        Portals = new GameObject[portalHolder.childCount];
        for (int i = 0; i < portalHolder.childCount; i++)
            Portals[i] = portalHolder.GetChild(i).gameObject;
    }
}
