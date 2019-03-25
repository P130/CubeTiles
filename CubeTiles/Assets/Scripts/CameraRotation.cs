using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    public GameObject target;

    private float rotationSpeed = 8.0f;
	void Update ()
    {
        transform.RotateAround(target.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
