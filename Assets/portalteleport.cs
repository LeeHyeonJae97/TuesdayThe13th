using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class portalteleport : MonoBehaviour
{ 
    public Transform teleportTarget;
    public GameObject thePlayer;

    Collider m_objectCollider;
    public void triggeron()
    {
        m_objectCollider = GetComponent<Collider>();
        m_objectCollider.isTrigger = true;
    }

    public void triggeroff()
    {
        m_objectCollider = GetComponent<Collider>();
        m_objectCollider.isTrigger = false;
    }
    private void OnTriggerStay(Collider other)
    {
        thePlayer.transform.position = teleportTarget.transform.position;
    }
    
}
