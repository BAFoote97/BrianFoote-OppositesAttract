﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour {

    public GameObject projectile;
    public float projectileLifetime;
    public float projectileForce;

    public bool canShoot;

    public float delayTime;
    public float delayMin;
    public float delayMax;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        delayTime = (Random.Range(delayMin, delayMax));

        if (canShoot == true)
        {
            //The Bullet Instantiation happens here.
            GameObject Temporary_Bullet_handler;

            Temporary_Bullet_handler = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
            Temporary_Bullet_handler.transform.Rotate(Vector3.left);

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody>();

            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            Temporary_RigidBody.AddForce(transform.forward * projectileForce, ForceMode.Impulse);

            //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
            Destroy(Temporary_Bullet_handler, projectileLifetime);

            canShoot = false;
            StartCoroutine(ShootDelay());
        }

    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(delayTime);
        canShoot = true;
    }

    

}
