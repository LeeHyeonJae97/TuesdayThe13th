using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public delegate void Move(Vector3 dir);

    public Move move;
    private Transform mainCam;
    public Transform bkg;
    public Transform stick;
    private Vector2 dir;

    private int bkgRadius;
    private bool isTouched;

    private const int minDist = 1000;

    private void Awake()
    {
        mainCam = Camera.main.transform;
        bkgRadius = (int)((RectTransform)bkg).rect.width / 2;
    }

    private void Update()
    {
        if (isTouched)
        {
            stick.position = StickPosBound();

            //Debug.Log((stick.position - bkg.position).sqrMagnitude);

            dir = stick.position - bkg.position;
            if (dir.sqrMagnitude > minDist)
            {
                dir = dir.normalized;
                dir = dir.x * new Vector2(mainCam.right.x, mainCam.right.z).normalized + dir.y * new Vector2(mainCam.forward.x, mainCam.forward.z).normalized;

                if (move != null && dir != Vector2.zero) move(new Vector3(dir.x, 0, dir.y));
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouched = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouched = false;
        stick.position = bkg.position;
    }

    private Vector2 StickPosBound()
    {
        Vector2 pos = Input.mousePosition;
        Vector2 offset = pos - (Vector2)bkg.position;

        if (offset.sqrMagnitude < bkgRadius * bkgRadius) return pos;

        else return offset.normalized * bkgRadius + (Vector2)bkg.position;
    }
}
