using UnityEngine;

public class FPSTarget : MonoBehaviour
{
    public int MaxFPS = 30;

    void Start()
    {
        Application.targetFrameRate = MaxFPS;
    }
}
