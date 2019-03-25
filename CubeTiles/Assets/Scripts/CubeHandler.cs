using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeHandler : MonoBehaviour {


    public GameObject cubePlayer1;
    public GameObject cubePlayer2;

    Transform cubeRotator;
    Transform cubeGoal;
    Vector3 endPos;

    float speed = .5f;
    bool rotating = false;
    Vector3 refPoint;
    Vector3 rotationAxis;
    float halfCubeSize = .5f;

    public GameObject Terrain;
    private GameObject refObject;

    private CubeSpawner cubespawner;
    private UIController uicontroller;

    Quaternion targetRot;


    public int outlinedCube = 2;

    public int cubesfinished = 0;

    public int cubesonbuttons = 0;
    public bool openhole = false;

    private void Start()
    {
        cubespawner = Terrain.GetComponent<CubeSpawner>();
        cubeGoal = cubespawner.Cubes[12, 2].transform;
        endPos = cubeGoal.position - new Vector3(0, 3, 0);

        cubePlayer2.GetComponent<Renderer>().material.SetFloat("_OutlineWidth", 1.1f);

        cubeRotator = (new GameObject("cubeRotator")).transform;
        uicontroller = Terrain.GetComponent<UIController>();
    }

    private void Update()
    {
        if (openhole)
        {
            cubeGoal.position = Vector3.MoveTowards(cubeGoal.transform.position, endPos, .02f);
        }
       

        if (!rotating)
        {
            if (Input.GetKeyDown(KeyCode.X))  //using X, user can choose which cube to move
            {
                if (outlinedCube == 1)
                {
                    cubePlayer2.GetComponent<Renderer>().material.SetFloat("_OutlineWidth", 1.1f); //cube that is able to move is outlined 

                    cubePlayer1.GetComponent<Renderer>().material.SetFloat("_OutlineWidth", 1.0f); 

                    outlinedCube = 2;
                }
                else if (outlinedCube == 2)
                {
                    cubePlayer1.GetComponent<Renderer>().material.SetFloat("_OutlineWidth", 1.1f); //cube that is able to move is outlined

                    cubePlayer2.GetComponent<Renderer>().material.SetFloat("_OutlineWidth", 1.0f);

                    outlinedCube = 1;
                }

            }
            else if (Input.GetKeyDown(KeyCode.D)) //the logic is similar to that of Rotate script but here we don't need to calculate sizes
            {                                     //cause the size of the cube is (1,1,1)
                rotating = true;
                refPoint = Vector3.forward * halfCubeSize;
                PositionRotator();
                targetRot = Quaternion.AngleAxis(90, Vector3.right) * cubeRotator.rotation;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                rotating = true;
                refPoint = Vector3.back * halfCubeSize;
                PositionRotator();
                targetRot = Quaternion.AngleAxis(90, Vector3.left) * cubeRotator.rotation;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                rotating = true;
                refPoint = Vector3.left * halfCubeSize;
                PositionRotator();
                targetRot = Quaternion.AngleAxis(90, Vector3.forward) * cubeRotator.rotation;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                rotating = true;
                refPoint = Vector3.right * halfCubeSize;
                PositionRotator();
                targetRot = Quaternion.AngleAxis(90, Vector3.back) * cubeRotator.rotation;
            }
        }
        else
        {
            cubeRotator.rotation = Quaternion.Slerp(cubeRotator.rotation, targetRot, speed);
        }

        if (cubeRotator.rotation == targetRot) //when Rotator reaches the desired rotation
        {
            refObject.transform.parent = null; //unparent the cube
            //and round to cube's position
            refObject.transform.position = new Vector3((float)Math.Round((double)refObject.transform.position.x, 2), (float)Math.Round((double)refObject.transform.position.y, 2), (float)Math.Round((double)refObject.transform.position.z, 2));

            rotating = false; 
            targetRot = Quaternion.identity;

        }
    }

    void PositionRotator()
    {
        uicontroller.IncreaseScore(1);


        if (outlinedCube == 1)
            refObject = cubePlayer1;
        else if (outlinedCube == 2)
            refObject = cubePlayer2;

        cubeRotator.localRotation = Quaternion.identity;


        cubeRotator.position = refObject.transform.position - Vector3.up * halfCubeSize + refPoint;
        refObject.transform.parent = cubeRotator;

        refObject.GetComponent<AudioSource>().Play();


    }
}
