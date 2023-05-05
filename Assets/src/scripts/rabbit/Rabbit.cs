using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface Rabbit
{
    public static Rabbit instance;
    public static Rabbit Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = GameObject.FindObjectOfType<RabbitImple>();
                if (obj != null)
                    instance = obj;
            }
            return instance;
        }
        private set { instance = value; }
    }
    public void OnHit(Fox fox);
    public Transform GetTransform();    

    /// <summary>
    /// �䳢 ���ǵ�
    /// </summary>
    public float speed { get; set; }


    /// <summary>
    /// �䳢�� �����ϰ��ִ� ������
    /// </summary>
    public ItemDefault DetectItem { get; set; }
    
    
}