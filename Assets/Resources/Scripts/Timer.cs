using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float time; // 전체 시간 (deltaTime 합)

    int min;    // 분 (minute)
    int sec;    // 초 (second)
    int msec;   // 밀리초 (millisecond)

    void Start()
    {
        // 초기화
        time = 0.0f;

        min = 0;
        sec = 0;
        msec = 0;
    }

    void Update()
    {
        // 현재 시간(게임 시작부터의 누적 시간) 업데이트
        UpdateCurrentTime();
    }

    // 현재 시간(게임 시작부터의 누적 시간) 업데이트
    private void UpdateCurrentTime()
    {
        float temp = 0.0f; // 계산 편의를 위한 임시 변수

        // 게임 시작부터의 누적 시간(단위: 초) 계산
        time += Time.deltaTime;

        temp = time % 60.0f;

        // 분, 초, 밀리초 계산
        min = (int) Mathf.Floor(time / 60.0f);

        sec = (int) Mathf.Floor(temp);

        msec = (int) Mathf.Floor((temp - sec) * 1000);

        // 타이머 UI의 글자 업데이트
        UIManager.instance.UpdateTimerText(min, sec, msec);
    }
}
