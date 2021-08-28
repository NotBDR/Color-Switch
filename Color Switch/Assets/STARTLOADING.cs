using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STARTLOADING : MonoBehaviour
{
    public GameObject[] CIRCLEPARTS;
    public float trans = 0f;

    private void Start()
    {
        trans = 0f;
        CIRCLEPARTS[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        CIRCLEPARTS[1].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        CIRCLEPARTS[2].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        CIRCLEPARTS[3].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }
    void Update()
    {
        if (trans < 1) {
            trans += 0.003f;
            CIRCLEPARTS[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, trans);
            CIRCLEPARTS[1].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, trans);
            CIRCLEPARTS[2].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, trans);
            CIRCLEPARTS[3].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, trans);
        }
    }
    
   
}
