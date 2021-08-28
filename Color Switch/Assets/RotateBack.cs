using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {


        if (transform.localRotation.eulerAngles.z >= 0)
        {
            transform.Rotate(0f, 0f, -100 * Time.deltaTime);
            this.GetComponent<Rotator>().enabled = false;
        }
        else
        { this.GetComponent<Rotator>().enabled = true;
            this.enabled = false;
        }

    }
}
