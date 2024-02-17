using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class CameraArm : MonoBehaviour
{
    [SerializeField] private float _minDistance = 1.0f;
    [SerializeField] private float _maxDistance = 15.0f;
    [SerializeField] private float _sensitivity = 4.0f;
    [SerializeField] private float _lerpSpeed = 10.0f;

    [SerializeField] private Transform _cameraTransform;

    [SerializeField] private float TargetDistance;

    public float GetSpeedMultiplier()
    {
        return 2.0f * TargetDistance / (_maxDistance - _minDistance) + 1.0f;
    }

    void Start()
    {
        TargetDistance = -_cameraTransform.localPosition.z;
    }

    void Update()
    {
        //Read player input
        TargetDistance -= Input.GetAxis("Mouse ScrollWheel") * _sensitivity;
        TargetDistance = Mathf.Clamp(TargetDistance, _minDistance, _maxDistance);

        //Move to target location
        float newLength = Mathf.Lerp(-_cameraTransform.localPosition.z, TargetDistance, _lerpSpeed * Time.deltaTime);
        _cameraTransform.localPosition = new Vector3(0, 0, -newLength);
    }
}
