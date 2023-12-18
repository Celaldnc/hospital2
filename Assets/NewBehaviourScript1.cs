using UnityEngine;

public class SimpleFPSMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    void Update()
    {
        // Klavye giri�lerini al
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        // Hareket vekt�r�n� olu�tur
        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);

        // Hareket vekt�r�n� normalle�tir ve h�zla �arp
        movement.Normalize();
        movement *= moveSpeed * Time.deltaTime;

        // Karakteri hareket ettir
        transform.Translate(movement);
    }
}
