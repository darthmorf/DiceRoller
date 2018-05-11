using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour {

	public GameObject die;
	public float forceMin;
	public float forceMax;

	Vector3 startPos;


	void Start()
	{
		startPos = die.transform.position;
	}

	private void Update()
	{
		if(Input.GetKey("space") || Input.touchCount > 0)
		{
			// Reset
			die.GetComponent<Rigidbody>().velocity = Vector3.zero;
			die.transform.position = startPos;

			// Random orientation and Force
			die.transform.rotation = Random.rotation;
			die.GetComponent<Rigidbody>().useGravity = true;
			die.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(forceMin, forceMax), Random.Range(forceMin, forceMax), Random.Range(forceMin, forceMax)));
		}
	}
}
