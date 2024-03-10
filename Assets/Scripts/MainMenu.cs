using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public GameObject aboutinfo;
/*    public GameObject aboutinfo;*/
    public GameObject howtoplayinfo;

    private bool imageactive = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void about()
    {
        if (!imageactive)
        {
            aboutinfo.SetActive(true);
            imageactive = true;
        }
        else
        {
            aboutinfo.SetActive(false);
            imageactive = false;
        }

    }
/*    public void close()
    {
            aboutinfo.SetActive(false);
            imageactive = false;

    }*/
    public void howtoplay()
    {
        /* aboutinfo.SetActive(false);
         image.SetActive(false);
         */
        howtoplayinfo.SetActive(true);
    }
    public void closehowtoplay()
    {
        howtoplayinfo.SetActive(false);
    }
}
