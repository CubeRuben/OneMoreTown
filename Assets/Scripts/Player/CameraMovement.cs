using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5.0f;
    [SerializeField] private float _interpolationSpeed = 1.0f;
    [SerializeField] private Vector3 _targetLocation;

    private CameraArm cameraArm;

    private void Start()
    {
        _targetLocation = transform.position;

        cameraArm = GetComponentInChildren<CameraArm>();
    }

    private void Update()
    {
        //Read player input
        Vector3 inputDelta = Input.GetAxis("Vertical") * transform.forward + Input.GetAxis("Horizontal") * transform.right;
        inputDelta.y = 0.0f;

        _targetLocation += inputDelta.normalized * _movementSpeed * cameraArm.GetSpeedMultiplier() * Time.deltaTime;

        transform.position = Vector3.SlerpUnclamped(transform.position, _targetLocation, _interpolationSpeed * Time.deltaTime);
    }
}
