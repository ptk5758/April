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
    public abstract void SetType(); // 자신의 type 을 설정하는 함수 이며 Awake 단계에서 호출된다
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
    public abstract void OnUseItem(Rabbit rabbit); // 아이템 사용 할때 호출

    private void Awake()
    {
        SetType(); // 아이템의 Type 설정
    }

    private void OnDestroy() // 오브젝트가 파괴됄때 호출됨
    {
        // Debug.Log(gameObject + "OnDestroy!");
    }    

}
