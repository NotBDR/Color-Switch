using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScores : MonoBehaviour
{
    public Text[] highscoretext;
    HighScores HighscoreManger;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<highscoretext.Length; i++)
        {
            highscoretext[i].text = i + 1 + ". Fetching...";
        }
        HighscoreManger = GetComponent<HighScores>();
        StartCoroutine("RefreshHighScore");
    }
    public void OnHighScoresDownloaded(Highscore[] highscorelist)
    {
        for (int i = 0; i < highscoretext.Length; i++)
        {
            highscoretext[i].text = i + 1 + ". ";
            if (highscorelist.Length > i)
            {
                highscoretext[i].text += highscorelist[i].username +" - "+ highscorelist[i].score;
            }
        }
        
    }

    IEnumerator RefreshHighScore()
    {
        while (true) {
            HighscoreManger.DownloadHighscores();
            yield return new WaitForSeconds(10);
        }
    }
   
}
