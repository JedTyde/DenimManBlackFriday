using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraM : MonoBehaviour
{
    public Transform objToFollow; // <--- Reference that object here	
	public float followDelay; // Smooths out the following effect

    void LateUpdate() => transform.position = Vector3.Lerp(transform.position, objToFollow.position, followDelay);
}
