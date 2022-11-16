using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIUserData : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtName = null;

    // to remember my parent who call me, and my index number to find myself 
    GameObject myParent = null;
    int idx = -1;

    public void Data(GameObject parent, string name, int index)
    {
        txtName.text = name;
        myParent = parent;
        idx = index;
    }

    // if clicked me, send my index to my parent 
    public void OnClick_me()
    {
        UIManager.Inst.select_data(idx);
    }



}
