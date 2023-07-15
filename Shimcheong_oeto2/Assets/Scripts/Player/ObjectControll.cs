using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControll : MonoBehaviour
{
    //������Ʈ �Ŵ��� ��ũ��Ʈ
    public ObjectManager objectManagerScr;

    //������Ʈ ������ ��ũ��Ʈ
    [SerializeField]
    private objdata objdataScr;

    //Player�� ������Ʈ�� ���������� Ȯ���ϴ� flag
    [SerializeField]
    private bool isTriggerObject;

    //Player�� ȹ���� ������Ʈ
    [SerializeField]
    private GameObject gameobject_TargetObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //������Ʈ ������ ZŰ�� ������ ���
        if(Input.GetKeyDown(KeyCode.Z) && isTriggerObject) 
        {
            Debug.Log("����");
            Debug.Log(objdataScr.id);
            //������Ʈ �߰�
            objectManagerScr.GetItem(objdataScr.id);
            //������Ʈ SetActive false
            gameobject_TargetObject.SetActive(false);
        }

    }

    //������Ʈ BoxCollider�� ���˽�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�������� ���
        if(collision.CompareTag("Item"))
        {
            //������ ������Ʈ
            gameobject_TargetObject = collision.gameObject;

            isTriggerObject = true;

            //������ ������ Objdata�� ������
            objdataScr = gameobject_TargetObject.GetComponent<objdata>();
        }
    }

    //������Ʈ BoxCollider�� �������ϰ��
    private void OnTriggerStay2D(Collider2D collision)
    { 
        if(collision.CompareTag("Item"))
        {
            isTriggerObject = true;
        }
    }

    //������Ʈ boxCollider�� �������� ���
    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggerObject = false;
    }

    
}
