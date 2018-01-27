using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int key = 0;
    public int checkpoint = 0;
    public List<Transform> checkpoints = new List<Transform>();


    public void Die(GameObject go)
    {
        go.transform.position = checkpoints[checkpoint].position;
    }

    public void SetCheck(Transform t)
    {
        int index = 0;
        foreach (Transform tr in checkpoints)
        {
            if (tr.position == t.position)
            {
                Debug.Log("CHECK " + index);
                checkpoint = index;
                break;
            }
            index++;
        }
    }
}
