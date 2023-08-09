using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemManager
{
    [SerializeField]
    private Transform[] transforms;

    [SerializeField]
    private Transform transformsGroup;

    [SerializeField]
    private GameObject boosterPrefab;

    [SerializeField]
    private GameObject TimerPrefab;

    public void InitializeItemManager()
    {
        transforms = transformsGroup.GetComponentsInChildren<Transform>();
    }
}
