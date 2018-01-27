using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBox2 : MonoBehaviour {

    public Transform topLeft;
    public Transform bottomLeft;

    bool isMoving = false;
    int curDir = -1;
    bool constraintHit = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (transform.position.x < topLeft.position.x)
        {
            transform.position = new Vector2(topLeft.position.x, transform.position.y);
            constraintHit = true;
            isMoving = false;
        }
        if (transform.position.y > topLeft.position.y)
        {
            transform.position = new Vector2(transform.position.x, topLeft.position.y);
            constraintHit = true;
            isMoving = false;
        }
        if (transform.position.x > bottomLeft.position.x)
        {
            transform.position = new Vector2(bottomLeft.position.x, transform.position.y);
            constraintHit = true;
            isMoving = false;
        }
        if (transform.position.y < bottomLeft.position.y)
        {
            transform.position = new Vector2(transform.position.x, bottomLeft.position.y);
            constraintHit = true;
            isMoving = false;
        }
        if (GetComponent<Rigidbody2D>().velocity.magnitude > 0.01f)
        {
            isMoving = false;
        }
        
    }

   public void MoveUp()
    {
        if (!isMoving)
        {
            isMoving = true;
            curDir = 0;
        }

        if (isMoving && curDir == 0)
        {
            GetComponent<Rigidbody2D>().constraints=RigidbodyConstraints2D.FreezePositionX |
           RigidbodyConstraints2D.FreezeRotation;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2f);
        }
    }

    public void MoveDown()
    {
        if (!isMoving)
        {
            isMoving = true;
            curDir = 2;
        }

        if (isMoving && curDir == 2)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX |
             RigidbodyConstraints2D.FreezeRotation;
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * 2f);
        }

       
    }

    public void MoveRight()
    {
        if (!isMoving)
        {
            isMoving = true;
            curDir = 1;
        }

        if (isMoving && curDir == 1)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY |
           RigidbodyConstraints2D.FreezeRotation;
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * 2f);
        }
    }

    public void MoveLeft()
    {
        if (!isMoving)
        {
            isMoving = true;
            curDir = 3;
        }

        if (isMoving && curDir == 3)
        {
            GetComponent<Rigidbody2D>().constraints= RigidbodyConstraints2D.FreezePositionY |
            RigidbodyConstraints2D.FreezeRotation;
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * 2f);
        }
    }
}
