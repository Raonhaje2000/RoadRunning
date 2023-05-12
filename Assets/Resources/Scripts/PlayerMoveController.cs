using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public float playerMoveSpeed; // �÷��̾��� ������ �ӵ�
    public float playerJumpSpeed; // �÷��̾��� ���� �ӵ�
    public float playerRunSpeed;  // �÷��̾��� �޸��� �ӵ�

    float gravity = 9.8f;         // �߷�
    float yVelocity = 0.0f;       // y�� �ӵ�

    Transform cameraPosition;     // ī�޶� ��ġ

    CharacterController cc;       // ĳ���� ��Ʈ�ѷ�

    Vector3 moveVector = Vector3.zero; // �÷��̾��� �̵� ���� * �̵� �ӵ� (Move�� ����)

    void Start()
    {
        // ĳ���� ��Ʈ�ѷ� ��������
        cc = this.GetComponent<CharacterController>();

        // ī�޶� ���� ��ġ ���� ��������
        cameraPosition = GameObject.Find("CamPos").transform;

        // ���� �ʱ�ȭ
        playerMoveSpeed = 8.0f;
        playerJumpSpeed = 5.0f;
        playerRunSpeed = 12.0f;
    }

    void Update()
    {
        // �÷��̾� �޸���
        PlayerRun();
    }

    // ī�޶� ������ �ִ� ������Ʈ �Լ�
    private void LateUpdate()
    {
        // ī�޶� ��ġ�� Ư�� ��ġ(ī�޶� ���� ��ġ ����)�� �����ϰ� ����
        Camera.main.transform.position = cameraPosition.position;
    }

    // �÷��̾� �޸��� (�ڵ� �̵�)
    void PlayerRun()
    {
        // ���� Ctrl Ű�� ������ ������ ������ �ڵ� �̵�
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            // �÷��̾� ������ �ڵ� �̵�
            cc.Move(Vector3.forward * playerRunSpeed * Time.deltaTime);

            // �÷��̾� �̵� (����Ű ��� �̵�)
            PlayerMove();
        }
        else
        {
            // �÷��̾� ���߱�
            cc.Move(Vector3.zero);
        }
    }

    // �÷��̾� �̵� (����Ű ��� �̵�)
    void PlayerMove()
    {
        // Ű���� Horizontal, Vertical �Է��� ���� �޾ƿ�
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // �÷��̾��� �̵� ���� ����
        moveVector.x = x;
        moveVector.y = -2.0f;
        moveVector.z = z;

        // ������ �̵����͸� �۷ι��� ��ȯ
        moveVector = transform.TransformDirection(moveVector);

        // �÷��̾��� �̵� �ӵ� ����
        moveVector *= playerMoveSpeed;

        // �÷��̾� ����
        //PlayerJump();

        // �÷��̾� �̵� ����
        cc.Move(moveVector * Time.deltaTime);
    }

    //�÷��̾� ����
    void PlayerJump()
    {
        // �ٴڰ� �浹 ���¿��� Jump ��ư�� ���� ���
        if (cc.isGrounded && Input.GetButtonDown("Jump"))
        {
            // y�� �ӵ��� �÷��̾��� ���� �ӵ��� ����
            yVelocity = playerJumpSpeed;
        }

        // y�� �������� �߷� ���� (�ٴڿ� ��� ������ �Ʒ��� ����������)
        yVelocity -= (gravity * Time.deltaTime);
        moveVector.y = yVelocity;
    }
}