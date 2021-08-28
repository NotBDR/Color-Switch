using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOptions : MonoBehaviour
{
    public Camera camera;
    void Start()
    {
        transform.position = camera.ScreenToWorldPoint(new Vector3(0, Screen.height, 1));
        transform.position = camera.ScreenToWorldPoint(new Vector3(0, Screen.height, 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
