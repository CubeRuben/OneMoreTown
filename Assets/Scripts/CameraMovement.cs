using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float MaxMovementSpeed;
    [SerializeField] private float Acceleration;
    [SerializeField] private float Friction;

    private Vector3 MovementVelocity;

    private void Start()
    {
        MovementVelocity = Vector3.zero;
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
            Vector3 movementDelta = inputDelta.normalized * Acceleration * Time.deltaTime;
            MovementVelocity += movementDelta;

            if (MovementVelocity.sqrMagnitude > Mathf.Pow(MaxMovementSpeed, 2)) 
            {
                MovementVelocity = MaxMovementSpeed * MovementVelocity.normalized;
            }
        }
        
        //Apply velocity
        transform.position += MovementVelocity * Time.deltaTime;
    }
}
