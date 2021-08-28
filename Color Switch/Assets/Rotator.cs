
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public static float speed = 60;
    public int Score;
    public static bool CircleBack=false;
    public Animation Animation;
    public static float ogspeed;
    

    private void Start()
    {
        speed = 60;
        ogspeed = speed;
    }
    void Update()
    {
        if (Player.lostbool == false)
        {
            Score = Player.ScoreInt;
            speed = ogspeed + Score * 2;
        }
        else { Score = 0; }

        if (speed < 210) { transform.Rotate(0f, 0f, speed * Time.deltaTime); }
        else { transform.Rotate(0f, 0f, 210 * Time.deltaTime); }

        if (CircleBack == true & this.tag=="SmallCircle") { CircleReset(); }
    }

    public void CircleReset()
    {
        Animation.Play();
        speed = ogspeed;
        CircleBack = false;
    }
 
}
