using System;
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
    [SerializeField] public KeyCode jumpKey;
    [SerializeField] private Animator animator;
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private Rigidbody2D _rigidbody2D;
    private float _jumpTime = 0;

    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        stunTime -= Time.deltaTime;
        _jumpTime += Time.deltaTime;
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

        if (Input.GetKey(jumpKey) && _jumpTime > 5f)
        {
            _rigidbody2D.velocity = movement*15;
            _jumpTime = 0f;
        }

        animator.SetFloat(Horizontal, movement.x);
        animator.SetFloat(Vertical, movement.y);

        if (stunTime > 0) movement = new Vector3();

        movement = movement.normalized * speed * Time.deltaTime;

        transform.Translate(movement);
    }
}
