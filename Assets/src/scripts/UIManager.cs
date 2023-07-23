using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class UIManager
{
    public static bool isPickUP = false;

    [SerializeField]
    TMP_Text timeText;

    [SerializeField]
    Image activeButton;
    public void Update()
    {
        UpdateTimeText();
        UpdatePickUpButton();
    }
    private void UpdateTimeText()
    {
        float playTime = GameManager.playTime;
        int m = (int)playTime / 60;
        int s = (int)playTime % 60;
        timeText.text = "TIME " + m + " : " + s + "";
    }    
    private void UpdatePickUpButton()
    {   
        activeButton.gameObject.SetActive(isPickUP);
    }
}
