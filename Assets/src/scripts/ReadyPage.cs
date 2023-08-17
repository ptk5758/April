using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyPage : MonoBehaviour
{
    [SerializeField]
    Animator basketAnimator;

    public void OpenLevelSelector()
    {
        StartCoroutine(BasketAnimation());
    }
    IEnumerator BasketAnimation()
    {
        basketAnimator.SetBool("isLevelSelector", true);
        yield return null;
        basketAnimator.SetBool("isLevelSelector", false);
    }
}
