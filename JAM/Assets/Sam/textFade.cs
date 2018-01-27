using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textFade : MonoBehaviour {

    bool starting = false;
    byte time = 0;
	// Update is called once per frame
	void Update () {
        time = (byte)Mathf.Clamp(time + (byte)(Time.deltaTime),(byte) 0,(byte) 255);
		if (starting)
        {
            GetComponent<TMPro.TextMeshPro>().faceColor = new Color32(GetComponent<TMPro.TextMeshPro>().faceColor.r, GetComponent<TMPro.TextMeshPro>().faceColor.b, GetComponent<TMPro.TextMeshPro>().faceColor.g, time);
        }
	}

    void OnPreRender()
    {
        starting = true;
    }
}
