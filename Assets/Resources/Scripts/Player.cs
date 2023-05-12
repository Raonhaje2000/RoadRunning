using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum State
    { 
        STOP = 0,   // 멈춤
        RUN = 1,    // 달리기
        DAMAGE = 2, // 장애물과 충돌
        DEAD = 3    // 사망 (체력 0)
    }

    State playerState;

    void Start()
    {
        // 플레이어의 상태 초기화
        playerState = State.RUN;
    }

    void Update()
    {
        switch (playerState)
        {
            case State.STOP:
                {
                    break;
                }
            case State.RUN:
                {
                    break;
                }
            case State.DAMAGE:
                { 
                    if(GameManager.instance.playerCurrentHp <= 0.0f)
                    {
                        // 플레이어의 체력이 0 이하인 경우 DEAD 상태로 전이
                        playerState = State.DEAD;
                    }
                    else
                    {
                        // 플레이어의 체력이 남아있는 경우 RUN 상태로 전이
                        playerState = State.RUN;
                    }

                    break;
                }
            case State.DEAD:
                {
                    // 게임 종료(Game Over)
                    GameManager.instance.GameOver();

                    break;
                }
        }
    }

    // 플레이어와 충돌한 GageObject 확인
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            // 장애물과 부딪힌 경우 플레이어 체력 5 감소
            SoundManager.instance.PlaySfx(this.transform.position, SoundManager.instance.collision, 0, SoundManager.instance.sfxVolum);
            GameManager.instance.UpdatePlayerHpBar(5.0f);

            // 플레이어 상태를 DAMAGE로 전이
            playerState = State.DAMAGE;
        }
        else if(other.tag == "People")
        {
            // 사람과 부딪힌 경우 플레이어 체력 10 감소
            SoundManager.instance.PlaySfx(this.transform.position, SoundManager.instance.collision, 0, SoundManager.instance.sfxVolum);
            GameManager.instance.UpdatePlayerHpBar(10.0f);

            // 플레이어의 상태를 DAMAGE로 전이
            playerState = State.DAMAGE;
        }
        else if(other.tag == "Portal")
        {
            // 포탈과 부딪힌 경우 포탈 도착 결과 처리
            GameManager.instance.ArrivePortal();
        }
    }
}
