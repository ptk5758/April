using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    int i;

    public void Level0Select() //Level0�� ���õ��� ��
    {
        i = 0;
        LevelNumber.GetInt(i);
        Debug.Log("Level0 ��ư ����");
        SceneManager.LoadScene("MapItemSelect");
        //�� Scene���� �ٲ�� �ڵ�
    }

    public void Level1Select() //Level1�� ���õ��� ��
    {
        i = 1;
        LevelNumber.GetInt(i);
        Debug.Log("Level1 ��ư ����");
        SceneManager.LoadScene("MapItemSelect");
        //�� Scene���� �ٲ�� �ڵ�
    }

    public void Level2Select() //Level2�� ���õ��� ��
    {
        i = 2;
        LevelNumber.GetInt(i);
        Debug.Log("Level2 ��ư ����");
        SceneManager.LoadScene("MapItemSelect");
        //�� Scene���� �ٲ�� �ڵ�
    }

    public void Level3Select() //Level3�� ���õ��� ��
    {
        i = 3;
        LevelNumber.GetInt(i);
        Debug.Log("Level3 ��ư ����");
        SceneManager.LoadScene("MapItemSelect");
        //�� Scene���� �ٲ�� �ڵ�
    }
}
