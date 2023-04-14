using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoglineManager : MonoBehaviour
{
    public GameObject[] logImage;
    public int images=0;

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            try
            {
                GameObject logImages = logImage[images];
            
                images++;
           
                logImages.SetActive(true);

            }
            catch
            {
                GoTitle();
            }
            
           


        }
    }

    void GoTitle() 
    {
        SceneManager.LoadScene("Title");
    }
}
