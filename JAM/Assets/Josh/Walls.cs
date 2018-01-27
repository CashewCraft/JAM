using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

    public static List<Vector2> Nodes = new List<Vector2>();
	
	void Start () {
		foreach (Transform i in transform)
        {
            Nodes.Add(i.position);
        }
        Nodes.Add(transform.GetChild(0).position);
	}
	
	void Update () {
        for (int i = 0; i < Nodes.Count-1; i++)
        {
            Debug.DrawLine(Nodes[i], Nodes[i + 1]);
        }
	}

    public static int Intersects(Vector2 p1, Vector2 p2)
    {
        for (int i = 0; i < Nodes.Count - 1; i++)
        {
            if (ccw(p1, Nodes[i], Nodes[i+1]) != ccw(p2, Nodes[i], Nodes[i+1]) && ccw(p1, p2, Nodes[i]) != ccw(p1, p2, Nodes[i + 1]))
            {
                return i;
            }
        }
        return 0;//Changed null >>> 0
    }

    static bool ccw(Vector2 A, Vector2 B, Vector2 C) // Changed void >>>> bool
    {
        return (C.y - A.y) * (B.x - A.x) > (B.y - A.y) * (C.x - A.x);
    }

    static void Draw() { }//temp fix
}
