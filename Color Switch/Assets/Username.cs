using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Username : MonoBehaviour
{
    public static string UserName;
    public GameObject UsernamePage;
    public GameObject MainMenu;
    public GameObject CIRCLE;
    public GameObject CancelButton;
    
    void Start()
    {
        
        UserName=PlayerPrefs.GetString("UserName", "");
        if (Equals(UserName, ""))
        {
            
            Debug.Log("there no username");
            UsernamePage.SetActive(true);
            CIRCLE.SetActive(true);
            CancelButton.SetActive(false);



        }
        else { MainMenu.SetActive(true); }

        
        
    }
    
    

    
}
