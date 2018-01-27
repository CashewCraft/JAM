using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularQueue
{/*
    public object[] main;
    private int filled;

    CircularQueue(int Len)
    {
        main = new object[Len];
    }

    public void Add(object item)
    {
        if (filled < main.Length)
        {
            main[filled++] = item;
        }
    }

    public object cycle()
    {
        object temp = main[0];
        for (int i = main.Length-1; i > 0; i--)
        {
            main[i-1] = main[i];
        }
        main[main.Length - 1] = temp;
        return temp;
    }

    public object peekNext()
    {
        return main[1];
    }

    public object peek()
    {
        return main[0];
    }
}

public class Walls : MonoBehaviour {

    public static CircularQueue Nodes = new CircularQueue(transform.childCount);
	
	void Start () {
		foreach (Transform i in transform)
        {
            Nodes.Add(i.position);
        }
	}
	
	void Update () {
        for (int i = 0; i < Nodes.Count-1; i++)
        {
            Debug.DrawLine(Nodes[i], Nodes[i + 1]);
        }
	}

    public static Vector2 Intersects(Vector2 p1, Vector2 p2, out int I)
    {
        for (int i = 0; i < Nodes.Count - 1; i++)
        {
            Vector2 p3 = Nodes[i];
            Vector2 p4 = Nodes[i+1];

            float delta = (p1.y - p2.y) * (p4.x - p3.x) - (p3.y - p4.y) * (p2.x - p1.x);
            if (delta == 0)
            {
                continue;
            }

            float x = ((p4.x - p3.x) * -(p1.x * p2.y - p2.x* p1.y) - (p2.x - p1.x) * -(p3.x * p4.y - p4.x* p3.y)) / delta;
            float y = ((p1.y - p2.y) * -(p3.x * p4.y - p4.x * p3.y) - (p3.y - p4.y) * -(p1.x * p2.y - p2.x * p1.y)) / delta;

            I = i;

            return Vector2(x, y);
        }
        return null;
    }

    static void Draw(int SI, Vector2 p1, int EI, Vector2 p2)
    {
        List<Vector2> N = OrganiseNodes(SI, EI);

        for (int i = SI; i < EI; i++)
        {
            if (i == SI)
            {
                Debug.DrawLine(p1, N[i + 1]);
            }
            else if (i == EI)
            {
                Debug.DrawLine(N[i], p2);
            }
            else
            {
                Debug.DrawLine(N[i], N[i + 1]);
            }
        }
    }
*/}
