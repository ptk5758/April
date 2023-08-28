using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickDen : MonoBehaviour
{
    public GameObject readyObject;
    public GameObject rabbitObject;

    Animator rabbit;
    Animator ready;

    void Start()
    {
        rabbit = rabbitObject.GetComponent<Animator>();
        ready = readyObject.GetComponent<Animator>();
    }

    public void ClickDenButton()
    {
        Debug.Log("버튼 눌림");
        ready.SetBool("Move", true);
        rabbit.SetBool("RabbitMove", true);
    }
 
}
