using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameoverText;
    [SerializeField] private Text TimeText;
    [SerializeField] private Text RecordText;

    private float time;
    private bool isGameover;

    private void Start()
    {
        time = 0;
        isGameover = false;
    }

    private void Update()
    {
        if (!isGameover)
        {
            //시간 흘러감 UI 업데이트
            time += Time.deltaTime;
            TimeText.text = $"Time : {(int)time}";
        }
        else
        {
            //재시작
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }


    public void EndGame()
    {
        isGameover = true;
        GameoverText.SetActive(true);
        Debug.Log("여기들오옴");
        float BestTime = PlayerPrefs.GetFloat("BestTime");

        if(time >BestTime)
        {
            BestTime = time;
            PlayerPrefs.SetFloat("BestTime", BestTime);
        }

        RecordText.text = $"최고기록 : {(int)BestTime}";
    }

}
