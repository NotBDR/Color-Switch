using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayName : MonoBehaviour
{
    public TMP_Text EnterName;
    void Start()
    {

        if (Equals(PlayerPrefs.GetString("UserName"), ""))
        {
            EnterName.text = "ENTER NICKNAME...";
        }
        else EnterName.text = PlayerPrefs.GetString("UserName");
    }

    // Update is called once per frame
    
}
