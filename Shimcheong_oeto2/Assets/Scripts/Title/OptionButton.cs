using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    //�ɼ� �������̽� ������Ʈ
    public GameObject gameObject_optionInterface;


    //�ɼ� ���� â�� ����ִ� �޼���
    public void OptionStart()
    {
        //�ɼ� �������̽� ������Ʈ Ȱ��ȭ
        gameObject_optionInterface.SetActive(true);
    }
}
