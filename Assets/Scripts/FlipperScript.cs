using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour {
	public bool leftFlipperKey = false;
    Rigidbody2D rb;
    public float flipperSpeed = 300;
    public float minAngle = 180;
    public float maxAngle = 40;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftShift)) {
			leftFlipperKey = true;
		}
		if(Input.GetKeyUp(KeyCode.LeftShift)){
			leftFlipperKey = false;
		}
	}
	void FixedUpdate() {
		if(leftFlipperKey){
            if (transform.eulerAngles.z < maxAngle || transform.eulerAngles.z > minAngle)
                rb.MoveRotation(rb.rotation + flipperSpeed * Time.deltaTime);
            else
            {
                rb.angularVelocity = 0;
                transform.eulerAngles = new Vector3(0, 0, maxAngle);
            }
		}
		else {
            if (transform.eulerAngles.z > 320 || transform.eulerAngles.z < minAngle)
                rb.MoveRotation(rb.rotation - flipperSpeed * Time.deltaTime);
            else
            {
                rb.angularVelocity = 0;
                transform.eulerAngles = new Vector3(0, 0, 320);
            }
        }
	}
}
