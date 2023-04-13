using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 10;
    public float pitchRate = 10;
    public float yawRate = 10;

    public float yawInput;
    public float pitchInput;
    public float headingInput;
    public float moveInput;
    public bool lockHeading = true;

    public GameObject head;     // Main camera

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Yaw & pitch are applied to the head (camera).
        yawInput = Input.GetAxis("Yaw");
        pitchInput = Input.GetAxis("Pitch");
        headingInput = Input.GetAxis("Heading");
        moveInput = Input.GetAxis("Movement");

        // Apply yaw and movement to the body so that we move in the direction that
        // we are looking (yaw could be split into two controlls to allow us to
        // separate control of where we are looking and how we move).
        if (lockHeading)
        {
            // Move in the same direction we're facing.
            transform.Rotate(Vector3.up, yawInput * yawRate * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.up, headingInput * yawRate * Time.deltaTime);
        }
        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);
        

        // Pitch is only applied to the head -- this may only matter if the
        // body is visible, but it prevents pitch from causing us to lean
        // forward or backward.
        head.transform.Rotate(Vector3.right, pitchInput * pitchRate * Time.deltaTime);
        if (!lockHeading)
        {
            head.transform.Rotate(Vector3.up, yawInput * yawRate * Time.deltaTime);
        }
    }
}
