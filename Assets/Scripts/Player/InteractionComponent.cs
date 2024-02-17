using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class InteractionComponent : MonoBehaviour
{
    private Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact")) 
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out hit))
                return;

            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable == null)
                return;

            interactable.Interact();
        }
    }
}
