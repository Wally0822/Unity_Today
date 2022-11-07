using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region Singleton

    static GameManager instance = null;
    public static GameManager Inst
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                    instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return instance;
        }
    }

    #endregion


    [SerializeField] TextMeshProUGUI PlayTime;
    [SerializeField] TextMeshProUGUI BestTime;
    [SerializeField] TextMeshProUGUI itemScore;
    [SerializeField] TextMeshProUGUI GG;

    float EscapeTime = 0;
    float bestTime = 0;

    public bool isGameOver = false;

    public int totalItem;
    int Gotcha;

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        { EscapeTime += Time.deltaTime; }

        PlayTime.text = (EscapeTime < 60) ? $"I'm alive! : {(int)EscapeTime % 60} Sec" : $"I'm alive! : {(int)EscapeTime / 60}Min : {(int)EscapeTime % 60} Sec";

        BestTime.text = (bestTime != 0) ? $"{(int)bestTime / 60} Min {(int)bestTime % 60} Sec" : "No one escaped!";

        itemScore.text = $"{Gotcha} / {totalItem}";


        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main");
        }

    }

    void Escaped()
    {
        bestTime = PlayerPrefs.GetFloat("BestTime");

        if (EscapeTime > bestTime)
        {
            bestTime = EscapeTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);

            BestTime.text = $"You are the best! : ${(int)bestTime / 60} Min {(int)bestTime % 60} Sec";
        }
    }

    void GameOver()
    {
        isGameOver = true;
        GG.gameObject.SetActive(true);

    }

    void Score()
    {
        Gotcha++;
    }


}
