using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour, IItem
{
    public enum Type { 
        EGG,
        ACTIVE,
        PASSIVE
    }
    /**
     * private
     * */
    private Rabbit rabbit;
    public Type type;
    public abstract void SetType(); // �ڽ��� type �� �����ϴ� �Լ� �̸� Awake �ܰ迡�� ȣ��ȴ�
    private void OnTriggerEnter(Collider other)
    {
        // Rabbit Item In Event
        if (other.gameObject.tag != "Player") return;
        rabbit = other.gameObject.GetComponent<Rabbit>();
        rabbit.NearItem = this;
    }
    private void OnTriggerExit(Collider other)
    {
        // Rabbit Item Exit Event
        if (other.gameObject.tag == "Player")
        {
            if (rabbit.NearItem != null)
                rabbit.NearItem = null;
        }
    }
    public abstract void OnUseItem(Rabbit rabbit); // ������ ��� �Ҷ� ȣ��

    private void Awake()
    {
        SetType(); // �������� Type ����
    }

    private void OnDestroy() // ������Ʈ�� �ı��ƶ� ȣ���
    {
        // Debug.Log(gameObject + "OnDestroy!");
    }    

}
