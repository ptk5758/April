using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMoveMent
{
    private static GameObject current;

    public RabbitMoveMent(GameObject gameObject) {
        RabbitMoveMent.current = gameObject;
    }

    public void Moving()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        // current.transform.position += new Vector3(h, 0, v).normalized * Time.deltaTime * _speed;
        current.transform.position += new Vector3(h, 0, v).normalized * Time.deltaTime;
    }

}
