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
    /// 토끼 스피드
    /// </summary>
    public float speed { get; set; }


    /// <summary>
    /// 토끼가 감지하고있는 아이템
    /// </summary>
    public ItemDefault DetectItem { get; set; }
    
    
}