using UnityEngine;
using UnityEngine.Events;
public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform BallAnchor;
    [SerializeField] private Transform launchIndicator;
    [SerializeField] private InputManager inputManager;
    private bool isBallLaunched;
    private Rigidbody ballRB;
    void Start()
    {
        //Grabbing a reference to RigidBody
        ballRB = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        // Add a listener to the OnSpacePressed event.
        // When the space key is pressed the
        // LaunchBall method will be called.
        inputManager.OnSpacePressed.AddListener(LaunchBall);

        //We bundle the last few lines of code relevant for
        //resetting the state into ResetBall() function
        ResetBall();

    }

    public void ResetBall()
    {
        isBallLaunched = false;

        // We are setting the ball to be a Kinematic Body
        ballRB.isKinematic = true;
        launchIndicator.gameObject.SetActive(true);
        transform.parent = BallAnchor;
        transform.localPosition = Vector3.zero;
    }

    private void LaunchBall()
    {
        // now your if check can be framed like a sentence
        //I "if ball is launched, then simply return and do nothing"
        if (isBallLaunched) return;
        // "now that the ball is not launched, set it to true and launch the ball"
        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;

        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);

        // ballRB.isKinematic = false;
        // // this sets the object to the outermost layer of the hierarchy
        // ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }

}