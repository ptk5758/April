using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rabbit : MonoBehaviour
{
    
    public float speed = 1;
    public float eggWeight = 0.5f;
    public List<Egg> eggs;
    private float _speed;
    private void Awake()
    {
        eggs = new List<Egg>();
        // _speed = speed - eggs.Count * eggWeight;
    }
    private void Update()
    {
        _speed = speed - eggs.Count * eggWeight;
    }
    private void FixedUpdate()
    {
        Moving();
    }

    private void Moving()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(h, 0, v).normalized * Time.deltaTime * _speed;
    }
    public void AddEgg(Egg egg)
    {        
        eggs.Add(egg);
    }
}
