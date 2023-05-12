using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculation : MonoBehaviour
{
    GameObject player;

    Transform startPoint;       // ��� ����
    Transform endPoint;         // ���� ����

    Transform playerPoint;      // �÷��̾��� ���� ��ġ

    float distance;             // ��ü �Ÿ�
    float remainingDistance;    // ���� �Ÿ�

    void Start()
    {
        // GameObject ���� �ε�
        player = GameObject.FindWithTag("Player");

        startPoint = GameObject.FindWithTag("StartPoint").transform;
        endPoint = GameObject.FindWithTag("EndPoint").transform;

        // ��� ������ ���� ���� ������ ��ü �Ÿ� ���
        distance = Vector3.Distance(new Vector3(0.0f, 0.0f, startPoint.position.z), new Vector3(0.0f, 0.0f, endPoint.position.z));
    }

    void Update()
    {
        // �÷��̾��� ���� ��ġ ���� ��������
        playerPoint = player.transform;

        // �÷��̾��� ���� ��ġ�� ���� ���� ������ �Ÿ� ���
        remainingDistance = Vector3.Distance(new Vector3(0.0f, 0.0f, playerPoint.position.z), new Vector3(0.0f, 0.0f, endPoint.position.z));

        // �Ÿ� ���� UI ������Ʈ
        UIManager.instance.UpdateDistance(distance, remainingDistance);
    }
}
