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
        gm.itemHandler += OnUseItem;
        gm.itemType = this.type;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gm.itemHandler -= OnUseItem;
            gm.itemType = Type.None;
        }
    }
    private void Awake()
    {        
        this.gm = GameManager.Instance;
        TypeInit();
    }
    public abstract void OnUseItem(Rabbit rabbit);
    private void OnDestroy()
    {        
        gm.itemHandler -= OnUseItem;
        gm.itemType = Item.Type.None;
            
    }

    private static bool CheckDelegateHasMethod<DType>(DType @delegate, DType method) where DType : System.Delegate
    {
        foreach (System.Delegate del in @delegate.GetInvocationList())
        {
            if (del.Method == method.Method)
            {
                return true;
            }
        }
        return false;
        
        /* return @delegate?.GetInvocationList()
                .Where(d => d.Method == method.Method)
                .Count() > 0;
        */
    }

}
