using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float time; // ��ü �ð� (deltaTime ��)

    int min;    // �� (minute)
    int sec;    // �� (second)
    int msec;   // �и��� (millisecond)

    void Start()
    {
        // �ʱ�ȭ
        time = 0.0f;

        min = 0;
        sec = 0;
        msec = 0;
    }

    void Update()
    {
        // ���� �ð�(���� ���ۺ����� ���� �ð�) ������Ʈ
        UpdateCurrentTime();
    }

    // ���� �ð�(���� ���ۺ����� ���� �ð�) ������Ʈ
    private void UpdateCurrentTime()
    {
        float temp = 0.0f; // ��� ���Ǹ� ���� �ӽ� ����

        // ���� ���ۺ����� ���� �ð�(����: ��) ���
        time += Time.deltaTime;

        temp = time % 60.0f;

        // ��, ��, �и��� ���
        min = (int) Mathf.Floor(time / 60.0f);

        sec = (int) Mathf.Floor(temp);

        msec = (int) Mathf.Floor((temp - sec) * 1000);

        // Ÿ�̸� UI�� ���� ������Ʈ
        UIManager.instance.UpdateTimerText(min, sec, msec);
    }
}
