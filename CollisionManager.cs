using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {

    public float rate = 4f;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Sphere"))
        {
            Debug.Log("tmkoc");
            transform.GetComponent<Rigidbody>().AddForce(transform.forward * rate);
            transform.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
