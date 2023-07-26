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
        current.transform.position += new Vector3(h, 0, v).normalized * Time.deltaTime * speed;
        //normalized : ���Ͱ��� normalized�� ��ȯ ������ �ش� ������ ���� ���Ͱ��� ���� �� �ִ�
        //������ ����ȭ, ���� ���͸� ����� ������ �Ѵٰ� ��
    }

}
