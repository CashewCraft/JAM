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

    bool down = true;

    private void Start()
    {
        if (invert)
            down = false;
    }


    // Update is called once per frame
    void FixedUpdate () {
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

    }
}
