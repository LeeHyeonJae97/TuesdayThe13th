using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MInimapOnOff : MonoBehaviour
{
    

    public void Button()
    {
        if(gameObject.activeSelf == true)
            gameObject.SetActive(false);
        if(gameObject.activeSelf == false)
            gameObject.SetActive(true);
    }
}
