using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetect : MonoBehaviour
{
    //�ܺ� ��ũ��Ʈ
    public Controller playerControlScr;

    //���� ������ RayCast
    private RaycastHit2D rayHit2D;

    public SpriteRenderer spriteRender;

    private int direction;

    //�󸶸�ŭ ���̸� ����� �Ұ���
    [SerializeField]
    [Range(-3, 3f)] private float raySpace;

    //ray�� ����
    [SerializeField]
    [Range(0, 3f)] private float rayLength;

    private void Update()
    {
        if(!spriteRender.flipX)
        {
            direction = 1;
        }

        else if (spriteRender.flipX)
        {
            direction = -1;
        }

        //�� ������ ����� ����
        Debug.DrawRay(new Vector2(transform.position.x + (raySpace * direction), transform.position.y), new Vector2(rayLength * direction, 0), new Color(0, 1, 0));

        //�� ������ ����
        rayHit2D = Physics2D.Raycast(new Vector2(transform.position.x + (raySpace * direction), transform.position.y), new Vector2(1 * direction, 0), rayLength, LayerMask.GetMask("Wall"));

        //���� ���� �Ǿ��ٸ�
        if(rayHit2D.collider != null)
        {
            //�̵� ����
            playerControlScr.detectWall = true;
        }

        //�ƹ��͵� �������� �ʾҴٸ�
        else if(rayHit2D.collider == null)
        {
            //�̵����� ����
            playerControlScr.detectWall = false;
        }

    }
}
