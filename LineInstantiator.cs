using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineInstantiator : MonoBehaviour
{
    private GamePlotScript GamePlotScript;

    public float delaySeconds = 3f;
    public GameObject[] line = new GameObject[6];
    
    Vector3 gnrsnPoint;

    // Use this for initialization
    void Start()
    {
       
        GamePlotScript = new GamePlotScript();
        int i = Random.Range(0, 6);
        Instantiate(line[i], transform.localPosition, transform.rotation);
    }

    //Update is called once per frame
    void Update()
    {
        
        StartCoroutine(ExecuteAfterTime(delaySeconds));

        if(GamePlotScript.ReturnScoreCount() > 15 && GamePlotScript.ReturnScoreCount() <=30)
        {
            delaySeconds = 2.7f;
            LineMover.speed = -5.2f;
        }
        if (GamePlotScript.ReturnScoreCount() > 30 && GamePlotScript.ReturnScoreCount() <= 40)
        {
            delaySeconds = 2.5f;
            LineMover.speed = -5.5f;
        }
    }

    private bool isCoroutineExecuting = false;

    IEnumerator ExecuteAfterTime(float time)   //IE numerator code for calling it in update
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        int i = Random.Range(0, 6);
        Instantiate(line[i], transform.localPosition, transform.rotation);

        isCoroutineExecuting = false;
    }
    
}

    
