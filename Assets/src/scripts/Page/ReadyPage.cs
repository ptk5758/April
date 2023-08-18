using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyPage : MonoBehaviour
{
    [SerializeField]
    Animator basketAnimator;

    [SerializeField]
    ReadyPageUI readyPageUI;

    public void ActivationLevelSelectBoard(bool state)
    {
        readyPageUI.ActiveLevelSelectBoard(state);
    }
}

[System.Serializable]
class ReadyPageUI
{
    [SerializeField]
    GameObject levelSelectBoard;

    internal void ActiveLevelSelectBoard(bool state)
    {
        levelSelectBoard.SetActive(state);
    }

}