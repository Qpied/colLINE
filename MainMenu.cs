using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    
    

    private Transform cameraTransform;
    private Transform cameraDesiredLookAt;

    public float CamRotationSpeed = 3f;
    // Use this for initialization
	void Start () {
        cameraTransform = Camera.main.transform;
    }
	
	// Update is called once per frame
	void Update () {
		if(cameraDesiredLookAt != null)
        {
            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, cameraDesiredLookAt.rotation, CamRotationSpeed * Time.deltaTime);
        }
	}


    public void sethighscoremenu(Text abc)
    {
        abc.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void lookAtMenu(Transform menuTransform)
    {
        cameraDesiredLookAt = menuTransform;
    }

    public void Scene1Loader(string scenename1)
    {
        SceneManager.LoadScene(scenename1);
    }
   

}
