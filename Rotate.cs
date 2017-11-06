using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

   // public float speedx = 0;
  //  public float speedy = 0;
    public float speedz = 3f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(transform.position, Vector3.zero, speedz);
	}
}
