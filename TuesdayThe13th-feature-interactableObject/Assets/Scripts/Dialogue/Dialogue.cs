using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObject/Dialogue")]
public class Dialogue : ScriptableObject
{
    // 말하는 사람의 이름, 이미지, 대사를 저장
    [System.Serializable]
    public struct Speak
    {
        public string speaker;
        public Sprite image;
        public string content;
    }

    public string dialogueName;
    public bool repeatable; // 대화가 반복해서 이루어질 수 있는지 혹은 한번 진행되었다면 다시는 진행될 수 없는지 여부를 저장
    [HideInInspector] public bool readMain;
    public Speak[] mainSpeaks;
    public Speak[] subSpeaks;
    public Option option; // 대화 후 선택 가능한 선택지
}
