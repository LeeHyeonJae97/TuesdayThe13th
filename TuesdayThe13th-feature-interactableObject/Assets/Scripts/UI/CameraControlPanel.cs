using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

/// <summary>
/// 카메라를 조작. 상하좌우로 드래그하여 조작할 수 있다.
/// </summary>
public class CameraControlPanel : MonoBehaviour, IDragHandler
{
    public CinemachineFreeLook cmFreeLoock;

    public int xModulator;
    public int yModulator;

    public void OnDrag(PointerEventData eventData)
    {
        float x = eventData.delta.x;
        float y = eventData.delta.y;

        if (x < -5 || x > 5) cmFreeLoock.m_XAxis.Value += eventData.delta.x / xModulator;
        if (y < -5 || y > 5) cmFreeLoock.m_YAxis.Value += -eventData.delta.y / yModulator;
    }
}
