using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rabbit : MonoBehaviour
{
    
    public float speed = 1;
    [SerializeField] private List<Egg> eggs;
    private void Awake()
    {
        eggs = new List<Egg>();
    }
    private void FixedUpdate()
    {
        Moving();
    }

    private void Moving()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(h, 0, v).normalized * Time.deltaTime * speed;
    }
    public void AddEgg(Egg egg)
    {        
        eggs.Add(egg);
    }
}
