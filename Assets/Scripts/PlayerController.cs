using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : Variables
{
    /*public float PlayerSpeed = 2f;
    public float SprintSpeed = 4f;
    public float JumpForce = 10f;*/
    public bool IsGrounded = true;
    public Vector3 Jump;
    
    Rigidbody _rigidbody;

    void OnCollisionStay()
    {
        IsGrounded = true;
    }

    void OnCollisionExit()
    {
        IsGrounded = false;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Jump = new Vector3(0f, 500f, 0f);
    }
    void Update()
    {
        float xAxis = Input.GetAxis("X Axis");
        float zAxis = Input.GetAxis("Z Axis");
        const float yAxis = 0;

        Vector3 tVector3 = new Vector3(xAxis, yAxis, zAxis);

        if (Input.GetKey("left shift"))
        {
            tVector3 *= PlayerSprint * Time.deltaTime;
        }
        else
        {
            tVector3 *= PlayerSpeed * Time.deltaTime;
        }

        transform.Translate(tVector3);

        if (Input.GetKeyDown("space") && IsGrounded)
        {
            _rigidbody.AddForce(Jump * PlayerJump * Time.deltaTime, ForceMode.Impulse);
            IsGrounded = false;
        }

    }
}
