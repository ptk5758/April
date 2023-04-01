using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface Rabbit
{
    public void OnHit(Enemy enemy);
    public Item NearItem { get; set; }
    public static Rabbit Instance { get; }
    public Transform GetTransform();
    public void DropEgg();
    public List<Egg> GetEggs();    
}