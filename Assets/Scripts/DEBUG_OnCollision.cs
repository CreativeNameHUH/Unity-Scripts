using UnityEngine;

public class DEBUG_OnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter called");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Stay called");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit called");
    }

    private void Start()
    {
        Debug.Log("DEBUG_OnCollision ");
    }
}
