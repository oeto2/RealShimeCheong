using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    //Scene�� �ҷ����ִ� �޼���(Start Button UI�� ����)
    public void LoadMainScene()
    {
        //TextScnene �ҷ�����
        SceneManager.LoadScene("TestScene");
    }
}
