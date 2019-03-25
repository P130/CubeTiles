using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeSpawner : MonoBehaviour {

    private Scene currentScene;

    public GameObject[,] Cubes = new GameObject[15,15];
    public Transform goalTrigger;

    private int x, y, buildIndex;



    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        buildIndex = currentScene.buildIndex;

        switch (buildIndex) //check in which scene we are
        {
            case 0:
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        GameObject instance = Instantiate(Resources.Load("Terrain", typeof(GameObject)), new Vector3(i + 0.5f, 0, j + 0.5f), Quaternion.identity) as GameObject;
                        Cubes[i, j] = instance;
                        if ((i == 1 && j == 2) || (i == 1 && j == 9) || (i == 2 && j == 11) || (i == 2 && j == 10) || (i == 3 && j == 3) || (i == 3 && j == 6) || (i == 3 && j == 12) || (i == 4 && j == 7) || (i == 4 && j == 10) || (i == 4 && j == 1) || (i == 4 && j == 3)
                        || (i == 5 && j == 7) || (i == 5 && j == 11) || (i == 6 && j == 0) || (i == 7 && j == 4) || (i == 7 && j == 8) || (i == 7 && j == 11) || (i == 8 && j == 7) || (i == 8 && j == 12) || (i == 8 && j == 14) || (i == 9 && j == 9) || (i == 9 && j == 1) || (i == 10 && j == 10) || (i == 11 && j == 4) || (i == 11 && j == 2)
                        || (i == 12 && j == 0) || (i == 12 && j == 3) || (i == 12 && j == 9) || (i == 12 && j == 12) || (i == 12 && j == 6) || (i == 13 && j == 13) || (i == 14 && j == 1))
                        {
                            ObstaclifyCube(instance); //create obstacles
                        }

                        if (i == 8 && j == 2)
                        {
                            instance.transform.position -= new Vector3(0, 3, 0); //create goal
                        }

                        instance.transform.parent = gameObject.transform;


                    }
                }

                for (int i = 2; i < 13; i++)
                {

                    ObstaclifyCube(Cubes[i, 5]);

                }
                break;
            case 1:
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        GameObject instance = Instantiate(Resources.Load("Terrain", typeof(GameObject)), new Vector3(i + 0.5f, 0, j + 0.5f), Quaternion.identity) as GameObject;
                        Cubes[i, j] = instance;
                        if ((i == 1 && j == 2) || (i == 1 && j == 9) || (i == 2 && j == 11) || (i == 2 && j == 10) || (i == 3 && j == 3) || (i == 3 && j == 6) || (i == 3 && j == 12)  || (i == 4 && j == 7) || (i == 4 && j == 10) || (i == 4 && j == 1) || (i == 4 && j == 3) 
                         || (i == 5 && j == 7) || (i == 5 && j == 11) || (i == 6 && j == 0) || (i == 7 && j == 4)|| (i == 7 && j == 8) || (i == 7 && j == 11) || (i == 8 && j == 7) || (i == 8 && j == 12) || (i == 8 && j == 14) || (i == 9 && j == 9) || (i == 9 && j == 1) || (i == 10 && j == 10) || (i == 11 && j == 4) || (i == 11 && j == 2)
                         || (i == 12 && j == 0)|| (i == 12 && j == 3) || (i == 12 && j == 9) || (i == 12 && j == 12) || (i == 12 && j == 6) || (i == 13 && j == 13) || (i == 14 && j == 1) )
                        {
                            ObstaclifyCube(instance);
                        }



                        if (i == 8 && j == 2)
                        {
                            instance.transform.position -= new Vector3(0, 3, 0);
                        }

                        instance.transform.parent = gameObject.transform;


                    }
                }

                for (int i = 2; i < 14; i++)
                {

                    ObstaclifyCube(Cubes[i, 5]);

                }
                break;
            case 2:
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        GameObject instance = Instantiate(Resources.Load("Terrain", typeof(GameObject)), new Vector3(i + 0.5f, 0, j + 0.5f), Quaternion.identity) as GameObject;
                        Cubes[i, j] = instance;
                        if ((i == 1 && j == 2) || (i == 1 && j == 9) || (i == 1 && j == 4) || (i == 1 && j == 7) || (i == 2 && j == 11) || (i == 2 && j == 0) || (i == 3 && j == 3) || (i == 3 && j == 4) || (i == 3 && j == 12) || (i == 4 && j == 7) || (i == 4 && j == 8) || (i == 4 && j == 1) || (i == 4 && j == 3)
                        || (i == 5 && j == 7) || (i == 5 && j == 11) || (i == 6 && j == 2) || (i == 7 && j == 4) || (i == 7 && j == 8) || (i == 7 && j == 11) || (i == 8 && j == 5) || (i == 8 && j == 7) || (i == 8 && j == 12) || (i == 8 && j == 14) || (i == 9 && j == 9) || (i == 9 && j == 1) || (i == 10 && j == 10) || (i == 11 && j == 4) || (i == 11 && j == 2)
                        || (i == 12 && j == 0) || (i == 12 && j == 3) || (i == 12 && j == 9) || (i == 12 && j == 12) || (i == 12 && j == 7) || (i == 13 && j == 13) || (i == 14 && j == 1))
                        {
                            ObstaclifyCube(instance);
                        }

                        if(j == 6)
                        {
                            ObstaclifyCube(instance);
                        }



                        if (i == 2 && j == 2)
                        {
                            instance.transform.position -= new Vector3(0, 3, 0);
                        }

                        instance.transform.parent = gameObject.transform;


                    }
                }

                
                break;
            case 3:
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        GameObject instance = Instantiate(Resources.Load("Terrain", typeof(GameObject)), new Vector3(i + 0.5f, 0, j + 0.5f), Quaternion.identity) as GameObject;
                        Cubes[i, j] = instance;
                        if ((i == 0 && j == 1) || (i == 0 && j == 8) || (i == 1 && j == 7) || (i == 1 && j == 2)   || (i == 1 && j == 4) || (i == 2 && j == 2) || (i == 3 && j == 3) || (i == 3 && j == 6) || (i == 3 && j == 9) || (i == 4 && j == 7) || (i == 4 && j == 1) || (i == 4 && j == 11) || (i == 4 && j == 13)
                                               || (i == 5 && j == 14) || (i == 6 && j == 7) || (i == 6 && j == 8) || (i == 6 && j == 12) || (i == 8 && j == 14) || (i == 7 && j == 10) || (i == 8 && j == 6) || (i == 10 && j == 7)
                                               || (i == 9 && j == 9) || (i == 10 && j == 10) || (i == 10 && j == 11) || (i == 10 && j == 12) || (i == 10 && j == 13) || (i == 12 && j == 8) || (i == 10 && j == 10) || (i == 11 && j == 4)
                                               || (i == 13 && j == 9) || (i == 13 && j == 11) || (i == 13 && j == 12) || (i == 12 && j == 14))
                        {
                            ObstaclifyCube(instance);
                        }

                        if((i==7 && j==1) || (i==7 && j==3))
                        {
                            instance.transform.position += new Vector3(0, 0.25f, 0);
                            instance.GetComponent<Renderer>().material.color = Color.green;
                            instance.transform.tag = "button";
                            instance.transform.localScale = new Vector3(.95f, .95f, .95f);
                            instance.GetComponent<BoxCollider>().isTrigger = true;
                        }

                        if ((j == 5 && i!=0) && (j==5 && i!=1))
                        {
                            ObstaclifyCube(instance);
                        }
                        
                        else if(i == 3 && j == 12)
                        {
                            instance.GetComponent<Renderer>().material.color = Color.cyan;
                        }

                        if(i == 12 && j == 2)
                        {
                            goalTrigger.parent = instance.transform;
                        }

                        instance.transform.parent = gameObject.transform;


                    }

                    
                }

                
                break;
    }


    }

    private void ObstaclifyCube(GameObject cube) //this function assigns obstacle properties to certain cubes 
    {
        cube.GetComponent<Renderer>().material.color = Color.gray;
        cube.tag = "obstacle";
        cube.transform.position += new Vector3(0, 0.25f, 0);
        cube.GetComponent<BoxCollider>().size = new Vector3(0.8f, 0.8f, 0.8f); //we use the box collider of the obstacles to detect collisioon with the player
        cube.GetComponent<BoxCollider>().isTrigger = true;
    }

    public GameObject CubeFromWorldPoint(Vector3 worldPoint)
    {
        x = (int)(worldPoint.x - 0.5f);
        y = (int)(worldPoint.z - 0.5f);
        return Cubes[x, y];
    }

}
