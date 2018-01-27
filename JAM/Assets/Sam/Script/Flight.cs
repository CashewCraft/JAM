using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour {
    [SerializeField]
    float horizontalSpeed = 10f;
    [SerializeField]
    float vertImpulse = 5f;
    [SerializeField]
    float vertDelay = 0.5f;
    float curVertDelay = 0f;
    Rigidbody2D rig;

    float fixedX = -999f;
    bool isRightWall = true;


    float fixedY = -999f;
    bool isFloor = true;

    public enum LastStick { None, Ceiling, Wall}
    public LastStick lastStick = LastStick.None;

    float dropTime = 0.3f;
    float curDropTime = 0f;
    bool isDropping = false;

    float checkTime = 0.05f;
    float curCheckTime = 0f;



    // Use this for initialization
    void Awake() {
        rig = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void FixedUpdate() {
        curCheckTime += Time.fixedDeltaTime;
        curVertDelay += Time.fixedDeltaTime;


        if (isDropping)
        {
            curDropTime += Time.deltaTime;
            /*bool isValid = true;
           /* RaycastHit2D ceilingCheck = Physics2D.Raycast(gameObject.transform.position, Vector2.up);
            if (Mathf.Abs(ceilingCheck.distance) < 0.5f && ceilingCheck.transform.GetComponent<Ceiling>() != null)
            {
                RaycastHit2D wallCheckRight = Physics2D.Raycast(gameObject.transform.position, Vector2.right);
                RaycastHit2D wallCheckLeft = Physics2D.Raycast(gameObject.transform.position, Vector2.left);
                if ((Mathf.Abs(wallCheckLeft.distance) < 0.5f && wallCheckLeft.transform.GetComponent<Wall>() != null) && (Mathf.Abs(wallCheckRight.distance) < 0.5f && wallCheckRight.transform.GetComponent<Wall>() != null))*/









            /* RaycastHit2D ceilingCheck = Physics2D.Raycast(transform.position, Vector2.up);
             if (ceilingCheck.collider != null)
             {
                 if(Mathf.Abs(ceilingCheck.point.y - transform.position.y) < 0.5f || ceilingCheck.transform.GetComponent<Ceiling>() != null)
                 {
                     RaycastHit2D leftCheck = Physics2D.Raycast(transform.position, Vector2.left);
                     RaycastHit2D rightCheck = Physics2D.Raycast(transform.position, Vector2.right);
                     if ((Mathf.Abs(leftCheck.point.x - transform.position.x) < 0.5f || leftCheck.transform.GetComponent<Wall>() != null) || (Mathf.Abs(rightCheck.point.x - transform.position.x) < 0.5f || rightCheck.transform.GetComponent<Wall>() != null))
                     {
                         if (curDropTime >= dropTime && false)
                         {
                             fixedX = -999f;
                             fixedY = -999f;
                             isDropping = false;
                             rig.rotation = 0f;
                         }

                     }
                 } 
             } */



            /* RaycastHit2D ceilingCheck = Physics2D.Raycast(transform.position, Vector2.up);
             RaycastHit2D leftCheck = Physics2D.Raycast(transform.position, Vector2.left);
             RaycastHit2D rightCheck = Physics2D.Raycast(transform.position, Vector2.right);
             if (ceilingCheck.collider != null && ceilingCheck.distance < 2f)
             {
                 if (leftCheck.collider != null && leftCheck.distance < 2f)
                 {

                     if (rightCheck.collider != null && rightCheck.distance <2f) 
                     {
                         if (curDropTime >= dropTime)
                         {
                             fixedX = -999f;
                             fixedY = -999f;
                             isDropping = false;
                             rig.rotation = 0f;
                         }
                     }
                 }
             }
         }*/

            RaycastHit2D up = Physics2D.Raycast(transform.position + Vector3.up * 0.51f, Vector2.up);
            RaycastHit2D left = Physics2D.Raycast(transform.position + Vector3.left * 0.51f, Vector2.left);
            RaycastHit2D right = Physics2D.Raycast(transform.position + Vector3.right * 0.51f, Vector2.right);
            //Debug.Log(up.distance + " " + left.distance + " " + right.distance);
            if (up.distance > 0.1f && left.distance > 0.1f && right.distance > 0.1f)
            {
                
                    fixedX = -999f;
                    fixedY = -999f;
                    isDropping = false;
                    rig.rotation = 0f;
                
            }
        }

        RaycastHit2D left1 = Physics2D.Raycast(transform.position + Vector3.left * 0.51f, Vector2.left);
        RaycastHit2D right1 = Physics2D.Raycast(transform.position + Vector3.right * 0.51f, Vector2.right);

        if (left1.distance < 0.01f)
        {
            rig.rotation = 270f;
        }
        else { if (right1.distance < 0.01f)
            rig.rotation = 90f;
        }


        if (Input.GetButton("Fire2") )//|| Input.GetAxisRaw("Jump") > 0.8f)
        {
            if (fixedX != -999f)
            {

                fixedX = -999f;

                if (isRightWall)
                {
                    rig.AddForce(Vector2.right * horizontalSpeed * 100f);
                }
                else
                {
                    rig.AddForce(Vector2.left * horizontalSpeed * 100f);
                }
            }

            if(fixedY != -999f)
            {

               fixedY = -999f;                
               rig.AddForce(Vector2.down * horizontalSpeed * 15f);
                
                 
            }
            rig.rotation = 0f;
        }

        if (fixedX != -999f || fixedY != -999f)
        {


            if (fixedX != -999f)
            {
                if (Mathf.Abs(Input.GetAxis("MoveY")) > 0)
                {
                    rig.AddForce(Vector2.up * ((Input.GetAxis("MoveY") * 1 * -horizontalSpeed) - (rig.velocity.y * 0.2f)), ForceMode2D.Impulse);

                }

                transform.position = new Vector2(fixedX, transform.position.y);
                rig.velocity = new Vector2(0, rig.velocity.y);
                rig.gravityScale = 0;
                //Debug.Log(fixedX);
                curDropTime = 0;
                


            } else
            {
                if (Mathf.Abs(Input.GetAxis("MoveX")) > 0)
                {
                    rig.AddForce(Vector2.right * ((Input.GetAxis("MoveX") * 1 * horizontalSpeed) - (rig.velocity.x * 0.2f)), ForceMode2D.Impulse);
                
                }

                rig.rotation = 180f;

                transform.position = new Vector2(transform.position.x, fixedY);
                rig.velocity = new Vector2(rig.velocity.x,0);
                rig.gravityScale = 0;
                //Debug.Log(fixedY);
                curDropTime = 0;


            }
        }
        else
        {
            rig.gravityScale = 1f;
            
            if (Input.GetAxisRaw("Jump") > 0 && curVertDelay >= vertDelay)
            {
                rig.isKinematic = false;
                curVertDelay = 0f;

                float impulse = rig.velocity.y <= 0 ? (vertImpulse + (Mathf.Abs(rig.velocity.y) * 0.8f)) : vertImpulse;
                rig.AddForce(Vector2.up * impulse, ForceMode2D.Impulse);
            }



            if (Mathf.Abs(Input.GetAxis("MoveX")) > 0)
            {
                rig.AddForce(Vector2.right * ((Input.GetAxis("MoveX") * horizontalSpeed) - (rig.velocity.x * 0.2f)), ForceMode2D.Impulse);
            }
        }


        

            
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        /*if (curCheckTime >= checkTime)
        {
            curCheckTime = 0;
            /*
            if (fixedX != -999f)
            {
                CheckWall(col);
                CheckCeiling(col);
            }
            else if (fixedY != -999f)
            {
                CheckCeiling(col);
                CheckWall(col);
            }
            else
            {
                CheckCeiling(col);
                CheckWall(col);
            }
        }*/

        /* if (Mathf.Abs(Input.GetAxisRaw("MoveX")) > Mathf.Abs(Input.GetAxisRaw("MoveY")))
         {
             CheckWall(col);
         }
         else
         {
             CheckCeiling(col);
         }
     }
    */
        CheckWall(col);
        CheckCeiling(col);
        if (Mathf.Abs(Input.GetAxis("MoveY")) > 0 && fixedY != -999f)
        {

            CheckCeiling(col);
        }
        else if (Mathf.Abs (Input.GetAxis("MoveX")) > 0 && fixedX != -999f)
        {
            CheckWall(col);
        
            
        }

    }

    void CheckWall(Collision2D col)
    {
        if (col.gameObject.GetComponent<Wall>() != null)
        {
            fixedX = transform.position.x;
            fixedY = -999f;

            isRightWall = (transform.position.x - col.transform.position.x) > 0 ? true : false;
            isDropping = false;
            curDropTime = 0f;
            //Debug.Log(fixedX);
        }
    }

    void CheckCeiling(Collision2D col)
    {
        if (col.gameObject.GetComponent<Ceiling>() != null)
        {
            fixedY = transform.position.y;
            fixedX = -999f;

            isFloor = (transform.position.y - col.transform.position.y) > 0 ? true : false;
            isDropping = false;
            curDropTime = 0f;
            //Debug.Log(fixedX);
        }
    }


    void OnCollisionExit2D(Collision2D col)
    {
        // if ((col.gameObject.GetComponent<Wall>() != null && fixedY != -999f) || (col.gameObject.GetComponent<Ceiling>() != null && fixedX != -999f))
        curDropTime = 0f;
        isDropping = true;
    }

}
