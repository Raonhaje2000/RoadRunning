using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculation : MonoBehaviour
{
    GameObject player;

    Transform startPoint;       // 출발 지점
    Transform endPoint;         // 도착 지점

    Transform playerPoint;      // 플레이어의 현재 위치

    float distance;             // 전체 거리
    float remainingDistance;    // 남은 거리

    void Start()
    {
        // GameObject 정보 로드
        player = GameObject.FindWithTag("Player");

        startPoint = GameObject.FindWithTag("StartPoint").transform;
        endPoint = GameObject.FindWithTag("EndPoint").transform;

        // 출발 지점과 도착 지점 사이의 전체 거리 계산
        distance = Vector3.Distance(new Vector3(0.0f, 0.0f, startPoint.position.z), new Vector3(0.0f, 0.0f, endPoint.position.z));
    }

    void Update()
    {
        // 플레이어의 현재 위치 정보 가져오기
        playerPoint = player.transform;

        // 플레이어의 현재 위치와 도착 지점 사이의 거리 계산
        remainingDistance = Vector3.Distance(new Vector3(0.0f, 0.0f, playerPoint.position.z), new Vector3(0.0f, 0.0f, endPoint.position.z));

        // 거리 관련 UI 업데이트
        UIManager.instance.UpdateDistance(distance, remainingDistance);
    }
}
