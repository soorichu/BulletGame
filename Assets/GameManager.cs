using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;  //게임 오버 시 활성화 텍스트
    public Text timeText;            //생존 시간 표시
    public Text recordText;          //최고 기록 표시

    private float surviveTime;       //생존 시간
    private bool isGameover;         //게임 오버 상태

    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;
        }
        else 
        {
            if (Input.GetKey(KeyCode.R)) {
                SceneManager.LoadScene("Cartoon Cat");
            }
        }
    }

    public void EndGame() {
        isGameover = true;
        gameoverText.SetActive(true);
        float bestTime = PlayerPrefs.GetFloat("BestTime");
        if (surviveTime > bestTime) {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + (int)bestTime;
    }
}
