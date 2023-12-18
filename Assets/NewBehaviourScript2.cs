using UnityEngine;

public class SpotlightFollow : MonoBehaviour
{
    public Transform target; // Iþýðýn takip edeceði hedef (karakter)
    public float rotationSpeed = 5f;

    private Light spotlight;

    void Start()
    {
        // Spot ýþýðýn bileþenini al
        spotlight = GetComponent<Light>();

        // Hedefin atanýp atanmadýðýný kontrol et
        if (target == null)
        {
            Debug.LogError("SpotlightFollow scriptine bir hedef (target) atanmalýdýr.");
            return;
        }

        // Spot ýþýðýn ayarlarýný baþlat
        spotlight.type = LightType.Spot;
        spotlight.spotAngle = 45f;
        spotlight.intensity = 1.5f;
    }

    void Update()
    {
        // Hedefin pozisyonunu al
        Vector3 targetPosition = target.position;

        // Iþýðýn pozisyonunu hedefin pozisyonuna ayarla
        transform.position = targetPosition;

        // Hedefe doðru bakmasýný saðla
        Vector3 directionToTarget = (targetPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
