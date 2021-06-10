using UnityEngine;

public class DEBUG_OnCollision : MonoBehaviour
{ 
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter called");
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Stay called");
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit called");
    }

    void Start()
    {
        Debug.Log("DEBUG_OnCollision ");
    }
}
