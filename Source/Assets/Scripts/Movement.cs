using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    Vector3 velocity = Vector3.zero;
    
    public Vector3 gravity;
    public Vector3 flapVelocity;

    public float maxSpeed;
    public float forwardSpeed;

    bool didFlap = false;




    // Use this for initialization
    void Start()
    {
    }

    // Do Graphic & Input updates here
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                didFlap = true;
            }
    }


    // Do physics engine updates here
    void FixedUpdate()
    {
        velocity.x = forwardSpeed;
        velocity += gravity * Time.deltaTime;

        if (didFlap)
        {
            didFlap = false;
            velocity += flapVelocity;
        }
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.position += velocity * Time.deltaTime;
    }
}
