using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitItemHandler
{
    GameObject current;
    Item detectItem;    
    public RabbitItemHandler(GameObject gameObject)
    {
        current = gameObject;
    }
    public void SetDetectItem(Item item) { //ItemImple로부터 먹은 Item을 받아옴
        detectItem = item;
    }
    public void PickUpItem()
    {
        if (detectItem == null) return; //SetDetectItem에서 DetectItem에 item을 넣어주지 않았으면
        
        switch (detectItem.GetItemType())
        {
            case ItemType.EGG:                
                PickUpEgg();
                break;
            case ItemType.ITEM:
                PickUpActiveItem();
                break;
        }

        DetectItemDisable(); //Egg, Item을 먹고 난 후에  다시 아이템을 먹을 수 있도록 하는 곳
    }
    private void DetectItemDisable()
    {
        ItemDefault item = (ItemDefault) detectItem;
        item.gameObject.SetActive(false); //먹은 item을 비활성화 시키면서
        UIManager.isPickUP = false;
        detectItem = null; //다시 item을 먹을 수 있게 detectItem을 null 값으로 바꿈
    }

    private void PickUpEgg()
    {        
        Rabbit rabbit = current.GetComponent<Rabbit>();
        if (rabbit.IsPickUpEgg()) //Egg를 주웠으면 -> true이면?
        {
            rabbit.AddEggInventory(detectItem as Egg);
            //detectItem에 있는 걸 Egg라는 이름으로? 인벤토리에 저장
        }
        else
        {
            Debug.Log("달걀을 주울수 가 없습");
        }
    }

    private void PickUpActiveItem() //item을 주웠으면
    {
        Rabbit.activeItem = detectItem;
        //detectItem에 있는 값을 activeItem으로 받아옴
    }

}
