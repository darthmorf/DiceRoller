using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roll : MonoBehaviour
{

	public GameObject die;
	public float forceMin;
	public float forceMax;
	public Button rollButton;

	Vector3 startPos;


	void Start()
	{
		startPos = die.transform.position;
	}

	public void RollDie()
	{
		Debug.Log("Rolling");
		// Reset
		die.GetComponent<Rigidbody>().velocity = Vector3.zero;
		die.transform.position = startPos;

		// Random orientation and Force
		die.transform.rotation = Random.rotation;
		die.GetComponent<Rigidbody>().useGravity = true;
		die.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(forceMin, forceMax) * RandomSign(), 0, Random.Range(forceMin, forceMax) * RandomSign()));
	}

	private int RandomSign()
	{
		return Random.value< .5? 1 : -1;
	}
}
