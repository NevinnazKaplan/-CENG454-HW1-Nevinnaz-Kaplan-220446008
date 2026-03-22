// FlightController.cs
// CENG 454 – HW1: Sky-High Prototype
// Author: Nevinnaz Kaplan | Student ID: 220446008

using UnityEngine;
using UnityEngine.InputSystem; // Unity 6'da hata almamak için bu þart!

public class FlightController : MonoBehaviour
{
    [Header("Flight Parameters")]
    [SerializeField] private float pitchSpeed = 45f;
    [SerializeField] private float yawSpeed = 45f;
    [SerializeField] private float rollSpeed = 45f;
    [SerializeField] private float thrustSpeed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.freezeRotation = true;
            rb.useGravity = false;
        }
    }

    void Update()
    {
        HandleFlight();
    }

    private void HandleFlight()
    {
        // YENÝ SÝSTEM: Klavye kontrolü (Keyboard.current üzerinden)
        var kb = Keyboard.current;
        if (kb == null) return;

        float pitchInput = 0f;
        float yawInput = 0f;
        float rollInput = 0f;
        float thrustInput = 0f;

        // Pitch: Yukarý/Aþaðý Ok Tuþlarý
        if (kb.upArrowKey.isPressed) pitchInput = 1f;
        else if (kb.downArrowKey.isPressed) pitchInput = -1f;

        // Yaw: Sol/Sað Ok Tuþlarý
        if (kb.leftArrowKey.isPressed) yawInput = -1f;
        else if (kb.rightArrowKey.isPressed) yawInput = 1f;

        // Roll: Q ve E Tuþlarý
        if (kb.qKey.isPressed) rollInput = 1f;
        else if (kb.eKey.isPressed) rollInput = -1f;

        // Thrust: Space (Boþluk)
        if (kb.spaceKey.isPressed) thrustInput = 1f;

        // HAREKETLERÝ UYGULA
        // Pitch (X), Yaw (Y), Roll (Z) rotasyonlarý
        transform.Rotate(Vector3.right * pitchInput * pitchSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * yawInput * yawSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward * rollInput * rollSpeed * Time.deltaTime);

        // Ýleri gitme (Thrust)
        transform.Translate(Vector3.forward * thrustInput * thrustSpeed * Time.deltaTime);
    }
}