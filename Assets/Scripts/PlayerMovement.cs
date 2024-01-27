using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] public KeyCode upKey;
    [SerializeField] public KeyCode downKey;
    [SerializeField] public KeyCode leftKey;
    [SerializeField] public KeyCode rightKey;

    void Update()
    {
        // Pobierz wektory kierunku ruchu dla obu graczy
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(upKey))
            movement += Vector3.up;
        if (Input.GetKey(downKey))
            movement += Vector3.down;
        if (Input.GetKey(leftKey))
            movement += Vector3.left;
        if (Input.GetKey(rightKey))
            movement += Vector3.right;

        // Normalizuj wektor, aby uniknąć ruchu skośnego z większą prędkością
        movement = movement.normalized * speed * Time.deltaTime;

        // Przesuń gracza
        transform.Translate(movement);
    }
}
