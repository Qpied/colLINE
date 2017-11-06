

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;



public class AdManager : MonoBehaviour {

	public static AdManager Instance { set; get; }

    public string bannerId = "ca-app-pub-6773459218045109/5938680134";
    public string videoId = "ca-app-pub-6773459218045109/7797243632";
    // Use this for initialization
	void Start () {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        //   Admob.Instance().setTesting(true);
        
#if UNITY_EDITOR
#elif UNITY_ANDROID
        Admob.Instance().initAdmob(bannerId, videoId);
        
        
#endif

    }
    public void ShowBanner()
    {
#if UNITY_EDITOR
#elif UNITY_ANDROID
        Admob.Instance().showBannerRelative(AdSize.Banner,AdPosition.BOTTOM_CENTER,0);
#endif
    }
    public void notshowbanner()
    {
        Admob.Instance().removeAllBanner();
    }
    public void ShowVideo()
    {
#if UNITY_EDITOR
#elif UNITY_ANDROID
        
        if (Admob.Instance().isInterstitialReady())
        {
            Admob.Instance().showInterstitial();
        }
#endif
    }


    // Update is called once per frame
    void Update () {
        Admob.Instance().loadInterstitial();
    }
}
