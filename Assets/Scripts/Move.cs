using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("Control Keys")]
    [SerializeField] private string jumpKey;
    [SerializeField] private string leftKey;
    [SerializeField] private string rightKey;
    [SerializeField] private string downKey;

    [Header("Statuses")]
    [SerializeField] private bool isFacingRight;
    [SerializeField] private bool isGrounded;

    [Header("Attributes")]
    [SerializeField] private int speed;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            _rb.velocity = new(_rb.velocity.x, 12);
        }

        if (Input.GetKey(leftKey))
        {
            _rb.velocity = new(-1 * speed, _rb.velocity.y);
        }

        if (Input.GetKey(rightKey))
        {
            _rb.velocity = new(speed, _rb.velocity.y);
        }
    }
}
