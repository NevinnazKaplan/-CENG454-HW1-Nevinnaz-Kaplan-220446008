// FlightController.cs
// CENG 454 – HW1
// Author: Nevinnaz Kaplan | Student ID: 220446008

using UnityEngine;
using UnityEngine.InputSystem;

public class FlightController : MonoBehaviour
{
    // public
    public float flySpeed = 15f;
    public float turnSpeed = 45f;

    private Rigidbody myRb;

    void Start()
    {
        // Rigidbody settings
        myRb = GetComponent<Rigidbody>();

        if (myRb != null)
        {
            myRb.useGravity = false; // No gravity
            myRb.freezeRotation = true; // Disable physics-based rotation so it is controlled by the user
        }
    }

    void Update()
    {
        // Unity 6 Input System control
        var currentKey = Keyboard.current;
        if (currentKey == null) return;

        // Checking inputs one by one (manual control instead of GetAxis)
        float pitchVal = 0;
        float yawVal = 0;
        float rollVal = 0;
        float moveForward = 0;

        // Pitch - up down arrow
        if (currentKey.upArrowKey.isPressed) pitchVal = 1;
        if (currentKey.downArrowKey.isPressed) pitchVal = -1;

        // Yaw - right left arrow
        if (currentKey.rightArrowKey.isPressed) yawVal = 1;
        if (currentKey.leftArrowKey.isPressed) yawVal = -1;

        // Roll - Q E Keys
        if (currentKey.qKey.isPressed) rollVal = 1;
        if (currentKey.eKey.isPressed) rollVal = -1;

        // Thrust - thrusting with space
        if (currentKey.spaceKey.isPressed) moveForward = 1;

        // --- MOVEMENT ---
        // Applying Time.deltaTime to the movement
        // Rotate the aircraft on its local axes
        transform.Rotate(Vector3.right * pitchVal * turnSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * yawVal * turnSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward * rollVal * turnSpeed * Time.deltaTime);

        // Move forward
        transform.Translate(Vector3.forward * moveForward * flySpeed * Time.deltaTime);
    }
}
