using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour {

    AudioSource audioMove;

    Transform rotator;
    float speed = .5f;
    float halfCubeWidth;
    float halfCubeHeight;
    float halfCubeDepth;
    bool rotating = false;
    Vector3 refPoint;
    Vector3 rotationAxis;

    public GameObject Terrain;
    private UIController uicontroller; 

    public bool standing; //we keep track of the state of the player
    public bool horizontal; //(they are public cause we need to check sometimes if player is standing for example when he reach the goal)

    Quaternion targetRot;

    void Start()
    {
        audioMove = GetComponent<AudioSource>();
        rotator = (new GameObject("Rotator")).transform; //we create a new object and we name it Rotator

        uicontroller = Terrain.GetComponent<UIController>();

    }



    void Update()
    {
        if (!rotating) 
        {
            if (Input.GetKeyDown(KeyCode.D)) 
            {
                Debug.Log("D");
                rotating = true;
                CalculateCubeSizes(); //while keeping an eye at the state of the player we can calculate the depth,height and width of player according to player's view

                if (standing) //we always check the state of the player
                {
                    standing = false;
                    horizontal = true;
                }
                else
                {
                    if (horizontal)
                    {
                        standing = true;
                        horizontal = false;
                    }

                }

                refPoint = Vector3.forward * halfCubeWidth; 
                PositionRotator();     //we position the Rotator
                targetRot = Quaternion.AngleAxis(90, Vector3.right) * rotator.rotation; //after we make Rotator parent of player, we rotate the Rotator on x axis(cause D was pressed)
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("A");
                rotating = true;
                CalculateCubeSizes();

                if (standing)
                {
                    standing = false;
                    horizontal = true;
                }
                else
                {
                    if (horizontal)
                    {
                        standing = true;
                        horizontal = false;
                    }

                }

                refPoint = Vector3.back * halfCubeWidth;
                PositionRotator();
                targetRot = Quaternion.AngleAxis(90, Vector3.left) * rotator.rotation;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {

                Debug.Log("W");
                rotating = true;
                CalculateCubeSizes();

                if (standing)
                {
                    standing = false;
                    horizontal = false;
                }
                else
                {
                    if (!horizontal)
                    {
                        standing = true;
                    }

                }

                refPoint = Vector3.left * halfCubeDepth;
                PositionRotator();
                targetRot = Quaternion.AngleAxis(90, Vector3.forward) * rotator.rotation;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {

                Debug.Log("S");
                rotating = true;
                CalculateCubeSizes();


                if (standing)
                {
                    standing = false;
                    horizontal = false;
                }
                else
                {
                    if (!horizontal)
                    {
                        standing = true;
                    }

                }


                refPoint = Vector3.right * halfCubeDepth;
                PositionRotator();
                targetRot = Quaternion.AngleAxis(90, Vector3.back) * rotator.rotation;
            }
        }
        else
        {
            rotator.rotation = Quaternion.Slerp(rotator.rotation, targetRot, speed);
        }

        if (rotator.rotation == targetRot) //when Rotator reaches the desired rotation
        {
            transform.parent = null; //unparent the gameObject
            rotating = false; 
            //and round the gameObject's position
            transform.position = new Vector3((float)Math.Round((double)transform.position.x, 2), (float)Math.Round((double)transform.position.y, 2), (float)Math.Round((double)transform.position.z, 2));


            targetRot = Quaternion.identity;

        }
    }

    void PositionRotator()
    {
        audioMove.Play();
        rotator.localRotation = Quaternion.identity;
        rotator.position = transform.position - Vector3.up * halfCubeHeight + refPoint; //Rotator will first take the transform's position and according to player's state
        transform.parent = rotator;                                                     //will move on y axis and x or z axis
    }                                                                                   //for example if player is standing and "D" is pressed then Rotator will transform's position
                                                                                        //and will move 1.0f downwards (height = 2.0f) and 0.5f rightwards (width = 1.0f) 



    void CalculateCubeSizes()
    {
    
        uicontroller.IncreaseScore(1); 
        if (!standing && !horizontal)  // Vertical
        {
            halfCubeWidth = .5f;
            halfCubeDepth = 1;
            halfCubeHeight = .5f; 
            Debug.Log("Vertical");
        }
        else if (!standing && horizontal) // Horizontal
        {
            halfCubeWidth = 1;
            halfCubeDepth = .5f;
            halfCubeHeight = .5f;
            Debug.Log("Horizontal");
        }
        else if (standing && !horizontal) // Standing
        {
            halfCubeWidth = .5f;
            halfCubeDepth = .5f;
            halfCubeHeight = 1f;
            Debug.Log("Standing");
        }
        
    }
    
    





}

