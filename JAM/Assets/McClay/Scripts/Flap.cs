using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flap : MonoBehaviour {

    public float InUp;
    public float InNotUp;
    float Up;
    float NotUp;
    public float speed = 10;
    public bool invert = false;
    float ry;

    public float debug;

    public bool animate = false;
    public bool animating = false;
    public bool noAnim = false;

    bool down = true;
    bool triggeru = false;
    bool triggerd = false;
    bool trigger2 = false;

    private void Start()
    {
        if (invert)
            down = false;
    }


    // Update is called once per frame
    void FixedUpdate () {

        
        if (Input.GetKeyDown("p"))
        {
            
        }

        if(Input.GetKeyDown("l"))
        {
            noAnim = !noAnim;
        }
        

        if (animate)
        {
            if (invert)
            {
                transform.Rotate(0, 1f, 0, Space.World);
                if (transform.rotation.y == 0 || transform.rotation.y > 0)
                {
                    transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
                    animating = !animating;
                    animate = false;
                }
            }
            else
            {
                transform.Rotate(-0,-1f, 0, Space.World);
                if (transform.rotation.y == 0 || transform.rotation.y < 0)
                {
                    transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
                    animating = !animating;
                    animate = false;
                }
            }            
        }

        if (!noAnim)
            animating = true;
                
        if (animating)
        {
            if (invert)
            {
                Up = InUp * -1;
                NotUp = InNotUp * -1;
            }
            else
            {
                Up = InUp;
                NotUp = InNotUp;
            }


            if (transform.rotation.x > Up)
                down = true;
            if (transform.rotation.x < NotUp)
                down = false;

            if (down)
                transform.Rotate(Time.deltaTime * speed, 0, 0, Space.Self);
            else
                transform.Rotate(Time.deltaTime * -1 * speed, 0, 0, Space.Self);
            if(!noAnim)
            {
                triggeru = false;
                triggerd = false;
                trigger2 = false;
            }

            if (noAnim)
            {
                if (transform.rotation.x < 0.003f )
                {
                    if (!triggeru)
                    {
                        triggeru = true;
                    }
                    if(triggerd)
                        trigger2 = true;
                        
                }
                if (transform.rotation.x > -0.003f)
                {
                    if (!triggerd)
                    {
                        triggerd = true;
                    }
                    if (triggeru)
                        trigger2 = true;
                }

                if (trigger2)
                {
                    
                    {
                        transform.rotation = new Quaternion(0, 0, transform.rotation.z, transform.rotation.w);
                        animating = !animating;
                    }
                }
            }

        }
    }
}
