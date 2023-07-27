using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMoveMent
{
    private static GameObject current;
    public static float speed = 10;

    public RabbitMoveMent(GameObject gameObject) { //RabbitImple���� gameObejct�� �޾ƿ�
        RabbitMoveMent.current = gameObject; //�޾ƿ� gameObject�� current�� ����
    }

    public void Moving() //�䳢�� �����̰� ��
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 rot = new Vector3(h, 0, v); //ȸ���� �� ���� ����??
        if(!(h==0 && v == 0))
        {
            current.transform.rotation = Quaternion.Lerp(current.transform.rotation, Quaternion.LookRotation(rot), Time.deltaTime*10); //���� rot ���� ���� �䳢 �ֽù������� ������ ȸ�� 
        }

        current.transform.position += new Vector3(h, 0, v).normalized * Time.deltaTime * speed;
        //normalized : ���Ͱ��� normalized�� ��ȯ ������ �ش� ������ ���� ���Ͱ��� ���� �� �ִ�
        //������ ����ȭ, ���� ���͸� ����� ������ �Ѵٰ� ��
    }

}
