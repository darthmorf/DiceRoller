using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RotationManager : MonoBehaviour
{

    public Assets.Scripts.Utilities.Dice diceType;
	
	void Update ()
    {
        Vector3 rotation = gameObject.transform.rotation.eulerAngles;

        switch (diceType)
        {
            case Assets.Scripts.Utilities.Dice.D4:
                print(GetD4Value(rotation));
                return;

            case Assets.Scripts.Utilities.Dice.D6:
                print(GetD6Value(rotation));
                return;

            default:
                throw new System.NotImplementedException();
        }
	}

    string GetD6Value2()
    {
        Transform[] faces = gameObject.GetComponentsInChildren<Transform>();
        Transform highestFace = faces[0];
        foreach (Transform face in faces.Skip(0).ToArray())
        {
            if (face.position.y > highestFace.position.y)
            {
                highestFace = face;
            }
        }
        return highestFace.name;
    }

    int GetD4Value (Vector3 rawRotation)
    {
        Vector3 roundedRotation = new Vector3(
           RoundD4x(rawRotation.x),
           rawRotation.y,
           RoundD4z(rawRotation.z));

        if (roundedRotation.x == 19.5f && roundedRotation.z == 30)
        {
            return 4;
        }
        else if (roundedRotation.x == 19.5f && roundedRotation.z == 150)
        {
            return 2;
        }
        else if (roundedRotation.x == 19.5f && roundedRotation.z == 270)
        {
            return 3;
        }
        else if (roundedRotation.x == 270)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    int GetD6Value (Vector3 rawRotation)
    {
        Vector3 roundedRotation = new Vector3(
            RoundD6(rawRotation.x),
            rawRotation.y,
            RoundD6(rawRotation.z));

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



   float RoundD4x (float rawValue)
    {
        if (rawValue <= 144.75)
        {
            return 19.5f;
        }
        else if (rawValue <= 324.75)
        {
            return 270f;
        }
        else if (rawValue <= 360)
        {
            return 19.5f;
        }
        else
        {
            return -1;
        }
    }

    int RoundD4z (float rawValue)
    {
        if (rawValue <= 90)
        {
            return 30;
        }
        else if (rawValue <= 210)
        {
            return 150;
        }
        else if (rawValue <= 330)
        {
            return 270;
        }
        else if (rawValue <= 360)
        {
            return 30;
        }
        else
        {
            return -1;
        }
    }

    int RoundD6(float rawValue)
    {
        if (rawValue <= 45)
        {
            return 0;
        }
        else if (rawValue <= 135)
        {
            return 90;
        }
        else if (rawValue <= 225)
        {
            return 180;
        }
        else if (rawValue <= 315)
        {
            return 270;
        }
        else if (rawValue <= 360)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
}
