using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{


    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerCap;
    public Rigidbody rb;

    public Transform camera;


    public float rotationSpeed;

    [Header("Input")]
    public InputActionReference look;
    private Vector2 lookInput;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnEnable()
    {
        look.action.Enable();
    }

    void OnDisable()
    {
        look.action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // rotation orientation

        lookInput = look.action.ReadValue<Vector2>();

        if (lookInput.sqrMagnitude < 0.01f)
        {
            return;
        }

        Vector3 camForward = camera.forward;
        camForward.y = 0f; 
        camForward = camForward.normalized;

        Quaternion targetRot = Quaternion.LookRotation(camForward);

        player.rotation = Quaternion.Slerp(player.rotation, targetRot, Time.deltaTime * rotationSpeed);

       




        
    }
}
