using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DjManager : MonoBehaviour
{
    GameObject Dj;
    AudioSource backMusic;
    private void Awake()
    {
        Dj=GameObject.Find("Dj");
        backMusic = Dj.GetComponent<AudioSource>();
        if (backMusic.isPlaying) return;
        else
        {
            backMusic.Play();
            DontDestroyOnLoad(Dj);
        }


    }
}
