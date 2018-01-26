using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoLocation : MonoBehaviour {

    public float sprayArc = 0.5f; //The radius of the arc we fire the echo through in radians (0.5 = 90 degrees)
    public float resolution = 0.005f; //How many radians between each blob?

    public GameObject Blep;

    private float maxRange = 10; //The maximum range of the raycast 

    private float Timer;
    public float TimeLimiter = 2;

    public float PulseSpeed;
    public float Pulse;
    public bool Pulsing;

    private float Rotlock;

	public float getThumbAng()
    {
        Vector2 LookAt = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        return Mathf.Atan2(LookAt.y, LookAt.x);
    }

    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, new Vector2(Mathf.Cos(((-(sprayArc / 2)) + 0) + getThumbAng()) * maxRange + transform.position.x, Mathf.Sin(((-(sprayArc / 2)) + 0) + getThumbAng()) * maxRange + transform.position.y));
        Debug.DrawRay(transform.position, new Vector2(Mathf.Cos(((-(sprayArc / 2)) + sprayArc) + getThumbAng()) * maxRange + transform.position.x, Mathf.Sin(((-(sprayArc / 2)) + sprayArc) + getThumbAng()) * maxRange + transform.position.y));

        if (Pulsing)
        {
            for (float i = 0; i < sprayArc; i += resolution)
            {
                Vector2 ToPos = new Vector2(Mathf.Cos(((-(sprayArc / 2)) + i) + getThumbAng()) * Pulse + transform.position.x, Mathf.Sin(((-(sprayArc / 2)) + i) + getThumbAng()) * Pulse + transform.position.y);
                Debug.DrawRay(transform.position, ToPos);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, ToPos, Pulse);

                if (hit.collider)
                {
                    Instantiate(Blep, hit.point, new Quaternion(), null);
                }
            }
            Pulse += PulseSpeed;
            if (Pulse >= maxRange) { Pulsing = false; Pulse = 0; }
        }

        if (Timer <= 0)
        {
            Pulsing = true;
            Timer = TimeLimiter;
        }
        else if (!Pulsing)
        {
            Timer -= Time.deltaTime;
        }
	}
}
