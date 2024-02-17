using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class CameraArm : MonoBehaviour
{
    [SerializeField] private float MinDistance = 1.0f;
    [SerializeField] private float MaxDistance = 15.0f;
    [SerializeField] private float Sensitivity = 4.0f;
    [SerializeField] private float LerpSpeed = 10.0f;

    [SerializeField] private Transform CameraTransform;

    [SerializeField] private float TargetDistance;

    public float GetSpeedMultiplier()
    {
        return 2.0f * TargetDistance / (MaxDistance - MinDistance) + 1.0f;
    }

    void Start()
    {
        TargetDistance = -CameraTransform.localPosition.z;
    }

    void Update()
    {
        //Read player input
        TargetDistance -= Input.GetAxis("Mouse ScrollWheel") * Sensitivity;
        TargetDistance = Mathf.Clamp(TargetDistance, MinDistance, MaxDistance);

        //Move to target location
        float newLength = Mathf.Lerp(-CameraTransform.localPosition.z, TargetDistance, LerpSpeed * Time.deltaTime);
        CameraTransform.localPosition = new Vector3(0, 0, -newLength);
    }
}
