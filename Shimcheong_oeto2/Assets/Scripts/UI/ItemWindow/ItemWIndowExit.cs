using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWIndowExit : MonoBehaviour
{
    //������ â ������Ʈ
    public GameObject gameObject_ItemWindow;

    //������â ����
    public void ItemWindowExit()
    {
        //������ â ������Ʈ ��Ȱ��ȭ
        gameObject_ItemWindow.SetActive(false);
    }
}
