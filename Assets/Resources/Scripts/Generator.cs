using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    GameObject[] randomMap;
    GameObject startMap;
    GameObject endMap;

    GameObject player;

    int mapCount; // ���۰� ���� ������ ���� ����

    private void Awake()
    {
        // ���� ������ �ε� �� �ʱ�ȭ
        mapCount = 25;

        LoadObjectResources();     // ���� ������(���ҽ�) �ε�
        InstantiateMapObject();    // �� ���� ����
        InstantiatePlayerObject(); // �÷��̾� ����
    }

    // ���� ������(���ҽ�) �ε�
    void LoadObjectResources()
    {
        randomMap = Resources.LoadAll<GameObject>("Prefabs/CityMap/Random");
        startMap = Resources.Load<GameObject>("Prefabs/CityMap/CityMap_Start");
        endMap = Resources.Load<GameObject>("Prefabs/CityMap/CityMap_End");

        player = Resources.Load<GameObject>("Prefabs/Player/Player");
    }

    // �� ���� ����
    void InstantiateMapObject()
    {
        float positionZ = 0.0f; // ������ ������ ���� Z�� ��ġ

        // ���� �� ����
        Instantiate(startMap, new Vector3(0.0f, 0.0f, positionZ), Quaternion.identity);

        // ���� �Ÿ����� �� ����
        for(int i = 0; i < mapCount; i++)
        {
            positionZ += 39.5f; // 39.5�� �� �ϳ��� z�� ����

            // �� ������ �߿��� �����ϰ� �ϳ� �̾Ƽ� �� ����
            int mapIndex = Random.Range(0, randomMap.Length);
            Instantiate(randomMap[mapIndex], new Vector3(0.0f, 0.0f, positionZ), Quaternion.identity);
        }

        positionZ += 39.5f;

        // �� �� ����
        Instantiate(endMap, new Vector3(0.0f, 0.0f, positionZ), Quaternion.identity);
    }

    // �÷��̾� ����
    void InstantiatePlayerObject()
    {
        // ���� �ʿ��� �÷��̾ �����Ǵ� ���� ���� �ε�
        Transform playerSpawnPoint = GameObject.Find("StartPoint").transform;

        // �÷��̾� ����
        Instantiate(player, playerSpawnPoint.position, playerSpawnPoint.rotation);
    }
}
