using UnityEngine.UI;
using UnityEngine;

public class GETScore : MonoBehaviour
{
    public Text Score;
    public Text YouGot;
    public int thisGameHighScore;
    GETScore getscore;
    // Update is called once per frame

    private void Start()
    {
        thisGameHighScore=PlayerPrefs.GetInt("HighScore", 0);
    }
    public void Update() {

                if (Player.ScoreInt > thisGameHighScore)
                {
                    YouGot.text = "New HighScore: " + Score.text;
                }
                else
                { YouGot.text = "YOU GOT: " + Score.text; }
            }
        }
    
