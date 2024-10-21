using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 RotateSpeeds;

    private void Update()
    {
        transform.Rotate(RotateSpeeds * Time.deltaTime, Space.Self);
    }
}
