using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOpener : MonoBehaviour
{

    public GameObject Panel;
    // Start is called before the first frame update
    public void OpenPanel()
    {   
        Panel.SetActive(true);
    }

    public void ClosePanel()
    {
        Panel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
