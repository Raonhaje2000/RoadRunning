using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // ���� �����
    public void Restart()
    {
        // Main Scene �ҷ�����
        SceneManager.LoadScene("MainScene");
    }
}
