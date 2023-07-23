using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class UIManager
{
    [SerializeField]
    TMP_Text timeText;
    public void Update()
    {
        float playTime = GameManager.playTime;
        int m = (int) playTime / 60;
        int s = (int) playTime % 60;
        timeText.text = "TIME " + m + " : " + s + "";
    }
}
