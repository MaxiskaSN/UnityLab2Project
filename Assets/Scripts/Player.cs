using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float Jump;

    private Rigidbody _rigidbody;
    private float moveForward;
    private float moveSide;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, Jump, _rigidbody.velocity.x);
            }
        }

        //Left Right Movement

        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        var camera = Camera.main;

        //camera forward and right vectors:
        var forward = camera.transform.forward;
        var right = camera.transform.right;

        //project forward and right vectors on the horizontal plane (y = 0)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        //this is the direction in the world space we want to move:
        var desiredMoveDirection = (forward * verticalAxis + right * horizontalAxis) * Speed;

        //now we can apply the movement:
        _rigidbody.velocity = new Vector3(desiredMoveDirection.x, _rigidbody.velocity.y, desiredMoveDirection.z);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {

        Debug.Log("OnCollisionExit");
        isGrounded = false;
    }
}
