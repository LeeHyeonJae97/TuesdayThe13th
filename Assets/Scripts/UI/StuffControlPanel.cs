using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 조작 가능한 단서를 화면에 드래그를 함으로써 회전시킬 수 있다.
/// </summary>
public class StuffControlPanel : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public float minDrag;
    public float rotateSpeed;

    public Transform Target { private get; set; }

    public void OnBeginDrag(PointerEventData eventData) { }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dir = eventData.delta;

        if (dir.x < minDrag || dir.x > minDrag) Target.Rotate(Vector3.up, -dir.x * rotateSpeed, Space.World);
        if (dir.y < minDrag || dir.y > minDrag) Target.Rotate(Vector3.right, -dir.y * rotateSpeed, Space.World);
    }

    public void OnEndDrag(PointerEventData eventData) { }
}
