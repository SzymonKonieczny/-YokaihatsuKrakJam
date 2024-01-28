using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float stunTime = 0.0f;

    [SerializeField] public KeyCode upKey;
    [SerializeField] public KeyCode downKey;
    [SerializeField] public KeyCode leftKey;
    [SerializeField] public KeyCode rightKey;
    [SerializeField] private Animator animator;
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");

    void Update()
    {
        stunTime -= Time.deltaTime;
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(upKey))
        {
            movement += Vector3.up;
        }

        if (Input.GetKey(downKey))
        {
            movement += Vector3.down;
        }

        if (Input.GetKey(leftKey))
        {
            movement += Vector3.left;
        }

        if (Input.GetKey(rightKey))
        {
            movement += Vector3.right;
        }

        animator.SetFloat(Horizontal, movement.x);
        animator.SetFloat(Vertical, movement.y);

        if (stunTime > 0) movement = new Vector3();

        movement = movement.normalized * speed * Time.deltaTime;

        transform.Translate(movement);
    }
}
