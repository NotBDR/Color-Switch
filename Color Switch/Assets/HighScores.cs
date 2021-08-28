using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour
{


    const string privteCode = "Woy1nm-dXUKkuN4JBHwLwws--wH5Z3eUiYa4VAxFxY3A";
    const string publicCode = "5efa9e86377eda0b6c90aee6";
    const string webURL = "http://dreamlo.com/lb/";
    public static Highscore[] highscoresList;
    public DisplayHighScores highscoresdisplay;
    public static HighScores instance;
    Player palyer;


    private void Awake()
    {
        instance = this;
    }
   
    public static void AddNewHighScore(string username, int score) {
       instance.StartCoroutine(instance.UploadNewHighScore(username, score));
    }
    public static void StaticDeleteHighScore(string username)
    {
        instance.StartCoroutine(instance.DeleteHighScore(username));
    }

    public void DownloadHighscores() {
        StartCoroutine("DownloadHighScoreFromDatabase");
    }

    IEnumerator UploadNewHighScore(string username, int score)
    {
        WWW www = new WWW(webURL + privteCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error)) { 
            Debug.Log("upload succefuly");
            DownloadHighscores();
        }
        else { Debug.Log("failed to upload score"); }
    }
    IEnumerator DeleteHighScore(string username)
    {
        WWW www = new WWW(webURL + privteCode + "/delete/" + WWW.EscapeURL(username) );
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("upload succefuly");
            DownloadHighscores();
        }
        else { Debug.Log("failed to upload score"); }
    }

    IEnumerator DownloadHighScoreFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error)) {
            formatHighScore(www.text);
            highscoresdisplay.OnHighScoresDownloaded(highscoresList);
        }

        else { Debug.Log("error"); }
    }

    private void formatHighScore(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
            print(highscoresList[i].username + ": " + highscoresList[i].score);
        }
    }

    

}
public struct Highscore{
        public string username;
        public int score;
    public Highscore(string _username, int _score) {
        username = _username;
        score = _score;
        }

    }
