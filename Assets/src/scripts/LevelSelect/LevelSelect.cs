using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    int i;

    public void SelectLevel(int value)
    {
        i = 0;
        LevelNumber.GetInt(i);
        Debug.Log("Level0 ��ư ����");
        PlayerPrefs.SetInt("GameLevel", (int)value);
        //Level.NORMAL�� int ���� 0�̴ϱ� 0�� PlayerPrefs�� ������ ����
        SceneManager.LoadScene("MapItemSelect");
        //�� Scene���� �ٲ�� �ڵ�
    }
}
