using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour, IItem
{    
    public enum Type { None, Egg, TimeAdder, before = -1 }

    [field:SerializeField]
    public Type type { get; protected set; }
    private void TypeInit()
    { 
        switch (this.GetType().Name)
        {
            case "DefaultEgg":
            case "Egg":
                type = Type.Egg;
                break;
            case "TimeAdder":
                type = Type.TimeAdder;
                break;
            default:
                type = Type.before;
                break;
        }
    }
    private GameManager gm;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;        
        // Rabbit instance = other.gameObject.GetComponent<Rabbit>();        
        gm.itemAction += UseItem;
        gm.itemType = this.type;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {            
            // Rabbit instance = other.gameObject.GetComponent<Rabbit>();            
            gm.itemAction -= UseItem;
            gm.itemType = Type.None;
        }
    }
    private void Awake()
    {        
        this.gm = GameManager.Instance;
        TypeInit();
    }
    public abstract void UseItem();
}
