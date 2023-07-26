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
    public void SetDetectItem(Item item) { //ItemImple�κ��� ���� Item�� �޾ƿ�
        detectItem = item;
    }
    public void PickUpItem()
    {
        if (detectItem == null) return; //SetDetectItem���� DetectItem�� item�� �־����� �ʾ�����
        
        switch (detectItem.GetItemType())
        {
            case ItemType.EGG:                
                PickUpEgg();
                break;
            case ItemType.ITEM:
                PickUpActiveItem();
                break;
        }

        DetectItemDisable(); //Egg, Item�� �԰� �� �Ŀ�  �ٽ� �������� ���� �� �ֵ��� �ϴ� ��
    }
    private void DetectItemDisable()
    {
        ItemDefault item = (ItemDefault) detectItem;
        item.gameObject.SetActive(false); //���� item�� ��Ȱ��ȭ ��Ű�鼭
        UIManager.isPickUP = false;
        detectItem = null; //�ٽ� item�� ���� �� �ְ� detectItem�� null ������ �ٲ�
    }

    private void PickUpEgg()
    {        
        Rabbit rabbit = current.GetComponent<Rabbit>();
        if (rabbit.IsPickUpEgg()) //Egg�� �ֿ����� -> true�̸�?
        {
            rabbit.AddEggInventory(detectItem as Egg);
            //detectItem�� �ִ� �� Egg��� �̸�����? �κ��丮�� ����
        }
        else
        {
            Debug.Log("�ް��� �ֿ�� �� ����");
        }
    }

    private void PickUpActiveItem() //item�� �ֿ�����
    {
        Rabbit.activeItem = detectItem;
        //detectItem�� �ִ� ���� activeItem���� �޾ƿ�
    }

}
