using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapWindowExit : MonoBehaviour
{
    //���� ������Ʈ
    public GameObject gameObject_MapWindow;
    
    //���� ���� ��ư
    public void MapWindowExitButton()
    {
        //���� ������Ʈ ��Ȱ��ȭ
        gameObject_MapWindow.SetActive(false);
    }
}
