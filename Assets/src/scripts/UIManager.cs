using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public enum Type { PLAY_TIME, EGG_COUNT }
    private Dictionary<Type, Text> UIMap;

    [Header("Text Attribute")]
    public Text playTimeUI;
    public Text eggCountUI;
    private void Awake()
    {
        InitialMap();
    }
    private void InitialMap()
    {
        UIMap = new Dictionary<Type, Text>();
        UIMap.Add(Type.PLAY_TIME, playTimeUI);
        UIMap.Add(Type.EGG_COUNT, eggCountUI);
    }
    public void SetUIText(Type type, string text)
    {
        UIMap[type].text = text;
    }
}
