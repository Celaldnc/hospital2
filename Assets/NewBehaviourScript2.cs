using UnityEngine;

public class SpotlightFollow : MonoBehaviour
{
    public Transform target; // I����n takip edece�i hedef (karakter)
    public float rotationSpeed = 5f;

    private Light spotlight;

    void Start()
    {
        // Spot �����n bile�enini al
        spotlight = GetComponent<Light>();

        // Hedefin atan�p atanmad���n� kontrol et
        if (target == null)
        {
            Debug.LogError("SpotlightFollow scriptine bir hedef (target) atanmal�d�r.");
            return;
        }

        // Spot �����n ayarlar�n� ba�lat
        spotlight.type = LightType.Spot;
        spotlight.spotAngle = 45f;
        spotlight.intensity = 1.5f;
    }

    void Update()
    {
        // Hedefin pozisyonunu al
        Vector3 targetPosition = target.position;

        // I����n pozisyonunu hedefin pozisyonuna ayarla
        transform.position = targetPosition;

        // Hedefe do�ru bakmas�n� sa�la
        Vector3 directionToTarget = (targetPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
