using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIUserData : Selectable
{
    [SerializeField] TextMeshProUGUI txtName = null;

    int idx = -1;

    bool iamSelected = false;
    bool iampressed = false;

    public void Data(GameObject parent, string name, int index)
    {
        txtName.text = name;
        idx = index;
    }

    // if clicked me, send my index to my parent 
    public void OnClick_me()
    {
        // show selected data 
        UIManager.Inst.select_data(idx);

        // player audio
        AudioManager.Inst.UISound_Pressed();
    }

    void Update()
    {
        if (IsHighlighted())
        {
            if (iamSelected) return;

            AudioManager.Inst.UISound_HighLighted();
            iamSelected = true;
        }

        else
            iamSelected = false;
    }



}
