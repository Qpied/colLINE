using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuLoaDER : MonoBehaviour {
    private GamePlotScript GamePlotScript;

  //  int previousHighSore = PlayerPrefs.GetInt("HighScore", 0);
    public void loadMainMenu(string MainMenuscenename)
    {
        SceneManager.LoadScene(MainMenuscenename);
    }
    public void playsound(GameObject go)
    {
        AudioSource audio = go.transform.GetComponent<AudioSource>(); ;
        audio.Play();
        
    }
   
    
    public void showADD()
    {
        AdManager.Instance.ShowBanner();
    }
    public void showIntADD()
    {
        AdManager.Instance.ShowVideo();
    }
    public void setscorecountzero(Text text)
    {
          GamePlotScript.scoreCount = 0;
        text.text = GamePlotScript.scoreCount.ToString();

    }
     

}
