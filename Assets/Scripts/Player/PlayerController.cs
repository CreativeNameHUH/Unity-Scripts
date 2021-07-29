using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : Variables
{
    public string GameOverScene = "GameOverScene";
    public bool IsGrounded = true;
    public Vector3 Jump;

    private Rigidbody _rigidbody;

    private void OnCollisionStay()
    {
        IsGrounded = true;
    }

    private void OnCollisionExit()
    {
        IsGrounded = false;
    }

    private void Start()
    {
        ResetVariables();
        _rigidbody = GetComponent<Rigidbody>();
        Jump = new Vector3(0f, 150f, 0f);
    }

    private void Update()
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
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PlayerPrefs.SetString("PlayerKills", PlayerTotalKills.ToString());
            SceneManager.LoadScene(GameOverScene);
        }
    }
}