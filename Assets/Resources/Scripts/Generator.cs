using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    GameObject[] randomMap;
    GameObject startMap;
    GameObject endMap;

    GameObject player;

    int mapCount; // 시작과 끝을 제외한 맵의 개수

    private void Awake()
    {
        // 관련 데이터 로드 및 초기화
        mapCount = 25;

        LoadObjectResources();     // 관련 프리팹(리소스) 로드
        InstantiateMapObject();    // 맵 랜덤 생성
        InstantiatePlayerObject(); // 플레이어 생성
    }

    // 관련 프리팹(리소스) 로드
    void LoadObjectResources()
    {
        randomMap = Resources.LoadAll<GameObject>("Prefabs/CityMap/Random");
        startMap = Resources.Load<GameObject>("Prefabs/CityMap/CityMap_Start");
        endMap = Resources.Load<GameObject>("Prefabs/CityMap/CityMap_End");

        player = Resources.Load<GameObject>("Prefabs/Player/Player");
    }

    // 맵 랜덤 생성
    void InstantiateMapObject()
    {
        float positionZ = 0.0f; // 다음에 생성될 맵의 Z축 위치

        // 시작 맵 생성
        Instantiate(startMap, new Vector3(0.0f, 0.0f, positionZ), Quaternion.identity);
        positionZ += 39.5f;

        // 일정 거리마다 맵 생성
        for(int i = 0; i < mapCount; i++)
        {
            // 맵 프리팹 중에서 랜덤하게 하나 뽑아서 맵 생성
            int mapIndex = Random.Range(0, randomMap.Length);
            Instantiate(randomMap[mapIndex], new Vector3(0.0f, 0.0f, positionZ), Quaternion.identity);
            
            positionZ += 39.5f; // 39.5는 맵 하나의 z축 길이
        }
        
        // 끝 맵 생성
        Instantiate(endMap, new Vector3(0.0f, 0.0f, positionZ), Quaternion.identity);
    }

    // 플레이어 생성
    void InstantiatePlayerObject()
    {
        // 시작 맵에서 플레이어가 스폰되는 지점 정보 로드
        Transform playerSpawnPoint = GameObject.Find("StartPoint").transform;

        // 플레이어 스폰
        Instantiate(player, playerSpawnPoint.position, playerSpawnPoint.rotation);
    }
}
