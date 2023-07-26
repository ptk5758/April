using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ItemDefault : MonoBehaviour, Item
{
    [SerializeField] private ItemType type;
    private void InitializeType()
    {
        switch (this.GetType().Name) //Type�� �̸��� �޾ƿ�
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
        //�����浹�� �Ͼ �ٸ� Object�� tag�� Player�� �ƴϸ� return
        OnRabbitEnter(other.gameObject.GetComponent<Rabbit>());
        //�����浹�� �ٸ� ��ü�� �Ͼ���� �ݱ� ��ư�� Ȱ��ȭ �Ǵ� �ڵ�� �Ѿ���ϴ� �� �ƴѰ�?

    }

    private void OnRabbitEnter(Rabbit rabbit)
    {
        UIManager.isPickUP = true; //�ݱ� ��ư�� Ȱ��ȭ
        RabbitItemHandler rabbitItemHandler = rabbit.itemHandler;        
        rabbitItemHandler.SetDetectItem(this); //RabbititemHandler�� ������ ���� �������� ��Ȱ��ȭ
    }

    //�䳢�� Egg �ȿ� ���ٰ� ������ �� �ƴ϶� Egg�� �ֿ����ν� Egg�� ������� ������ 
    //���ٰ� �����°Ŷ�� �� �� ���� �׷��ϱ� ������ ������ �ݴ� ��ư�� ��Ȱ��ȭ�ǰ�
    //�ݱ� ��Ȱ��ȭ�� �ǰ� �ϱ� ���ؼ� Exit�� �ϸ� Egg�� �� �� ������ ���� �ش�Ǳ� ������ �ݰ� ������
    //���� �� �ƴ϶� Egg�� ������Ŷ� Exit�� �ν����� �ʴµ�
    //�׷��� RabbitItemHandler���� DetectItemDisable�� Item�� �԰� �� �Ŀ� ���� Item�� ��Ȱ��ȭ�����ִ� ���̱� ������
    //���� Item�� ������� �ݱ� ��ư�� ��Ȱ��ȭ �Ǿ��ϱ� ������ ���� ������ ��Ȱ��ȭ ������

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        OnRabbitExit(other.gameObject.GetComponent<Rabbit>());
    }
    private void OnRabbitExit(Rabbit rabbit)
    {
        UIManager.isPickUP = false; //�ݱ� ��ư�� ��Ȱ��ȭ
        RabbitItemHandler rabbitItemHandler = rabbit.itemHandler;
        rabbitItemHandler.SetDetectItem(null);
    }
    //Item�̳� Egg�� ���� �ʰ� �׳� ������ �� �ֱ� ������ Exit�� �־����

}
