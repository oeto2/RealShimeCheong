using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //�ܺ� ��ũ��Ʈ
    public WallDetect wallDetectScr;

    //ī�޶� ������ ������Ʈ�� Transform��
    public Transform transform_TrargetObject;

    //ī�޶� ���� �ӵ�
    [SerializeField] [Range(1, 30)] private float speed;

    //ī�޶� ���� ��
    private Transform transform_CameraLimit;

    //���� �������� Transform��
    public Transform[] transform_Limits;

    //ī�޶��� ȭ���� ���� ���� ��
    private float hight;
    //ȭ���� ���� ��
    private float width;

    private void Start()
    {
        //hight = ī�޶� ȭ���� ����ũ�� ���� ��
        hight = Camera.main.orthographicSize;
        //width = ī�޶� ȭ���� ����ũ�� ���� ��
        width = hight * Screen.width / Screen.height;
        //�⺻ ���� ���� �� ��ȣ
        ChangeLimit(0);
    }
    
    //���� ���� �ٲٱ�
    public void ChangeLimit(int x)
    {
        //ī�޶��� ���� ���� �� ����
        transform_CameraLimit = transform_Limits[x];
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //ī�޶� ������Ʈ�� ������ ���� ����������Ʈ�� �����ǰ� ���� ���̰����� ���� (Y��,Z���� ����)
        transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, 1, 0), new Vector3( transform_TrargetObject.position.x, 1,0), Time.deltaTime * speed);

        //lx = ���ѿ����� ���� ���� �� - ī�޶� ���� ���ݰ�
        float lx = transform_CameraLimit.localScale.x * 0.5f - width;
        //clampX = X�� ���� ��
        float clampX = Mathf.Clamp(transform.position.x, -lx + transform_CameraLimit.position.x, lx + transform_CameraLimit.position.x);

        //ly = ���� ������ ���� ���� �� - ī�޶� ���� ���ݰ�
        float ly = transform_CameraLimit.localScale.y * 0.5f - hight;
        //clampY = Y�� ���� ��
        float clampY = Mathf.Clamp(transform.position.y, -ly + transform_CameraLimit.position.y, ly + transform_CameraLimit.position.y);

        //ī�޶� ���� �� ����
        transform.position = new Vector3(clampX, clampY, -10f);
    }
  
}
