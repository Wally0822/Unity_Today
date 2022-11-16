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
    [SerializeField] TextMeshProUGUI win;

    float EscapeTime = 0f;
    float bestTime = 1000f;

    public bool isGameOver = false;
    public bool isPaused = false;


    public int totalItem;
    public int Gotcha;

    Cube Cube;

    private void Awake()
    {
        Cube = FindObjectOfType<Cube>();
    }


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
            SceneManager.LoadScene("Test_ChrisP");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!isPaused)
            {
                Debug.Log("escape!!!");

                // turn onf DBPanel 
                UIManager.Inst.DBpanel_OnNOff(true);

                // and request UIManager to load user data
                UIManager.Inst.Load_Data();

                Time.timeScale = 0;

                isPaused = true;
            }

            else
            {
                // turn onf DBPanel 
                UIManager.Inst.DBpanel_OnNOff(false);

                Time.timeScale = 1f;

                isPaused = false;
            }

        }

    }

    void Escaped()
    {
        isGameOver = true;

        bestTime = PlayerPrefs.GetFloat("BestTime");

        if (EscapeTime < bestTime)
        {
            bestTime = EscapeTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);

            Debug.Log("you win!");

        }
        win.gameObject.SetActive(true);

        Invoke("SaveData", 3f);

    }

    void GameOver()
    {
        isGameOver = true;
        GG.gameObject.SetActive(true);
    }

    void Score()
    {
        Gotcha++;

        if (Gotcha >= 10)
        {
            Cube.SendMessage("End", SendMessageOptions.DontRequireReceiver);

            Escaped();
        }

    }

    void SaveData()
    {
        UIManager.Inst.SaveData();
    }

}
