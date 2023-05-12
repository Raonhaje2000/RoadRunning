using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // 게임 재시작
    public void Restart()
    {
        // Main Scene 불러오기
        SceneManager.LoadScene("MainScene");
    }
}
