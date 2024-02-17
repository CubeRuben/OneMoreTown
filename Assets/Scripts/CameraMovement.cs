using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 5.0f;
    [SerializeField] private float InterpolationSpeed = 1.0f;
    [SerializeField] private Vector3 TargetLocation;

    private CameraArm CameraArm;

    private void Start()
    {
        TargetLocation = transform.position;

        CameraArm = GetComponentInChildren<CameraArm>();
    }

    private void Update()
    {
        //Read player input
        Vector3 inputDelta = Input.GetAxis("Vertical") * transform.forward + Input.GetAxis("Horizontal") * transform.right;
        inputDelta.y = 0.0f;

        TargetLocation += inputDelta.normalized * MovementSpeed * CameraArm.GetSpeedMultiplier() * Time.deltaTime;

        transform.position = Vector3.LerpUnclamped(transform.position, TargetLocation, InterpolationSpeed * Time.deltaTime);
    }
}
