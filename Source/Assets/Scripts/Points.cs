using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Score.AddPoint();
        }
    }
}
