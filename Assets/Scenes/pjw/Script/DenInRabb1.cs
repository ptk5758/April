using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DenInRabb1 : MonoBehaviour
{
    //public static GameObject[] rabbitSpecies;
    public int rabbitNum;
   
    public void SelectRabb()
    {
        //GameObject rabbitSpec = rabbitSpecies[rabbitNum];
        Debug.Log(rabbitNum);
        SceneManager.LoadScene("Ready");
    }

    //rabbitSpecies �䳢 ��/ Den �� �䳢 �ĺ��ϴ� ��
    //�̰� �������� �� == �ν����ͷ� �Ȱ�
    //�� �������� �� ���� �ϴ� ������ SelectRabb �Ű������� ��µ�
    //����������� ���������ϸ� �ȵǳ���?�ߴ��� �ȵɰǾ��ٰ��Ͻ�(�¸�)
    //DenInRabb���� ������ 5�� �ʱ�ȭ �� ����׷α׿��� 5�� ���
    //Ready ������ �÷��� �ÿ��� ���� ���� 0���� ǥ�õ�()

    //���� �䳢�� �ν����� ������ �ʱ�ȭ�Ǿ����
    //int�� �ƴ϶� GameObj�� �༭ �α׶���ó�� �迭�� ��¼���Ҽ��¾���??
    //DeninRabb �ν����Ϳ��� �����迭�� �� �䳢 �Ҵ�? xx
    //Ŭ�� > �� ������ �ν����Ͱ�(���� a)�� ������
    //wkrl�ڱ����� < �ȵ�~~��ģ

    //rabbitNum�� PlayRabb���� ��
}
