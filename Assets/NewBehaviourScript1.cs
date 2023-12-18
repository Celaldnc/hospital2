using UnityEngine;

public class SimpleFPSMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    void Update()
    {
        // Klavye giriþlerini al
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        // Hareket vektörünü oluþtur
        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);

        // Hareket vektörünü normalleþtir ve hýzla çarp
        movement.Normalize();
        movement *= moveSpeed * Time.deltaTime;

        // Karakteri hareket ettir
        transform.Translate(movement);
    }
}
