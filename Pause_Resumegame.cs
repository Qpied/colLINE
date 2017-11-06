using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;
public class Pause_Resumegame : MonoBehaviour {

    public GameObject PlayButton;
    private GamePlotScript GamePlotScript;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        PlayButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        GamePlotScript = new GamePlotScript();
    }

    public void pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            Debug.Log("time scale 0");
        }
        
            PlayButton.SetActive(true);
        
            
    }
    public void play()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            Debug.Log("time scale 1");
        }
        PlayButton.SetActive(false);
    }
    public void showbannerad()
    {
        AdManager.Instance.ShowBanner();
    }
    public void showintad()
    {
        AdManager.Instance.ShowVideo();
    }
    public void notshowad()
    {
        Admob.Instance().removeAllBanner();
    }
}
