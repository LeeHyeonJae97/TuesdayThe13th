using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 상호작용 가능한 모든 오브젝트들. 현재 단서, NPC, 포탈의 세 가지가 있다.
/// </summary>
public abstract class InteractableObject : MonoBehaviour
{
    //**
    public Color interactButtonColor;

    public Sprite interactButton;

    public delegate void InteractCallBack(GameObject go);
    public InteractCallBack onInteract;

    // 단서와 상호작용할 시 호출될 메소드를 인자로 받아 저장한다.    
    public void Init(InteractCallBack onInteract)
    {
        if (this.onInteract == null && onInteract != null)
            this.onInteract = onInteract;
    }

    // 단서와 상호작용시 호출될 메소드
    public void Interact() => onInteract(gameObject);
}
