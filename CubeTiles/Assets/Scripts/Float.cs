using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour {

    public ParticleSystem particle;
    Vector3 highestPos;
    Vector3 lowestPos;
    bool rising;
    float animStep = .01f;

    void Start ()
    {
        highestPos = transform.position + new Vector3(0, 1, 0);
        lowestPos = transform.position;
        rising = true;
    }
	
	void Update () {

        if (transform.position == highestPos)
        {
            rising = false;
        }
        else if (transform.position == lowestPos)
        {
            rising = true;
        }


        

        if (rising)
            transform.position = Vector3.MoveTowards(transform.position, highestPos, animStep); //move slowly the floater towards the highest position
        else
            transform.position = Vector3.MoveTowards(transform.position, lowestPos, animStep); //move slowly the floater towards the lowest position


    }

    public void EnableParticles()
    {
        ParticleSystem.EmissionModule em = particle.emission;
        em.enabled = true;
    }

}
