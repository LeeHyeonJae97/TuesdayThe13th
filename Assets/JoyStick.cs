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
    private Image bkgImage, stickImage;

    private Color32 transparent, opaque;
    private Vector2 dir;

    private int bkgRadius;
    private bool isTouched;

    private void Awake()
    {
        mainCam = Camera.main.transform;
        bkgRadius = (int)((RectTransform)bkg).rect.width / 2;

        bkgImage = bkg.GetComponent<Image>();
        stickImage = stick.GetComponent<Image>();

        transparent = new Color32(255, 255, 255, 0);
        opaque = new Color32(255, 255, 255, 255);
    }

    private void Update()
    {
        if (isTouched)
        {
            stick.position = StickPosBound();

            dir = (stick.position - bkg.position).normalized;        
            dir = dir.x * new Vector2(mainCam.right.x, mainCam.right.z).normalized + dir.y * new Vector2(mainCam.forward.x, mainCam.forward.z).normalized;            

            if (move != null && dir != Vector2.zero) move(new Vector3(dir.x, 0, dir.y));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        bkg.position = stick.position = eventData.position;

        bkgImage.color = opaque;
        stickImage.color = opaque;

        isTouched = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bkgImage.color = transparent;
        stickImage.color = transparent;

        isTouched = false;
    }

    private Vector2 StickPosBound()
    {
        Vector2 pos = Input.mousePosition;
        Vector2 offset = pos - (Vector2)bkg.position;

        if (offset.sqrMagnitude < bkgRadius * bkgRadius) return pos;

        else return offset.normalized * bkgRadius + (Vector2)bkg.position;
    }
}
