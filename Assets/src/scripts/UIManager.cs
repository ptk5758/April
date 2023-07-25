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
    Image pickUpButton;

    [SerializeField]
    Image activeItemButton;

    [SerializeField]
    TMP_Text scoreText;

    public void Update()
    {
        UpdateTimeText();
        UpdatePickUpButton();
        UpdateActiveItemButton();
        UpdateScoreText();
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
        pickUpButton.gameObject.SetActive(isPickUP);
    }

    private void UpdateActiveItemButton()
    {   
        activeItemButton.gameObject.SetActive(Rabbit.activeItem != null);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score " + GameManager.eggCount;
    }
}
