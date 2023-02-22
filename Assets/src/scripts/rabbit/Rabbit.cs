using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rabbit : MonoBehaviour
{
    public float speed = 1;
    public bool isItem = false;

    [field:SerializeField]
    public Item item { get; set; }
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

    public void UseActiveItem()
    {
        if (item == null) return;
        item.UseItem();
    }
}
