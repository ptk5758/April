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

    [Header("Button UI")]
    public Image pickUpButton;

    [Header("Active Item")]
    public GameObject activeItem;

    private void Awake()
    {
        UIMap = new Dictionary<Type, Text>();
        UIMap.Add(Type.PLAY_TIME, playTimeUI);
        UIMap.Add(Type.EGG_COUNT, eggCountUI);
    }

    private void Start()
    {
        activeItem.SetActive(false);
    }

    public void SetUIText(Type type, string text)
    {
        UIMap[type].text = text;
    }

    public void SetAbleToPickUpButton(bool status)
    {
        if (status)
        {
            Color temp = pickUpButton.color;
            temp.a = 1f;
            pickUpButton.color = temp;            
        }
        else
        {
            Color temp = pickUpButton.color;
            temp.a = 0.4f;
            pickUpButton.color = temp;
        }

    }

    public void SetActiveItemButton(ActiveItem item)
    {
        activeItem.SetActive(true);
        Button btn = activeItem.GetComponent<Button>();
        btn.onClick.AddListener(item.OnUseItem);
    }
}
