using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public enum Type { PLAY_TIME }
    private Dictionary<Type, Text> UIMap;
    public Text playTimeUI;
    private void Awake()
    {
        InitialMap();
    }
    private void InitialMap()
    {
        UIMap = new Dictionary<Type, Text>();
        UIMap.Add(Type.PLAY_TIME, playTimeUI);
    }
    public void SetUIText(Type type, string text)
    {
        UIMap[type].text = text;
    }
}
