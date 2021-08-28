using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    public  GameObject UpCoin;
    public GameObject DownCoin;

  
    public float JumpForce=10f;
    public float lilJump = 6f;
    public Rigidbody2D rg;
    public string CurrentColor;
    public SpriteRenderer sr;
    public AudioSource JumpAuido;
    public Color Cyan;
    public Color Yallow;
    public Color Magenta;
    public Color Pink;
    //score
    public static int ScoreInt=0;
    public Text Score;
    public Text LocalHighScoreText;
    public static string UserName;
    public GameObject Lost;
    public static bool lostbool;
    string OldColor;
    public AudioSource ScoreAuido;
    public Animator jump;
    float upcolor = 0;
    float downcolor = 0;
    public static bool UpScore=true;
    public Vector2 TopRight;
    public Vector2 BottomLeft;
    HighScores highScores;
    Vector3 ogpos;
    public GameObject LocalScoreHide;
    private int OldScore;
    

    public void setUsername(TMP_Text username) {
        UserName = username.text;
        PlayerPrefs.SetString("UserName", UserName);
        PlayerPrefs.SetInt("HighScore", 0);
        LocalHighScoreText.text = PlayerPrefs.GetString("UserName") + ", YOUR HIGHEST SCORE IS:" + 0;

    }
    
    private void Start()
    {
        
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        LocalHighScoreText.text= PlayerPrefs.GetString("UserName")+", YOUR HIGHEST SCORE IS:"+PlayerPrefs.GetInt("HighScore", 0).ToString();
        SetRandomColor();
        Score.text = ""+ScoreInt;
        //stop player motion //circle motion 
        BottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        TopRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        lostbool = false;
        ogpos = transform.position;
        UserName=PlayerPrefs.GetString("UserName", UserName);
        UpCoin.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
        DownCoin.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);

    }
  


    private void SetRandomColor()
    {
        OldColor = CurrentColor;
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:CurrentColor = "Cyan"   ; sr.color = Cyan;     break;
            case 1:CurrentColor = "Pink"   ; sr.color = Pink;     break;
            case 2:CurrentColor = "Yallow" ; sr.color = Yallow;   break;
            case 3:CurrentColor = "Magenta"; sr.color = Magenta;  break;

               
        }
        if (OldColor == CurrentColor) {  SetRandomColor(); }
    }

    void Update()
    {
        if (LocalHighScoreText.text == ", YOUR HIGHEST SCORE IS:0") {
            LocalHighScoreText.text = PlayerPrefs.GetString("UserName") + ", YOUR HIGHEST SCORE IS:" + ScoreInt; }


        if (UpScore == true)
        {
            if (UpCoin.GetComponent<Renderer>().material.color.a < 1)
            {
                upcolor += 0.05f;
                UpCoin.GetComponent<Renderer>().material.color = new Color(1, 1, 1, upcolor);
            }

        }
        if (UpScore == false & UpCoin.GetComponent<Renderer>().material.color.a > 0) {
            upcolor -= 0.05f;
            UpCoin.GetComponent<Renderer>().material.color = new Color(1, 1, 1, upcolor);

        }

        if (UpScore == false)
        {
            if (DownCoin.GetComponent<Renderer>().material.color.a < 1)
            {
                downcolor += 0.05f;
                DownCoin.GetComponent<Renderer>().material.color = new Color(1, 1, 1, downcolor);
            }

        }

        if (UpScore == true & DownCoin.GetComponent<Renderer>().material.color.a > 0)
        {
            downcolor -= 0.05f;
            DownCoin.GetComponent<Renderer>().material.color = new Color(1, 1, 1, downcolor);

        }
        if (Input.GetButtonDown("ChangeColor") || Input.GetMouseButtonDown(1) & lostbool == false){
            SetRandomColor(); 
        }

        if (transform.position.y < TopRight.y + transform.localScale.y / 2 )
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 3.5f;
            if (ScoreInt > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", ScoreInt);
                LocalHighScoreText.text = PlayerPrefs.GetString("UserName") + ", YOUR HIGHEST SCORE IS:" + ScoreInt;
            }
            Score.text = "" + ScoreInt + "";
            if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0) & lostbool == false)
            {
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None & RigidbodyConstraints2D.FreezePositionX;
                this.GetComponent<TrailRenderer>().emitting = true;
                this.GetComponent<TrailRenderer>().time = 0.2f;
                Time.timeScale = 1;
                rg.velocity = Vector2.up * JumpForce;
                JumpAuido.Play();
                jump.Play("jump");
            }
        }
        
        if (transform.position.y < BottomLeft.y )
        { Debug.Log("outScreen down ");
            transform.position = new Vector3((TopRight.x + BottomLeft.x)/2 , BottomLeft.y + transform.localScale.y, 1);
        }

        /////////
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != CurrentColor && collision.tag != "ColorChangerUp" && collision.tag != "ColorChangerDown" && collision.tag != "ColorChangerMeddle") 
        {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            Rotator.speed = 0;
            //stop rotate stop player 
            Lost.SetActive(true);
            LocalScoreHide.SetActive(false);
            Debug.Log(ScoreInt);
            Debug.Log(UserName);
            HighScores.AddNewHighScore(UserName, PlayerPrefs.GetInt("HighScore", ScoreInt));
            lostbool = true;
        }

       
        if (collision.tag == "ColorChangerUp" && UpScore == true && lostbool!=true) 
        {
         ScoreAuido.Play();
         ScoreInt++;
         Debug.Log("UP");
         UpScore = false;
         SetRandomColor();
            UpCoin.GetComponent<ParticleSystem>().Play();
        }

        if (collision.tag == "ColorChangerDown" && UpScore == false && lostbool!= true) 
        {
         ScoreAuido.Play();
         ScoreInt++;
         Debug.Log("Down");
         UpScore = true;
         SetRandomColor();
         DownCoin.GetComponent<ParticleSystem>().Play();
        }


        if (collision.tag == "ColorChangerMeddle" & ScoreInt != OldScore )
        {
            OldScore = ScoreInt;
            Debug.Log("Middle");
            SetRandomColor();
        }


    }
    public void Reset()
    {
        Debug.Log("restart methode called");
        Rotator.CircleBack = true;
        transform.position = ogpos;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        this.GetComponent<TrailRenderer>().emitting= false;
        this.GetComponent<TrailRenderer>().time = 0f;
        transform.position = ogpos;
        ScoreInt = 0;
        lostbool = false;
        LocalScoreHide.SetActive(true);
        UpScore = true;
        
        
    }
}
