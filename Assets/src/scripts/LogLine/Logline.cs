using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logline : MonoBehaviour
{
    public GameObject[] logImage;
    public int images = 0;
    public GameObject[] panelObject;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //여기서 기본적으로 5초 지나면 옵젝 활성화되도록

        if (Input.GetMouseButtonDown(0))
        {
            try
            {
                GameObject logImages = logImage[images];

                images++;

                logImages.SetActive(true);
                anim.Play("LogLine");

            }
            catch
            {
                GoTitle();
            }

        }
    }

    void GoTitle()
    {
        Debug.Log("title로 이동");
    }
}
