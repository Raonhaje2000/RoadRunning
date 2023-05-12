using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public ProgressBar playerHpBar;     // 플레이어의 HP UI

    public GameObject gameOver;         // Game Over 되었을 때의 화면
    public GameObject arrival;          // 도착 했을 때의 화면

    public Text timerText;              // 타이머 글자

    public Text remainingDistanceText;  // 남은 거리 글자
    public ProgressBar distanceBar;     // 거리 표기 UI

    public Text arrivalTimeText;        // 도착한 시간 글자

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // 화면 비활성화
        gameOver.SetActive(false);
        arrival.SetActive(false);
    }

    // 플레이어의 HP UI 업데이트
    public void UpdatePlayerHpBarUI()
    {
        playerHpBar.BarValue = GameManager.instance.playerCurrentHp / GameManager.instance.playerMaxHp * 100.0f;
    }

    // 타이머 UI의 글자 업데이트
    public void UpdateTimerText(int min, int sec, int msec)
    {
        timerText.text = string.Format("{0:D2}:{1:D2}.{2:D3}", min, sec, msec);

        if (arrivalTimeText.IsActive())
        {
            arrivalTimeText.text = string.Format("{0:D2}:{1:D2}.{2:D3}", min, sec, msec);
        }
    }

    // 거리 표기 UI 업데이트
    public void UpdateDistance(float distance, float remainingDistance)
    {
        remainingDistanceText.text = string.Format("Remaining Distance : {0:D4} m", (int) Mathf.Floor(remainingDistance));

        distanceBar.BarValue = (distance - remainingDistance) / distance * 100.0f;
    }

    // Game Over 화면 보여주기
    public void ShowGameOver()
    {
        // Game Over 되었을 때의 화면 활성화
        gameOver.SetActive(true);
    }

    // 도착 화면 보여주기
    public void ShowArrival()
    {
        // 도착 했을 때의 화면 활성화
        arrival.SetActive(true);
    }
}
