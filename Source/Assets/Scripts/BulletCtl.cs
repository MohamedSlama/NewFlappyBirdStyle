using UnityEngine;
using System.Collections;

public class BulletCtl : MonoBehaviour {

    public Vector2 speed;

    Rigidbody2D rg;

	// Use this for initialization
	void Start () {

        rg = GetComponent<Rigidbody2D>();
        rg.velocity = speed;
	}
	
	// Update is called once per frame
	void Update () {

        rg.velocity = speed;
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BOX"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Score.AddPoint();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
