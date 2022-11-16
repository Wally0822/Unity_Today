using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEditor.Experimental.GraphView;

public class UserData
{
    public string name;
    public float bestTime;
    public int score;
}
public class UIManager : MonoBehaviour
{

    #region Singleton
    static UIManager instance = null;

    public static UIManager Inst
    {
        get
        {

            if (instance == null)
            {

                instance = FindObjectOfType<UIManager>();

                if (instance == null)
                    instance = new GameObject("UIManager").AddComponent<UIManager>();
            }
            return instance;
        }

    }
    #endregion

    [SerializeField] GameObject DBpanel = null;
    [SerializeField] ScrollRect scrollView = null;
    [SerializeField] TextMeshProUGUI RECname = null;
    [SerializeField] TextMeshProUGUI RECBestTime = null;
    [SerializeField] TextMeshProUGUI RECScore = null;
    [SerializeField] GameObject scorePanel = null;
    [SerializeField] GameObject SaveButton = null;
    [SerializeField] GameObject inputNameField = null;

    public bool isStopped = false;

    public int curMyidx = -1;

    public string ServerURL = null;
    public int Port = 0;


    public List<UserData> myUserData = null;
    bool isProcessing = false;

    public void DBpanel_OnNOff(bool onNoff)
    {
        DBpanel.SetActive(onNoff);


        // when close DBpanel, destroy all the record data 
        if (!onNoff)
        {
            for (int i = 0; i < myUserData.Count; ++i)
            {
                Destroy(scrollView.content.GetChild(i).gameObject);
            }
        }
    }

    public void scorePanel_OnNOff(int idx)
    {
        bool result;

        if (curMyidx == idx)
        {   
            // selected same user data and if it's actived, => false, deactived => true
            result = (scorePanel.activeSelf) ? false : true;
            scorePanel.SetActive(result);
        }
        else
            scorePanel.SetActive(true);
    }

    public void SaveData()
    {



    }


    public void Load_Data()
    {
        if (isProcessing) return;

        StartCoroutine(processLoad());
    }

    IEnumerator processLoad()
    {
        string targetURL = ServerURL + ":" + Port + "/getuserdata";

        using (UnityWebRequest www = UnityWebRequest.Get(targetURL))
        {

            yield return www.SendWebRequest();
            UnityEngine.Debug.Log(www.downloadHandler.text);

            myUserData = JsonConvert.DeserializeObject<List<UserData>>(www.downloadHandler.text);
            for (int i = 0; i < myUserData.Count; i++)
            {
                // assign UI instance and input data 
                UIUserData instUIObj = getLoadUserData();

                // let UIObj has parent info, its name and its index number 
                instUIObj.Data(this.gameObject, myUserData[i].name, i);
            }

            www.Dispose();
        }
        isProcessing = false;
    }

    UIUserData prefabUIData = null;

    // find UI prefab and instantiate 
    UIUserData getLoadUserData()
    {
        if (prefabUIData == null)
            prefabUIData = Resources.Load<UIUserData>("UserRecord");

        UIUserData instUIObj = Instantiate(prefabUIData, scrollView.content.transform);
        return instUIObj;
    }

    public void select_data(int idx)
    {

        scorePanel_OnNOff(idx);

        RECname.text = $"Name : {myUserData[idx].name}";
        RECBestTime.text = $"Best Time : {myUserData[idx].bestTime / 60}Min {myUserData[idx].bestTime % 60}Sec";        // 수정 필요! 
        RECScore.text = $"Score : {myUserData[idx].score.ToString()}";

        curMyidx = idx; // 현재 선택한 데이터의 인덱스
    }
}
