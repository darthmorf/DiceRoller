using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RotationManager : MonoBehaviour
{	
	void Update ()
    {
       print(gameObject.name + ": " + GetHighestFace(gameObject).name);
	}

    Transform GetHighestFace(GameObject parent)
    {
        Transform[] faces = parent.GetComponentsInChildren<Transform>();
        faces = faces.Skip(1).ToArray();
        Transform highestFace = faces[0];
        foreach (Transform face in faces)
        {
            if (face.position.y > highestFace.position.y)
            {
                highestFace = face;
            }
        }
        return highestFace;
    }
}
