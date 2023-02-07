using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Models;

public class Player : MonoBehaviour
{
    private CharacterController characterController;
    private DefaultInput defaultInput;
    public Vector2 input_Movement;
    public Vector2 input_View;

    private Vector3 newCameraRotation;
    private Vector3 newPlayerRotation;

    [Header("References")]
    public Transform cameraHolder;

    [Header("Settings")]
    public PlayerSettingsModel playerSettings;
    public float viewClampYMin = -70;
    public float viewClampYMax = 80;

    // Start is called before the first frame update
    private void Awake()
    {
        defaultInput = new DefaultInput();

        defaultInput.Player.Movement.performed += e => input_Movement = e.ReadValue<Vector2>();
        defaultInput.Player.View.performed += e => input_View = e.ReadValue<Vector2>();

        defaultInput.Enable();

        newCameraRotation = cameraHolder.localRotation.eulerAngles;
        newPlayerRotation = transform.localRotation.eulerAngles;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        CalculateMovement();
        CalculateView();

    }

    private void CalculateMovement()
    {
        var verticalSpeed = playerSettings.ForwardSpeed *input_Movement.y * Time.deltaTime;
        var horizontalSpeed = playerSettings.StrafeSpeed *input_Movement.x * Time.deltaTime;


        var newMovementSpeed = new Vector3(horizontalSpeed, 0, verticalSpeed);
        newMovementSpeed = transform.TransformDirection(newMovementSpeed);

        characterController.Move(newMovementSpeed);
    }

    private void CalculateView()
    {
        newPlayerRotation.y += playerSettings.ViewXSensitivity *(playerSettings.ViewXInverted ? -input_View.x : input_View.x) * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(newPlayerRotation);

        newCameraRotation.x += playerSettings.ViewYSensitivity * (playerSettings.ViewYInverted ? input_View.y : -input_View.y) * Time.deltaTime;
        newCameraRotation.x = Mathf.Clamp(newCameraRotation.x, viewClampYMin, viewClampYMax);

        cameraHolder.localRotation = Quaternion.Euler(newCameraRotation);
    }
}
