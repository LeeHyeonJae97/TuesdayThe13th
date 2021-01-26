using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChange : MonoBehaviour
{
    // Start is called before the first frame update
    

    public GameObject Panel;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;


    // Start is called before the first frame update
    public void OpenPanel()
    {
        Panel.SetActive(true);
        panel2.SetActive(false);
        panel3.SetActive(false);
        panel4.SetActive(false);
    }
    
}
