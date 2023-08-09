using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemManager
{
    static Transform[] transforms;

    [SerializeField]
    Transform transformsGroup;

    [SerializeField]
    GameObject boosterPrefab;

    [SerializeField]
    GameObject TimerPrefab;
}
