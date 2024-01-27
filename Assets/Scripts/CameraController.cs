using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float smoothSpeed = 0.125f;
    public float minOrthoSize = 5f;
    public float maxOrthoSize = 10f;
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;

    private Camera cameraComponent;

    private void Start()
    {
        cameraComponent = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (player1 != null && player2 != null)
        {
            // Oblicz odległość między graczami
            float distance = Vector3.Distance(player1.position, player2.position);

            // Oblicz nowy rozmiar orthographicSize w zależności od odległości
            float targetOrthoSize = Mathf.Clamp(distance / 2f, minOrthoSize, maxOrthoSize);

            // Płynne dostosowanie orthographicSize
            cameraComponent.orthographicSize = Mathf.Lerp(cameraComponent.orthographicSize, targetOrthoSize, smoothSpeed * Time.deltaTime);

            // Oblicz środek pomiędzy dwoma graczami
            Vector3 centerPoint = (player1.position + player2.position) / 2f;

            float clampedX = Mathf.Clamp(centerPoint.x, minX, maxX);
            float clampedY = Mathf.Clamp(centerPoint.y, minY, maxY);

            // Ustaw pozycję kamery na środek pomiędzy graczami, uwzględniając ograniczenia
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}
