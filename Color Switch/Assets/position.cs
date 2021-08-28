using UnityEngine;

public class position : MonoBehaviour
{
     
    public Camera camera;
   
    void Start()
    {
        transform.position = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 1));
        transform.position = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 1));

    }


}
