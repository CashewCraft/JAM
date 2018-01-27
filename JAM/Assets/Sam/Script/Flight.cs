using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour {
    public bool canFly = true;

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

    public GameController gameController;
    public Animator anim;

    float fixedY = -999f;
    bool isFloor = true;

    public enum LastStick { None, Ceiling, Wall}
    LastStick curStick = LastStick.None;
    LastStick lastStick = LastStick.None;

    float stickTime = 0.25f;
    float curStickTime = 0f;


    float dropTime = 0.3f;
    float curDropTime = 0f;
    bool isDropping = false;

    float checkTime = 0.05f;
    float curCheckTime = 0f;



    // Use this for initialization
    void Awake() {
        rig = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();
        
        
	}

    // Update is called once per frame
    void FixedUpdate() {
        curCheckTime += Time.fixedDeltaTime;
        curVertDelay += Time.fixedDeltaTime;
        curStickTime += Time.fixedDeltaTime;


        if (isDropping)
        {
            curDropTime += Time.deltaTime;
        
            RaycastHit2D up = Physics2D.Raycast(transform.position + Vector3.up * 0.5001f, Vector2.up);
            RaycastHit2D left = Physics2D.Raycast(transform.position + Vector3.left * 0.5001f, Vector2.left);
            RaycastHit2D right = Physics2D.Raycast(transform.position + Vector3.right * 0.5001f, Vector2.right);
            
            if (up.distance > 0.1f && left.distance > 0.1f && right.distance > 0.1f)
            {

                fixedX = -999f;
                fixedY = -999f;
                isDropping = false;
                rig.rotation = 0f;

            }
        }

        RaycastHit2D left1 = Physics2D.Raycast(transform.position + Vector3.left * 0.5001f, Vector2.left);
        RaycastHit2D right1 = Physics2D.Raycast(transform.position + Vector3.right * 0.5001f, Vector2.right);
        RaycastHit2D down = Physics2D.Raycast(transform.position + Vector3.up * -0.5001f, -Vector2.up);
        RaycastHit2D up1 = Physics2D.Raycast(transform.position + Vector3.up * 0.5001f, Vector2.up);
        if (left1.distance < 0.01f)
        {
            rig.rotation = 270f;
        }
        else { if (right1.distance < 0.01f)
            {
                rig.rotation = 90f;
            }
         else if (up1.distance < 0.0001f)
            {
                rig.rotation = 180f;
            }
        }
    


        if (Mathf.Abs(Input.GetAxis("Jump")) > 0.95f  && curStickTime >= stickTime && canFly)//|| Input.GetAxisRaw("Jump") > 0.8f)
        {
            curStickTime = 0f;
            if (fixedX != -999f)
            {

                fixedX = -999f;
                curStick = LastStick.None;
                if (isRightWall)
                {
                    rig.AddForce(Vector2.right * horizontalSpeed * 100f);
                    anim.SetTrigger("Fly");
                }
                else
                {
                    rig.AddForce(Vector2.left * horizontalSpeed * 100f);
                    anim.SetTrigger("Fly");
                }
            }

            if(fixedY != -999f)
            {
                curStick = LastStick.None;
                if (isFloor)
                {
                    rig.AddForce(Vector2.down * horizontalSpeed * 500f);
                    anim.SetTrigger("Fly");
                } else
                {
                    rig.AddForce(Vector2.up * horizontalSpeed * 15f);
                    anim.SetTrigger("Fly");
                }
                fixedY = -999f;                
              
                
                 
            }
            rig.rotation = 0f;
        }

        if (Mathf.Abs(Input.GetAxis("Jump")) > 0.85f && (down.distance < 0.01f) && canFly){
            if (fixedY != -999f)
            {
                anim.SetTrigger("Fly");
                curStick = LastStick.None;
                    rig.AddForce(Vector2.up * horizontalSpeed * 15f, ForceMode2D.Impulse);
                    fixedY = -999f;
                    curStickTime = 0f;
                }

            }
        

        if (fixedX != -999f || fixedY != -999f)
        {


            if (fixedX != -999f)
            {
                if (Mathf.Abs(Input.GetAxis("MoveY")) > 0)
                {
                    anim.SetTrigger("Walk");
                    rig.AddForce(Vector2.up * ((Input.GetAxis("MoveY") * 1 * -horizontalSpeed) - (rig.velocity.y * 0.2f)), ForceMode2D.Impulse);

                }

                transform.position = new Vector2(fixedX, transform.position.y);
                rig.velocity = new Vector2(0, rig.velocity.y);
                rig.gravityScale = 0;
               
                curDropTime = 0;
                


            } else
            {
                
                if ((down.distance > 0f))
                {

                    transform.position = new Vector2(transform.position.x, fixedY);
                    rig.velocity = new Vector2(rig.velocity.x, 0);
                    rig.gravityScale = 0;
                    
                    curDropTime = 0;
                }
                else if (Input.GetAxisRaw("Jump") > 0.05f && canFly)// && curVertDelay >= vertDelay)
                {
                    anim.SetTrigger("Fly");
                    fixedX = -999f;
                    fixedY = -999f;
                    isDropping = false;
                    rig.rotation = 0f;

                    // rig.isKinematic = false;
                    rig.gravityScale = 1f;
                    curVertDelay = 0f;

                   // float impulse = rig.velocity.y <= 0 ? (vertImpulse + (Mathf.Abs(rig.velocity.y) * 0.8f)) : vertImpulse;
                    rig.AddForce(Vector2.up * vertImpulse * 5, ForceMode2D.Impulse);
                    curStick = LastStick.None;
                }
                else
                {
                    transform.position = new Vector2(transform.position.x, fixedY);
                    rig.velocity = new Vector2(rig.velocity.x, 0);
                    rig.gravityScale = 0;
                    
                    curDropTime = 0;
                }

                if (Mathf.Abs(Input.GetAxis("MoveX")) > 0)
                {
                    anim.SetTrigger("Walk");
                    rig.AddForce(Vector2.right * ((Input.GetAxis("MoveX") * 1 * horizontalSpeed) - (rig.velocity.x * 0.2f)), ForceMode2D.Impulse);

                }

            }
        }
        else
        {
            rig.gravityScale = 1f;
            
            if (Input.GetAxisRaw("Jump") > 0.85f && curVertDelay >= vertDelay && canFly)
            {
                anim.SetTrigger("Fly");
                // rig.isKinematic = false;
                curVertDelay = 0f;

                float impulse = rig.velocity.y <= 0 ? (vertImpulse + (Mathf.Abs(rig.velocity.y) * 0.8f)) : vertImpulse;
                rig.AddForce(Vector2.up * impulse, ForceMode2D.Impulse);
                curStick = LastStick.None;
            }



            if (Mathf.Abs(Input.GetAxis("MoveX")) > 0)
            {
                anim.SetTrigger("Walk");
                rig.AddForce(Vector2.right * ((Input.GetAxis("MoveX") * horizontalSpeed) - (rig.velocity.x * 0.2f)), ForceMode2D.Impulse);
            }
        }


        if (Mathf.Abs(Input.GetAxis("MoveX")) < 0.05)
        {
            anim.SetTrigger("Walk");
            rig.AddForce(-rig.velocity.x * Vector2.right * 20);
        }



            if (curStick != lastStick)
        {
            curStickTime = 0f;
        }

        lastStick = curStick;

           if (rig.rotation == 0)
        {
            if (Input.GetAxis("MoveX") < 0)

            {
                anim.SetTrigger("Walk");
                GetComponent<SpriteRenderer>().flipX = true;
            } else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        if (rig.rotation == 180)
        {
            if (Input.GetAxis("MoveX") < 0)

            {
                anim.SetTrigger("Walk");
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        if (Input.GetButtonDown("Fire3"))
        {
            gameController.Die(gameObject);
            fixedY = -999f;
            fixedX = -999f;
            curStick = LastStick.None;
            isDropping = false;
            curDropTime = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        CheckHurty(col);
        CheckWall(col);
        CheckCeiling(col);
        if (Mathf.Abs(Input.GetAxis("MoveY")) > 0 && fixedX != -999f)
        {
            CheckCeiling(col);
        }
        else if (Mathf.Abs (Input.GetAxis("MoveX")) > 0 && fixedY != -999f)
        {
            CheckWall(col);
        }

    }

    void CheckHurty(Collision2D col)
    {
        if (col.gameObject.GetComponent<Hurty>() != null)
        {
            gameController.Die(gameObject);

            fixedY = -999f;
            fixedX = -999f;
            curStick = LastStick.None;
            isDropping = false;
            curDropTime = 0f;
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

            curStick = LastStick.Wall;
            anim.SetTrigger("Walk");

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

            curStick = LastStick.Ceiling;
            anim.SetTrigger("Walk");

        }
    }


    void OnCollisionExit2D(Collision2D col)
    {
        curDropTime = 0f;
        isDropping = true;
    }

}
