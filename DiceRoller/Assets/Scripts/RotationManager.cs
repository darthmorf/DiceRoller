using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{

    public Assets.Scripts.Utilities.Dice diceType;
	
	void Update ()
    {
        Vector3 rotation = gameObject.transform.rotation.eulerAngles;

        switch (diceType)
        {
            case Assets.Scripts.Utilities.Dice.D6:
                print(GetD6Value(rotation));
                return;

            default:
                throw new System.NotImplementedException();
        }
	}

    int GetD6Value (Vector3 rawRotation)
    {
        Vector3 roundedRotation = new Vector3(
            Assets.Scripts.Utilities.ToNearest90(rawRotation.x),
            Assets.Scripts.Utilities.ToNearest90(rawRotation.y),
            Assets.Scripts.Utilities.ToNearest90(rawRotation.z));

        if (roundedRotation.x == 0 && roundedRotation.z == 0)
        {
            return 4;
        }
        else if (roundedRotation.x == 90)
        {
            return 6;
        }
        else if (roundedRotation.x == 180 && roundedRotation.z == 0)
        {
            return 3;
        }
        else if (roundedRotation.x == 270)
        {
            return 1;
        }
        else if (roundedRotation.x == 0 && roundedRotation.z == 90)
        {
            return 2;
        }
        else if (roundedRotation.x == 0 && roundedRotation.z == 180)
        {
            return 3;
        }
        else if (roundedRotation.x == 0 && roundedRotation.z == 270)
        {
            return 5;
        }
        else
        {
            return -1;
        }
    }
}
