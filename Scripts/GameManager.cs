using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float playerMaxHp;       // 플레이어의 최대 체력
    public float playerCurrentHp;   // 플레이어의 현재 체력

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1.0f;
    }

    void Start()
    {
        // 플레이어의 HP UI 초기화
        SetPlayerHpBar();

        // 배경음악 재생
        PlayBgm();
    }

    // 배경음악 재생
    public void PlayBgm()
    {
        // 배경음악 GameObject 생성
        SoundManager.instance.PlayBGM(SoundManager.instance.mainBgm, 0, true);
    }

    // 배경음악 정지
    public void StopBgm()
    {
        // 배경음악 GameObject를 찾아서 제거
        GameObject bgm = GameObject.Find("BGM");

        Destroy(bgm);
    }

    // 플레이어의 HP UI 초기화
    public void SetPlayerHpBar()
    {
        // 플레이어의 최대 체력과 현재 체력을 100으로 초기화
        playerMaxHp = 100.0f;
        playerCurrentHp = playerMaxHp;

        // 플레이어의 HP UI 업데이트
        UIManager.instance.UpdatePlayerHpBarUI();
    }

    // 플레이어의 HP UI 업데이트
    public void UpdatePlayerHpBar(float damage)
    {
        // 받은 데미지만큼 플레이어의 현재 체력 감소
        playerCurrentHp -= damage;

        // 플레이어의 HP UI 업데이트
        UIManager.instance.UpdatePlayerHpBarUI();
    }

    // 포탈 도착 결과 처리
    public void ArrivePortal()
    {
        // 도착 화면 보여주기
        UIManager.instance.ShowArrival();

        // 게임 동작 멈춤
        Time.timeScale = 0.0f;

        // URL 이동
    }

    // 게임 종료(Game Over)
    public void GameOver()
    {
        // Game Over 화면 보여주기
        UIManager.instance.ShowGameOver();

        // 배경음악 정지
        StopBgm();

        // 게임 동작 멈춤
        Time.timeScale = 0.0f;
    }
}
