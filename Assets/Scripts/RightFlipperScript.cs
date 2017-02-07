using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFlipperScript : MonoBehaviour {
	public bool rightFlipperKey = false;
    Rigidbody2D rb;
    public float flipperSpeed = 1200;
    public float minAngle = 40;
    public float maxAngle = 320;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightShift)) {
			rightFlipperKey = true;
		}
		if(Input.GetKeyUp(KeyCode.RightShift)){
			rightFlipperKey = false;
		}
	}
	void FixedUpdate() {
		if(rightFlipperKey){
            if (transform.eulerAngles.z < maxAngle || transform.eulerAngles.z > minAngle)
                rb.MoveRotation(rb.rotation - flipperSpeed * Time.deltaTime);
            else
            {
                rb.angularVelocity = 0;
                transform.eulerAngles = new Vector3(0, 0, maxAngle);
            }
		}
		else {
            if (transform.eulerAngles.z > maxAngle || transform.eulerAngles.z < minAngle)
                rb.MoveRotation(rb.rotation + flipperSpeed * Time.deltaTime);
            else
            {
                rb.angularVelocity = 0;
                transform.eulerAngles = new Vector3(0, 0, minAngle);
            }
        }
	}
}
