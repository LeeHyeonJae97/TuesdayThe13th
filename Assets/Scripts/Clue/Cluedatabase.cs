using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Cluedatabase: MonoBehaviour
{
    public static Cluedatabase instance;
    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    public List<ClueData>ClueDB = new List<ClueData>();
}
