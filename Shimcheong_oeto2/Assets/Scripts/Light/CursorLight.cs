using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLight : MonoBehaviour
{
    //UI Manager Scripts
    public UIManager script_UIManager;

    //���콺 Ŀ���� ������ ��
    private Vector3 vector3_CursorPos;

    // Update is called once per frame
    void Update()
    {
        //Ŀ�� ��ġ ��
        vector3_CursorPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        
        //������â�� ������ ������ ���� ���¿����� ������ ���콺 Ŀ���� �ű�
        if(!script_UIManager.isItemWindowLaunch && !script_UIManager.isMapWindowLaunch)
        {
            transform.position = vector3_CursorPos;
        }
    }
}
