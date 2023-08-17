using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyPage : MonoBehaviour
{
    [SerializeField]
    Animator basketAnimator;

    public void OpenLevelSelector()
    {        
        basketAnimator.SetBool("isLevelSelector", true);
    }
    
}
