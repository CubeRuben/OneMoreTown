using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float MaxMovementSpeed;
    [SerializeField] private float Friction;

    private Vector3 MovementVelocity;

    private CameraArm CameraArm;

    private void Start()
    {
        MovementVelocity = Vector3.zero;

        CameraArm = GetComponentInChildren<CameraArm>();
    }

    private void Update()
    {
        //Read player input
        Vector3 inputDelta = Input.GetAxis("Vertical") * transform.forward + Input.GetAxis("Horizontal") * transform.right;
        inputDelta.y = 0.0f;
        
        //Apply friction if no player input
        if (inputDelta.sqrMagnitude <= 0.1)
        {
            MovementVelocity -= MovementVelocity.normalized * Friction * Time.deltaTime;

            if (MovementVelocity.sqrMagnitude <= 0.001) 
            {
                MovementVelocity = Vector3.zero;
            } 
        }
        //Apply acceleration if have player input
        else
        {
            MovementVelocity = inputDelta.normalized * MaxMovementSpeed * CameraArm.GetMaxSpeedMultiplier();
        }
        
        //Apply velocity
        transform.position += MovementVelocity * Time.deltaTime;
    }
}
