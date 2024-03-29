using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemManager
{

    private Transform[] transforms;

    [SerializeField]
    private Transform transformsGroup;

    [SerializeField]
    private GameObject boosterPrefab;

    [SerializeField]
    private GameObject TimerPrefab;

    private int maxItem;

    public void InitializeItemManager()
    {
        transforms = transformsGroup.GetComponentsInChildren<Transform>();
        maxItem = LevelManager.GetGameLevelOptionData(GameLevelOption.ITEM);
        SummonItem();
    }

    private void SummonItem()
    {
        GameObject[] objects = new GameObject[] { boosterPrefab, TimerPrefab };
        for (int i=0; i<maxItem; i++)
        {
            GameObject obj = Object.Instantiate(objects[Random.Range(0, 2)], transformsGroup);
            obj.transform.position = transforms[Random.Range(1, transforms.Length)].position;
        }
    }
}
