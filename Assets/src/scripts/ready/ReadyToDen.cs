using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyToDen : MonoBehaviour
{

    public void MoveToDen()
    {
        //ui �ö���� �ִϸ��̼� ���� ���� �� �̵��ϵ��� ����
        SceneManager.LoadScene("den");
    }

}
