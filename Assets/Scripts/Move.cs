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

    [Header("Attributes")]
    [SerializeField] private int speed;
    [SerializeField] private int jumpCounter;

    private Rigidbody2D _rb;
    private int _jumpCounter;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _jumpCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MoveAround();

        Flip();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _jumpCounter = jumpCounter;
    }

    private void MoveAround()
    {
        if (Input.GetKeyDown(jumpKey) && _jumpCounter > 0)
        {
            _rb.velocity = new(_rb.velocity.x, 12);
            _jumpCounter--;
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

    private void Flip()
    {
        if ((isFacingRight && Input.GetKeyDown(leftKey)) || (!isFacingRight && Input.GetKeyDown(rightKey)))
        {
            isFacingRight = !isFacingRight;
            gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
    }
}
