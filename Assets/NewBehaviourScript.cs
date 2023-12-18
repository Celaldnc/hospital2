using UnityEngine;

public class SimpleFPSController : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public float moveSpeed = 5f;
    public float sensitivity = 2f;

    private float rotationX = 0f;

    private void Update()
    {
        // Kamerayý döndürme ve karakteri hareket ettirme
        RotateCamera();

    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Yatay (sol/sað) dönüþü saðla
        transform.Rotate(Vector3.up * mouseX);

        // Dikey (yukarý/aþaðý) dönüþü sýnýrla
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Kamerayý ve karakteri döndür
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }


}
