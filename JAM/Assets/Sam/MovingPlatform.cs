using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public MoveType moveType;
    public float speed = 2f;
    public List<Transform> waypoints = new List<Transform>();
    int curPoint = 0;
    int totPoints;
    bool direction = false;

	// Use this for initialization
	void Start () {
        totPoints = waypoints.Count - 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Debug.Log(totPoints + " ---- " + curPoint);
        switch (moveType)
        {
            case (MoveType.abcabc):
                transform.position = Vector2.MoveTowards(transform.position, waypoints[curPoint].position, Time.fixedDeltaTime * 1f);
                if (Vector2.Distance(transform.position , waypoints[curPoint].position) < 0.5f)
                {
                    curPoint++;
                    if (curPoint > totPoints)
                        curPoint = 0;
                }
                break;

            case (MoveType.abcba):
                transform.position = Vector2.Lerp(transform.position, waypoints[curPoint].position, Time.fixedDeltaTime);
                if (Vector2.Distance(transform.position, waypoints[curPoint].position) < 0.1f)
                {
                  if (direction)
                    {
                        curPoint++;
                        if (curPoint >= totPoints)
                        {
                            direction = !direction;
                            curPoint = totPoints;
                        }
                    } else
                    {
                        curPoint--;
                        if (curPoint <= 0)
                        {
                            direction = !direction;
                            curPoint = 0;
                        }

                    }

                  
                }
                break;
            case (MoveType.random):
                break;
        }
	}

    public enum MoveType { abcba, abcabc, random}
}
