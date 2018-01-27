using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {


    GameController gameController;
  


    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Flight>() != null)
        {
            if (gameController.key > 0)
            {
                gameController.key--;
                Destroy(gameObject);
            }

        }
    }


}
