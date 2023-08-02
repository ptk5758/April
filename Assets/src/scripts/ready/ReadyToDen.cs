using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyToDen : MonoBehaviour
{

    public void MoveToDen()
    {
        //ui 올라오는 애니메이션 동작 이후 씬 이동하도록 수정
        SceneManager.LoadScene("den");
    }

}
