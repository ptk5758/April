using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ItemDefault : MonoBehaviour, Item
{
    [SerializeField] private ItemType type;
    private void InitializeType()
    {
        switch (this.GetType().Name) //Type의 이름을 받아옴
        {
            case "EggDefault":
                type = ItemType.EGG;
                break;
            default :
                type = ItemType.ITEM;
                break;
        }
    }
    public ItemType GetItemType()
    {
        return type;
    }

    private void Awake()
    {
        InitializeType();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        //물리충돌이 일어난 다른 Object의 tag가 Player가 아니면 return
        OnRabbitEnter(other.gameObject.GetComponent<Rabbit>());
        //물리충돌은 다른 객체랑 일어나야지 줍기 버튼이 활성화 되는 코드로 넘어가야하는 거 아닌가?

    }

    private void OnRabbitEnter(Rabbit rabbit)
    {
        UIManager.isPickUP = true; //줍기 버튼을 활성화
        RabbitItemHandler rabbitItemHandler = rabbit.itemHandler;        
        rabbitItemHandler.SetDetectItem(this); //RabbititemHandler로 보내서 먹은 아이템을 비활성화
    }

    //토끼가 Egg 안에 들어갔다가 나오는 게 아니라 Egg를 주움으로써 Egg가 사라지기 때문에 
    //들어갔다가 나오는거라고 볼 수 없음 그러니까 들어가있지 않으면 줍는 버튼이 비활성화되게
    //줍기 비활성화가 되게 하기 위해서 Exit로 하면 Egg에 들어간 후 나왔을 때만 해당되기 때문에 줍고 나서는
    //나온 게 아니라 Egg가 사라진거라서 Exit로 인식하지 않는듯
    //그래서 RabbitItemHandler에서 DetectItemDisable이 Item을 먹고 난 후에 먹은 Item을 비활성화시켜주는 곳이기 때문에
    //먹은 Item이 사라지면 줍기 버튼도 비활성화 되야하기 때문에 같은 곳에서 비활성화 시켜줌

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        OnRabbitExit(other.gameObject.GetComponent<Rabbit>());
    }
    private void OnRabbitExit(Rabbit rabbit)
    {
        UIManager.isPickUP = false; //줍기 버튼을 비활성화
        RabbitItemHandler rabbitItemHandler = rabbit.itemHandler;
        rabbitItemHandler.SetDetectItem(null);
    }
    //Item이나 Egg를 줍지 않고 그냥 지나갈 수 있기 때문에 Exit로 있어야함

}
