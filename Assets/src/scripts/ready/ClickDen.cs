using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDen : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ClickDenButton()
    {
        anim.SetBool("Move", true);
    }
}
