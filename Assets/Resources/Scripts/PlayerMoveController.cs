using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public float playerMoveSpeed; // 플레이어의 움직임 속도
    public float playerJumpSpeed; // 플레이어의 점프 속도
    public float playerRunSpeed;  // 플레이어의 달리기 속도

    float gravity = 9.8f;         // 중력
    float yVelocity = 0.0f;       // y축 속도

    Transform cameraPosition;     // 카메라 위치

    CharacterController cc;       // 캐릭터 컨트롤러

    Vector3 moveVector = Vector3.zero; // 플레이어의 이동 방향 * 이동 속도 (Move의 인자)

    void Start()
    {
        // 캐릭터 컨트롤러 가져오기
        cc = this.GetComponent<CharacterController>();

        // 카메라가 있을 위치 정보 가져오기
        cameraPosition = GameObject.Find("CamPos").transform;

        // 변수 초기화
        playerMoveSpeed = 8.0f;
        playerJumpSpeed = 5.0f;
        playerRunSpeed = 12.0f;
    }

    void Update()
    {
        // 플레이어 달리기
        PlayerRun();
    }

    // 카메라에 영향을 주는 업데이트 함수
    private void LateUpdate()
    {
        // 카메라 위치를 특정 위치(카메라가 있을 위치 정보)와 동일하게 적용
        Camera.main.transform.position = cameraPosition.position;
    }

    // 플레이어 달리기 (자동 이동)
    void PlayerRun()
    {
        // 왼쪽 Ctrl 키를 누르지 않으면 앞으로 자동 이동
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            // 플레이어 앞으로 자동 이동
            cc.Move(Vector3.forward * playerRunSpeed * Time.deltaTime);

            // 플레이어 이동 (방향키 사용 이동)
            PlayerMove();
        }
        else
        {
            // 플레이어 멈추기
            cc.Move(Vector3.zero);
        }
    }

    // 플레이어 이동 (방향키 사용 이동)
    void PlayerMove()
    {
        // 키보드 Horizontal, Vertical 입력을 각각 받아옴
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 플레이어의 이동 방향 적용
        moveVector.x = x;
        moveVector.y = -2.0f;
        moveVector.z = z;

        // 로컬의 이동벡터를 글로벌로 변환
        moveVector = transform.TransformDirection(moveVector);

        // 플레이어의 이동 속도 적용
        moveVector *= playerMoveSpeed;

        // 플레이어 점프
        //PlayerJump();

        // 플레이어 이동 적용
        cc.Move(moveVector * Time.deltaTime);
    }

    //플레이어 점프
    void PlayerJump()
    {
        // 바닥과 충돌 상태에서 Jump 버튼을 누른 경우
        if (cc.isGrounded && Input.GetButtonDown("Jump"))
        {
            // y축 속도를 플레이어의 점프 속도로 변경
            yVelocity = playerJumpSpeed;
        }

        // y축 방향으로 중력 적용 (바닥에 닿기 전까지 아래로 떨어지도록)
        yVelocity -= (gravity * Time.deltaTime);
        moveVector.y = yVelocity;
    }
}