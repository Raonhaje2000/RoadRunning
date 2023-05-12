using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public ProgressBar playerHpBar;     // �÷��̾��� HP UI

    public GameObject gameOver;         // Game Over �Ǿ��� ���� ȭ��
    public GameObject arrival;          // ���� ���� ���� ȭ��

    public Text timerText;              // Ÿ�̸� ����

    public Text remainingDistanceText;  // ���� �Ÿ� ����
    public ProgressBar distanceBar;     // �Ÿ� ǥ�� UI

    public Text arrivalTimeText;        // ������ �ð� ����

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // ȭ�� ��Ȱ��ȭ
        gameOver.SetActive(false);
        arrival.SetActive(false);
    }

    // �÷��̾��� HP UI ������Ʈ
    public void UpdatePlayerHpBarUI()
    {
        playerHpBar.BarValue = GameManager.instance.playerCurrentHp / GameManager.instance.playerMaxHp * 100.0f;
    }

    // Ÿ�̸� UI�� ���� ������Ʈ
    public void UpdateTimerText(int min, int sec, int msec)
    {
        timerText.text = string.Format("{0:D2}:{1:D2}.{2:D3}", min, sec, msec);

        if (arrivalTimeText.IsActive())
        {
            arrivalTimeText.text = string.Format("{0:D2}:{1:D2}.{2:D3}", min, sec, msec);
        }
    }

    // �Ÿ� ǥ�� UI ������Ʈ
    public void UpdateDistance(float distance, float remainingDistance)
    {
        remainingDistanceText.text = string.Format("Remaining Distance : {0:D4} m", (int) Mathf.Floor(remainingDistance));

        distanceBar.BarValue = (distance - remainingDistance) / distance * 100.0f;
    }

    // Game Over ȭ�� �����ֱ�
    public void ShowGameOver()
    {
        // Game Over �Ǿ��� ���� ȭ�� Ȱ��ȭ
        gameOver.SetActive(true);
    }

    // ���� ȭ�� �����ֱ�
    public void ShowArrival()
    {
        // ���� ���� ���� ȭ�� Ȱ��ȭ
        arrival.SetActive(true);
    }
}
