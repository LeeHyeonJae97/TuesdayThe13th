using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Portalteleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;

    Collider m_objectCollider;
    public void Triggeron()
    {
        m_objectCollider = GetComponent<Collider>();
        m_objectCollider.isTrigger = true;
    }

    public void Triggeroff()
    {
        m_objectCollider = GetComponent<Collider>();
        m_objectCollider.isTrigger = false;
    }

    private void OnTriggerStay(Collider other)
    {
        thePlayer.transform.position = teleportTarget.transform.position;
    }
}
