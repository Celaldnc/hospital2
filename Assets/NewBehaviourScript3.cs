using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Karakterin hareket hýzý
    public float sensitivity = 2f; // Fare hassasiyeti
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Fare imlecini kilitler
        Cursor.visible = false; // Fare imlecini gizler
    }

    private void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 moveVector = transform.TransformDirection(moveDirection) * speed;

        characterController.Move(moveVector * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = -Input.GetAxis("Mouse Y") * sensitivity; // Y ekseninde ters hareket etmesi için "-" eklenmiþtir

        transform.Rotate(Vector3.up * mouseX); // Yatay eksende dönme (karakterin etrafýnda)
        Camera.main.transform.Rotate(Vector3.right * mouseY); // Dikey eksende dönme (kamera)
    }
}

