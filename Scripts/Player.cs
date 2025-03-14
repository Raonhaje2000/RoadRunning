using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum State
    { 
        STOP = 0,   // ����
        RUN = 1,    // �޸���
        DAMAGE = 2, // ��ֹ��� �浹
        DEAD = 3    // ��� (ü�� 0)
    }

    State playerState;

    void Start()
    {
        // �÷��̾��� ���� �ʱ�ȭ
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
                        // �÷��̾��� ü���� 0 ������ ��� DEAD ���·� ����
                        playerState = State.DEAD;
                    }
                    else
                    {
                        // �÷��̾��� ü���� �����ִ� ��� RUN ���·� ����
                        playerState = State.RUN;
                    }

                    break;
                }
            case State.DEAD:
                {
                    // ���� ����(Game Over)
                    GameManager.instance.GameOver();

                    break;
                }
        }
    }

    // �÷��̾�� �浹�� GageObject Ȯ��
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            // ��ֹ��� �ε��� ��� �÷��̾� ü�� 5 ����
            SoundManager.instance.PlaySfx(this.transform.position, SoundManager.instance.collision, 0, SoundManager.instance.sfxVolum);
            GameManager.instance.UpdatePlayerHpBar(5.0f);

            // �÷��̾� ���¸� DAMAGE�� ����
            playerState = State.DAMAGE;
        }
        else if(other.tag == "People")
        {
            // ����� �ε��� ��� �÷��̾� ü�� 10 ����
            SoundManager.instance.PlaySfx(this.transform.position, SoundManager.instance.collision, 0, SoundManager.instance.sfxVolum);
            GameManager.instance.UpdatePlayerHpBar(10.0f);

            // �÷��̾��� ���¸� DAMAGE�� ����
            playerState = State.DAMAGE;
        }
        else if(other.tag == "Portal")
        {
            // ��Ż�� �ε��� ��� ��Ż ���� ��� ó��
            GameManager.instance.ArrivePortal();
        }
    }
}
