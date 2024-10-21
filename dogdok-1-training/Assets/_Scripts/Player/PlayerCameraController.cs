using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public GameObject PlayerBody;

    public float HorizontalSensitivity;
    public float VerticalSensitivity;

    float mouseDeltaX;
    float mouseDeltaY;

    float rotationX;

    private void Update()
    {
        mouseDeltaX = Input.GetAxis("Mouse X");
        mouseDeltaY = Input.GetAxis("Mouse Y");

        Vector3 bodyRotation = new Vector3(0f, mouseDeltaX * HorizontalSensitivity, 0f);
        Vector3 rotation = new Vector3(-mouseDeltaY * VerticalSensitivity, 0f, 0f);

        float newRotationX = rotationX + rotation.x;
        if (newRotationX > 90f)
        {
            newRotationX = 90f;
            return;
        }

        else if (newRotationX < -90f)
        {
            newRotationX = -90f;
            return;
        }

        rotationX = newRotationX;

        transform.Rotate(rotation);
        PlayerBody.transform.Rotate(bodyRotation);
    }
}
