using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    //�̵���ų Player ������Ʈ
    public GameObject gameObject_Player;

    //�̵��� ������(�̵��� ���� ��Ż)
    public Transform transform_Destination;

    //Player�� ��Ż�� �����ߴ��� Ȯ���ϴ� flag
    [SerializeField] private bool isPlayerArrivePotal;

    //�� ��ȣ ����
    public int int_MapNum;

    private void Update()
    {
        //��Ż �տ��� WŰ Ȥ�� �� ����Ű�� ������ ���
        if(isPlayerArrivePotal && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            //������ �̵�
            MoveToDestination();
        }
    }

    //Player�� ��Ż�� BoxCollider�� �´���� ���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("����");
        //Collsion�� Tag���� Player�� ���
        if(collision.CompareTag("Player"))
        {
            //��Ż�� ������
            isPlayerArrivePotal = true;
        }
    }

    //Player�� ��Ż�� BoxCollider���� ��������
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Collsion�� Tage���� Player�� ���
        if(collision.CompareTag("Player"))
        {
            //��Ż���� ���
            isPlayerArrivePotal = false;
        }
    }

    //�������� �̵�
    public void MoveToDestination()
    {
        //Player�� ��ġ���� �������� ��ġ������ ����
        gameObject_Player.transform.position = transform_Destination.position;
        //ī�޶��� ���� ������ �� ��ȣ�� ����
        Camera.main.GetComponent<CameraMove>().ChangeLimit(int_MapNum);
    }
}
