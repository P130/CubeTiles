using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeTracer : MonoBehaviour {

    private Rotate rotate;

    private Vector3 spawnPos;
    private Quaternion spawnRot;

    public GameObject Terrain;
    private UIController uicontroller;
    private CubeHandler cubehandler;
    Collision other;

    private void Start()
    {
        spawnPos = transform.position; //remember the initial position
        spawnRot = transform.rotation;

        if(transform.name == "cubePlayer2")
        {
            spawnPos -= new Vector3(0, 1, 0);
        }

        uicontroller = Terrain.GetComponent<UIController>();
        cubehandler = Terrain.GetComponent<CubeHandler>();

    }

   
   

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("goal")) //if a cube reaches the goal, the second one needs to reach it to complete the level
        {
            
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            transform.localScale = new Vector3(0.90f, 0.90f, 0.90f);
            other.GetComponent<AudioSource>().Play();
            cubehandler.cubesfinished++;

            

            if (cubehandler.cubesfinished == 2) //show if the second cube reaches the goal show the complete level menu
            {
                StartCoroutine(CompletedLevel(other));
            }

           if (transform.name == "cubePlayer1")
           {
                cubehandler.outlinedCube = 2;
                cubehandler.cubePlayer2.GetComponent<Renderer>().material.SetFloat("_OutlineWidth", 1.1f);
           }
           else
           {
                cubehandler.outlinedCube = 1;
                cubehandler.cubePlayer1.GetComponent<Renderer>().material.SetFloat("_OutlineWidth", 1.1f);
            }
        }
        else if(other.transform.CompareTag("obstacle")) //start from initial position if hits obstacle
        {
            StartCoroutine(Respawn());
        }
        else if (other.transform.CompareTag("bound")) //start from inital position if falls of the edge
        {
            StartCoroutine(FallOfTheEdge());
        }
        else if(other.transform.CompareTag("button")) //both cubes need to reach the green cubes to open the hole
        {
            cubehandler.cubesonbuttons++;
            
            if(cubehandler.cubesonbuttons == 2)
            {
                cubehandler.openhole = true;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.CompareTag("button"))
        {
            cubehandler.cubesonbuttons--;
        }
    }


    IEnumerator FallOfTheEdge()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        yield return new WaitForSeconds(1.5f);
        uicontroller.IncreaseScore(5);
        StartCoroutine(Respawn());

    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(.1f);
        transform.position = spawnPos;
        transform.rotation = spawnRot;
    }

    IEnumerator CompletedLevel(Collider other)
    {
        
        yield return new WaitForSeconds(1);
        uicontroller.CompletedLevel();
        
    }


}
