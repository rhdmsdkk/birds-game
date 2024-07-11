using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [Header("Aim Controls")]
    [SerializeField] private string aimUpKey;
    [SerializeField] private string aimDownKey;

    [Header("Bounds")]
    [SerializeField] private float upperBound = 60f;
    [SerializeField] private float lowerBound = -50f;

    [Header("Attributes")]
    [SerializeField] private float aimSpeed = 3.5f;

    void Update()
    {
        float zRotation = gameObject.transform.eulerAngles.z;

        if (zRotation > 180)
        {
            zRotation -= 360;
        }

        if (Input.GetKey(aimUpKey) && zRotation <= upperBound)
        {
            zRotation += aimSpeed;
            zRotation = Mathf.Clamp(zRotation, lowerBound, upperBound);
            gameObject.transform.eulerAngles = new Vector3(0, 0, zRotation);
        }

        if (Input.GetKey(aimDownKey) && zRotation >= lowerBound)
        {
            zRotation -= aimSpeed;
            zRotation = Mathf.Clamp(zRotation, lowerBound, upperBound);
            gameObject.transform.eulerAngles = new Vector3(0, 0, zRotation);
        }
    }
}
