using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float playerMaxHp;       // �÷��̾��� �ִ� ü��
    public float playerCurrentHp;   // �÷��̾��� ���� ü��

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
        // �÷��̾��� HP UI �ʱ�ȭ
        SetPlayerHpBar();

        // ������� ���
        PlayBgm();
    }

    // ������� ���
    public void PlayBgm()
    {
        // ������� GameObject ����
        SoundManager.instance.PlayBGM(SoundManager.instance.mainBgm, 0, true);
    }

    // ������� ����
    public void StopBgm()
    {
        // ������� GameObject�� ã�Ƽ� ����
        GameObject bgm = GameObject.Find("BGM");

        Destroy(bgm);
    }

    // �÷��̾��� HP UI �ʱ�ȭ
    public void SetPlayerHpBar()
    {
        // �÷��̾��� �ִ� ü�°� ���� ü���� 100���� �ʱ�ȭ
        playerMaxHp = 100.0f;
        playerCurrentHp = playerMaxHp;

        // �÷��̾��� HP UI ������Ʈ
        UIManager.instance.UpdatePlayerHpBarUI();
    }

    // �÷��̾��� HP UI ������Ʈ
    public void UpdatePlayerHpBar(float damage)
    {
        // ���� ��������ŭ �÷��̾��� ���� ü�� ����
        playerCurrentHp -= damage;

        // �÷��̾��� HP UI ������Ʈ
        UIManager.instance.UpdatePlayerHpBarUI();
    }

    // ��Ż ���� ��� ó��
    public void ArrivePortal()
    {
        // ���� ȭ�� �����ֱ�
        UIManager.instance.ShowArrival();

        // ���� ���� ����
        Time.timeScale = 0.0f;

        // URL �̵�
    }

    // ���� ����(Game Over)
    public void GameOver()
    {
        // Game Over ȭ�� �����ֱ�
        UIManager.instance.ShowGameOver();

        // ������� ����
        StopBgm();

        // ���� ���� ����
        Time.timeScale = 0.0f;
    }
}
