using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

    public Transform startPoint;
    public Transform endPoint;

    LineRenderer laserLine;

    private void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.SetWidth(.2f, .2f);
    }

    private void Update()
    {
        laserLine.SetPosition(0, startPoint.position); //create a laser line from the left cannon to the right
        laserLine.SetPosition(1, endPoint.position);
    }
}
