using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTracer : MonoBehaviour {

    private CubeSpawner cs;
    private Teleport tp;
    private Rotate rotate;
    

    private Vector3 spawnPos;
    private Quaternion spawnRot;

    public GameObject Terrain;
    private UIController uicontroller;

    private Scene currentScene;
    private int buildIndex;

    public GameObject cubePlayer1;
    public GameObject cubePlayer2;


    
    private void Start()
    {

        spawnPos = transform.position; //Remember tha starting position and rotation to respawn from there 
        spawnRot = transform.rotation;

        transform.rotation = spawnRot;

        uicontroller = Terrain.GetComponent<UIController>();
        tp = GetComponent<Teleport>();
        rotate = GetComponent<Rotate>();


        currentScene = SceneManager.GetActiveScene();
        buildIndex = currentScene.buildIndex;
        
    }

    private void Update()
    {

        if (buildIndex == 3)
        {
            if(transform.position.x == 3.5f && transform.position.z == 12.5f) //if we are at 3rd level and player stands on the laser 
            {
                cubePlayer1.SetActive(true); //disable itself and enable the 2 cubes
                cubePlayer2.SetActive(true);
                gameObject.SetActive(false);
                cubePlayer2.GetComponent<Animation>()["splitting"].speed = 2.0f;
                cubePlayer2.GetComponent<Animation>().Play("splitting"); //play the animation
                Terrain.GetComponent<CubeHandler>().enabled = true;
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("obstacle"))
        {
            StartCoroutine(Respawn());
        }
        else if (other.transform.CompareTag("teleporter") && rotate.standing)
        {
            StartCoroutine(Teleport(other));
        }
        else if (other.transform.CompareTag("bound"))
        {      
            StartCoroutine(FallOfTheEdge());
        }
        else if (other.transform.CompareTag("goal") && rotate.standing)
        {
            other.GetComponent<AudioSource>().Play();
            StartCoroutine(CompletedLevel());
        }
    }

    IEnumerator Teleport(Collider other)
    {
        yield return new WaitForSeconds(.5f);
        tp.TeleportPlayer(); //Transport player to the left teleporter
        other.GetComponent<AudioSource>().Play();
    }

    IEnumerator FallOfTheEdge()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; //enable gravity so the cube can fall
        yield return new WaitForSeconds(1.5f);
        uicontroller.IncreaseScore(5); 
        StartCoroutine(Respawn()); //respawn after 1.5 sec
        
    }

    IEnumerator Respawn() //every scene has a different respawn position
    {
        yield return new WaitForSeconds(.1f);
        if(buildIndex == 1)
        {
            transform.position = spawnPos;
            transform.rotation = spawnRot;
            rotate.standing = true;
            rotate.horizontal = false;
        }
        else if (buildIndex == 2)
        {
            if (tp.rightside)
                transform.position = spawnPos;
            else
                transform.position = tp.leftTeleporter.transform.position;
            transform.rotation = spawnRot;
            rotate.standing = true;
            rotate.horizontal = false;
        }
        else if(buildIndex == 3)
        {
            transform.position = spawnPos;
            transform.rotation = spawnRot;
            rotate.standing = false;
            rotate.horizontal = true;
        }
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; //disable again the rigidbody (i could have used isKinematic but at some point i wanted
                                                                                //to use OnCollisionEnter so eventually i didn't use the isKinematic)

    }

    IEnumerator CompletedLevel()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; //let the player fall
        transform.localScale = new Vector3(1.95f, 0.95f, 0.95f); // make the object smaller so it can fit

        yield return new WaitForSeconds(1); //after 1 sec 
        uicontroller.CompletedLevel();  //show the menu
    }






}
