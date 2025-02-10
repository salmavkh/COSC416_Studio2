using System;
using UnityEngine;
using UnityEngine.Events;

public class FallTrigger : MonoBehaviour
{
    // Adding an OnPinFall public event in case any other object
    // needs to know whether a Pin has Fallen i.e. Our GameManager
    public UnityEvent OnPinFall = new();
    public bool isPinFallen = false;

    private void OnTriggerEnter(Collider triggeredObject)
    {

        // We can use the CompareTag() function
        // to compare the collided object's tag to a string
        // We also make sure that the OnPinFall is not invoked more than once
        // For example if a pin were to bounce off the ground and hit it twice
        if (triggeredObject.CompareTag("Ground") && !isPinFallen)
        {
            isPinFallen = true;
            OnPinFall?.Invoke();
            Debug.Log($"{gameObject.name} is fallen");

            // using $"..." is C#'s string formatting
            // similar to Python's f-string
            // or Java's String.format()
        }
    }
}
