using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

	public GameObject d6;
	public GameObject d8;
	public Canvas SpawnButtons;

	private List<GameObject> dice = new List<GameObject>();
	private float xPos = 0f;
	private float zPos = 0f;
	private float offset = 3.5f;

	private bool rollButtonPressed = false;

	public void ToggleSpawnUI()
	{
		SpawnButtons.enabled = !SpawnButtons.enabled;
	}

	public void SpawnD6()
	{
		SpawnDie(d6);
	}

	public void SpawnD8()
	{
		SpawnDie(d8);
	}

	private void SpawnDie(GameObject diceType)
	{
		GameObject go = Instantiate(diceType, new Vector3(xPos, 5, zPos), Quaternion.identity);
		dice.Add(go);

		if (xPos == 0) xPos += offset;

		else if (xPos > 0) xPos = (xPos * -1);

		else if (xPos < 0) xPos = (xPos * -1) + offset;

		if (dice.Count % 18 == 0)
		{
			xPos = 0;
			if (zPos == 0) zPos += offset;

			else if (zPos > 0) zPos = (zPos * -1);

			else if (zPos < 0) zPos = (zPos * -1) + offset;
		}
	}

	public void RollPress()
	{
		rollButtonPressed = true;
	}

	public void RollRelease()
	{
		rollButtonPressed = false;
	}

	private void Update()
	{
		if(rollButtonPressed)
		{
			foreach (GameObject go in dice)
			{
				go.GetComponent<Roll>().RollDie();
			}
		}
	}
}
