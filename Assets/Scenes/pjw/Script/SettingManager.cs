using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    public RectTransform settingTransform;
    public void OpenSettings()
    {
        settingTransform.anchoredPosition = new Vector2(0, 0);
        
    }

    public void CloseSettings()
    {
        settingTransform.anchoredPosition = new Vector2(300, 0);
    }
}
