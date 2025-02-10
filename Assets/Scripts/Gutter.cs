using UnityEngine;
public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggeredBody)
    {
        // Check if the collided object has the tag "Ball"
        if (!triggeredBody.CompareTag("Ball")) return;

        // We first get the rigidbody of the ball
        // and store it in a local variable baltRigidBody
        Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();

        if (ballRigidBody == null) return; // Ensure the object has a Rigidbody

        // We store the velocity magnitude before resetting the velocity
        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;

        // It is important to reset the linear AND angular velocity
        // This is because the ball is rotating on the ground when moving
        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;

        //Now we add force in the forward direction of the gutter
        //We use the cached velocity magnitude to keep it a little realistic
        ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);
    }
}