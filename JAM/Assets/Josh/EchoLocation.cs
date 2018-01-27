using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoLocation : MonoBehaviour {

    public float sprayArc = 0.5f; //The radius of the arc we fire the echo through in radians (0.5 = 90 degrees)
    public float resolution = 0.005f; //How many radians between each blob?

    public GameObject Blep;

    public float maxRange = 10; //The maximum range of the raycast 

    private float Timer;
    public float TimeLimiter = 2;

    public float PulseSpeed;
    private float Pulse;
    private bool Pulsing;

    public GameObject item;

    private float Rotlock;
    private Vector2 PingPoint;

	public float getThumbAng()
    {
        Vector2 LookAt = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            return Rotlock;
        }
        else
        {
            return Mathf.Atan2(LookAt.y, LookAt.x);
        }
    }

    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

        if (Pulsing)
        {
            for (float i = 0; i < sprayArc; i += resolution)
            {
                Vector2 ToPos = new Vector2(Mathf.Cos(((-(sprayArc / 2)) + i) + Rotlock) * Pulse + PingPoint.x, Mathf.Sin(((-(sprayArc / 2)) + i) + Rotlock) * Pulse + PingPoint.y);
                Debug.DrawRay(PingPoint, ToPos);
                RaycastHit2D hit = Physics2D.Raycast(PingPoint, ToPos, Pulse);

                if (hit.collider)
                {
                    Instantiate(Blep, hit.point, new Quaternion(), null);
                }
            }
            item.transform.localScale = new Vector3(Pulse*2, Pulse*2, 0);
            item.transform.rotation = Quaternion.Euler(0, 0, (Mathf.Rad2Deg * Rotlock)-45);
            Pulse += PulseSpeed;
            if (Pulse >= maxRange) { Pulsing = false; Pulse = 0; item.transform.localScale = new Vector3(0, 0, 0); }
        }

        if (Timer <= 0)
        {
            Pulsing = true;
            Timer = TimeLimiter;
            PingPoint = transform.position;
            Rotlock = getThumbAng();
        }
        else if (!Pulsing)
        {
            Timer -= Time.deltaTime;
        }
	}
}
