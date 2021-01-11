using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 선택지. 대화의 분기를 가르거나 특정한 일을 수행 가능하도록 상속하여 구현한다.
/// </summary>
public abstract class Option : ScriptableObject
{
    public string[] contents;
    public UnityAction[] onClicks;

    public abstract void Init(DialogueManager dialogueManager);
}
