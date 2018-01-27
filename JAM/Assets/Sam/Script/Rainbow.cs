using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{


    SpriteRenderer rend;

    public float timePerColour = 1f;
    public float curTime;
    int curColourNum = 0;
    Color col1 = Color.red;
    Color col2 = Color.yellow;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        rend.color = Color32.Lerp(col1, col2, curTime / timePerColour);
        if (curTime >= timePerColour)
        {
            curTime = 0;
            curColourNum++;
            if (curColourNum > 5)
                curColourNum = 0;
            switch (curColourNum.ToString())
            {
                case "0":
                    col1 = Color.red;
                    col2 = Color.yellow;
                    break;
                case "1":
                    col1 = Color.yellow;
                    col2 = Color.green;
                    break;
                case "2":
                    col1 = Color.green;
                    col2 = Color.cyan;
                    break;
                case "3":
                    col1 = Color.cyan;
                    col2 = Color.blue;
                    break;
                case "4":
                    col1 = Color.blue;
                    col2 = Color.magenta;
                    break;
                case "5":
                    col1 = Color.magenta;
                    col2 = Color.red;
                    break;
            }
        }
    }
}
