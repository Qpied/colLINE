using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

    public float Forward_force = 3f;
    public Material[] materials = new Material[3];
    public Material[] materials2 = new Material[3];
    public Renderer rend;
    AudioSource colChangeSound;
    private int index = 1;

    bool currentPlatformAndroid = false;

    private void Awake()
    {
#if UNITY_ANDROID
        currentPlatformAndroid = true;
#endif
    }

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        AudioSource[] audios = GetComponents<AudioSource>();
        colChangeSound =audios[2];
    }

      private void OnMouseDown()
      {

          transform.GetComponent<Rigidbody>().AddForce(Forward_force * transform.forward);
          if (materials.Length == 0)
          {
              return;
          }
          else if (Input.GetMouseButtonDown(0))
          {
              index += 1;
              if (index == materials.Length + 1)
              {
                  index = 1;
              }
           //   Debug.Log(index);

              rend.sharedMaterial = materials[index - 1];
          }

      } 

    void touchToChangeColor()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            float middleHeight = Screen.height / 2;
            float middleWidth = Screen.width / 2;

            if (touch.position.y < middleHeight && touch.phase == TouchPhase.Began && touch.position.x < middleWidth && Time.timeScale == 1)
            {
                if (materials.Length == 0)
                {
                    return;
                }
                else if (Input.GetMouseButtonDown(0))
                {
                    index += 1;
                    if (index == materials.Length +1)
                    {
                        index = 1;
                    }
          //          Debug.Log(index);

                    rend.sharedMaterial = materials[index - 1];
                }
                colChangeSound.Play();
            }
            else if (touch.position.y < middleHeight && touch.phase == TouchPhase.Began && touch.position.x > middleWidth && Time.timeScale == 1)
            {

                if (materials.Length == 0)
                {
                    return;
                }
                else if (Input.GetMouseButtonDown(0))
                {
                    index += 1;
                    if (index == materials2.Length + 1)
                    {
                        index = 1;
                    }
                    //          Debug.Log(index);

                    rend.sharedMaterial = materials2[index - 1];
                }
                colChangeSound.Play();
            }
        }
    }
    // Update is called once per frame
    void Update () {
		if(currentPlatformAndroid)
        {
            touchToChangeColor();
        }
        
	}
}
