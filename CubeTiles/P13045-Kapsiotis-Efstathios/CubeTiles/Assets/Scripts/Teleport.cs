using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public bool rightside;
    public Transform rightTeleporter;
    public Transform leftTeleporter;
    public ParticleSystem right_ps;
    public ParticleSystem left_ps;

    private void Start()
    {
        rightside = true;
    }

    public void TeleportPlayer()
    {
        if(rightside)
        {
            right_ps.Play(); //play the particle system of right teleporter
            transform.position = leftTeleporter.position; //move the player to the left teleporter
            rightTeleporter.GetChild(0).gameObject.SetActive(true); //show the hide floater cube
            
            leftTeleporter.GetChild(0).gameObject.SetActive(false); //hide the left floater cube

            rightside = false; //this boolean is used to decide in case player collides with object or falls off the edge, if he will respawn from the right or the left side
        }
        
    }


}
