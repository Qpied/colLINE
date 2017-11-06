using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using admob;

public class GamePlotScript : MonoBehaviour
{

  //  private DataController DataController;
    AudioSource correctColl;
    AudioSource wrongColl;
    
    public GameObject canvasobject;
    public GameObject ScoreCounterText;
  //  public GameObject HighScoreCounter;

    public static int scoreCount = 0;
    public Text ScoreCounter;
 //   public Text highScore;
    public GameObject CanvasforScoreandHighScore;
    public Text ScoreCounterf;
    public Text highScoref;

    public int chancesLeft;
    public Material[] m;

    
    // Use this for initialization
    void Start()
    {
     
        AudioSource[] audios = GetComponents<AudioSource>();
        correctColl = audios[0];
        wrongColl = audios[1];
      
        canvasobject.SetActive(false);
        CanvasforScoreandHighScore.SetActive(false);
        chancesLeft = 3;

        highScoref.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        ScoreCounter.text = scoreCount.ToString();
        ScoreCounterf.text = scoreCount.ToString();
     



    }
  /*  private void OnCollisionExit(Collision collision)
    {
        string ballColor = transform.GetComponent<Renderer>().material.name;
        string lineColor = collision.transform.GetComponent<Renderer>().material.name;

        if ((lineColor == "blue_dark" || lineColor == "blue_dark (Instance)") && (ballColor == "red" || ballColor == "red (Instance)"))
        {
          //  correctColl.Play();
        //    Debug.Log("red killed blue");
         //   scoreCount += 0.5f;
        }
        else if ((lineColor == "orange" || lineColor == "orange (Instance)") && (ballColor == "blue_dark" || ballColor == "blue_dark (Instance)"))
        {
         //   correctColl.Play();
        //    Debug.Log("blue_dark killed orange");
          //  scoreCount += 0.5f;
        }
        else if ((lineColor == "purple_light" || lineColor == "purple_light (Instance)") && (ballColor == "green_dark" || ballColor == "green_dark (Instance)"))
        {
          //  correctColl.Play();
        //    Debug.Log("green_dark killed purple_light");
          //  scoreCount += 0.5f;
        }
        else if ((lineColor == "pink_red" || lineColor == "pink_red (Instance)") && (ballColor == "purple_light" || ballColor == "purple_light (Instance)"))
        {
           // correctColl.Play();
        //    Debug.Log("purple_light killed pink_red");
         //   scoreCount += 0.5f;
        }
        else if ((lineColor == "green_dark" || lineColor == "green_dark (Instance)") && (ballColor == "pink_red" || ballColor == "pink_red (Instance)"))
        {
           // correctColl.Play();
       //     Debug.Log("green_dark killed by pink_red");
          //  scoreCount += 0.5f;
        }
        else if ((lineColor == "red" || lineColor == "red (Instance)") && (ballColor == "orange" || ballColor == "orange (Instance)"))
        {
          //  correctColl.Play();
         //   Debug.Log("orange killed red");
          //  scoreCount += 0.5f;
        }
        else
        {
           Debug.Log("Chances left:" + chancesLeft);
            
            wrongColl.Play();
            scoreCount = scoreDeductor();
            if(chancesLeft == 1)
            {
                Admob.Instance().loadInterstitial();
            }
            if (chancesLeft == 0 || scoreCount < 0)
            {
               StartCoroutine(WaitBeforeSettingInactive());
              if(scoreCount > PlayerPrefs.GetInt("HighScore",0))
                {
                    PlayerPrefs.SetInt("HighScore", scoreCount);
                  //  highScore.text = scoreCount.ToString();
                    highScoref.text = "HIGHSCORE: " + scoreCount.ToString();
                }
              else
                {
                    highScoref.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
                }
                AdManager.Instance.ShowVideo();
                ScoreCounterText.SetActive(false);
                canvasobject.SetActive(true);
                CanvasforScoreandHighScore.SetActive(true);
                
            }
        } 

    }  */
    public int ReturnScoreCount()
    {
        return scoreCount;
    }
    
    IEnumerator WaitBeforeSettingInactive()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
    private int scoreDeductor()
    {
        if(scoreCount>=5)
        {
            scoreCount -= (int)0.34f * scoreCount;
            
        }
        return scoreCount;
    }
    private void OnTriggerEnter(Collider other)
    {
        string ballColor = transform.GetComponent<Renderer>().material.name;
        string ColliderParentColor = other.transform.GetComponentInParent<Renderer>().material.name;
        if ((ColliderParentColor == "blue_dark" || ColliderParentColor == "blue_dark (Instance)") && (ballColor == "red" || ballColor == "red (Instance)"))
        {
            scoreCount += 1; 
            correctColl.Play();
        }
        else if ((ColliderParentColor == "orange" || ColliderParentColor == "orange (Instance)") && (ballColor == "blue_dark" || ballColor == "blue_dark (Instance)"))
        {
            scoreCount += 1;
            correctColl.Play();
        }
        else if ((ColliderParentColor == "purple_light" || ColliderParentColor == "purple_light (Instance)") && (ballColor == "green_dark" || ballColor == "green_dark (Instance)"))
        {
            scoreCount += 1;
            correctColl.Play();
        }
        else if ((ColliderParentColor == "pink_red" || ColliderParentColor == "pink_red (Instance)") && (ballColor == "purple_light" || ballColor == "purple_light (Instance)"))
        {
            scoreCount += 1;
            correctColl.Play();
        }
        else if ((ColliderParentColor == "green_dark" || ColliderParentColor == "green_dark (Instance)") && (ballColor == "pink_red" || ballColor == "pink_red (Instance)"))
        {
            scoreCount += 1;
            correctColl.Play();
        }
        else if ((ColliderParentColor == "red" || ColliderParentColor == "red (Instance)") && (ballColor == "orange" || ballColor == "orange (Instance)"))
        {
            scoreCount += 1;
            correctColl.Play();
        }
        else
        {
            chancesLeft--;
            Debug.Log("Chances left:" + chancesLeft);

            wrongColl.Play();
            scoreCount = scoreDeductor();
            if (chancesLeft == 1)
            {
                Admob.Instance().loadInterstitial();
            }
            if (chancesLeft == 0 || scoreCount < 0)
            {
                StartCoroutine(WaitBeforeSettingInactive());
                if (scoreCount > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", scoreCount);
                    //  highScore.text = scoreCount.ToString();
                    highScoref.text = "HIGHSCORE: " + scoreCount.ToString();
                }
                else
                {
                    highScoref.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
                }
                AdManager.Instance.ShowVideo();
                ScoreCounterText.SetActive(false);
                canvasobject.SetActive(true);
                CanvasforScoreandHighScore.SetActive(true);

            }

        }
        Debug.Log(other.transform.GetComponent<Renderer>().material.name); 
        Destroy(other.gameObject);
    }
    
}

    

      

