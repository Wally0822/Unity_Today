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
    public double bestRecord;
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

    public void SaveData(float EscapeTime, int Gotcha)
    {
        if (isProcessing) return;

        UserData newData = new UserData();
        newData.name = inputNameField.ToString();
        newData.bestRecord = EscapeTime;
        newData.score = Gotcha;

        // convert json type data to string 
        string jsonData = JsonUtility.ToJson(newData);
        isProcessing = true;
        StartCoroutine(processSave(jsonData));
    }

    IEnumerator processSave(string jsonData)
    {

        string targetURL = ServerURL + ":" + Port + "/saveuserdata";

        using (UnityWebRequest request = UnityWebRequest.Post(targetURL, jsonData))
        {
            // divide string data to byte 
            byte[] jsonTosend = new System.Text.UTF8Encoding().GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(jsonTosend);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                UnityEngine.Debug.Log(request.error);
            }

            else
            {
                UnityEngine.Debug.Log(request.downloadHandler.text);
            }
        }

        isProcessing = false;
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

        int time = int.Parse(myUserData[idx].bestRecord.ToString());

        Debug.Log($"{myUserData[idx].bestRecord.ToString()} 나의 시간!");

        RECname.text = $"Name : {myUserData[idx].name}";
        RECBestTime.text = $"Best Time : {time / 60}Min {time % 60}Sec";        // 수정 필요! 
        RECScore.text = $"Score : {myUserData[idx].score.ToString()}";

        curMyidx = idx; // 현재 선택한 데이터의 인덱스
    }
}
