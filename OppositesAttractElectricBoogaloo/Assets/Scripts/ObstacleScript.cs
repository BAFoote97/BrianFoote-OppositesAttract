using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {

    public float moveMin;
    public float moveMax;

    public float moveSpeed;

    public bool moveIndependent;

	// Use this for initialization
	void Start () {
        moveSpeed = (Random.Range(moveMin, moveMax));

	}
	
	// Update is called once per frame
	void Update () {
        if (moveIndependent == false)
        {
           transform.Translate(0, -moveSpeed, 0);
        }
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Border")
        {
            Debug.Log("Hit border");
            Destroy(gameObject);
        }
    }
}
