using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    [SerializeField]
    RectTransform endingPanel;

    [SerializeField]
    TMP_Text endingScoreBoard;

    [SerializeField]
    Sprite[] resultValueImages;

    [SerializeField]
    Sprite[] resultRankImages;

    [SerializeField]
    Image resultValueImage;

    [SerializeField]
    Image resultRankImage;



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

    public void OpenEndingBoard()
    {
        endingScoreBoard.text = GameManager.eggCount.ToString();
        if (GameManager.eggCount > 0)
        {
            resultValueImage.sprite = resultValueImages[1];
        }
        else
        {
            resultValueImage.sprite = resultValueImages[0];
        }
        //resultValueImage.sprite;
        //resultRankImage.sprite;
        endingPanel.gameObject.SetActive(true);
    }

    public void CloseEndingBoard()
    {
        SceneManager.LoadScene("Ready");
        // endingPanel.gameObject.SetActive(false);
    }
}
