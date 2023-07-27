using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMoveMent
{
    private static GameObject current;
    public static float speed = 10;

    public RabbitMoveMent(GameObject gameObject) { //RabbitImple에서 gameObejct를 받아옴
        RabbitMoveMent.current = gameObject; //받아온 gameObject를 current에 저장
    }

    public void Moving() //토끼가 움직이게 함
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 rot = new Vector3(h, 0, v); //회전할 값 변수 설정??
        if(!(h==0 && v == 0))
        {
            current.transform.rotation = Quaternion.Lerp(current.transform.rotation, Quaternion.LookRotation(rot), Time.deltaTime*10); //변수 rot 값에 따라 토끼 주시방향으로 서서히 회전 
        }

        current.transform.position += new Vector3(h, 0, v).normalized * Time.deltaTime * speed;
        //normalized : 벡터값이 normalized를 반환 받으면 해당 벡터의 단위 벡터값을 받을 수 있다
        //벡터의 정규화, 단위 벡터를 만드는 역할을 한다고 함
    }

}
