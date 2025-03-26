using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.01f;
    private Rigidbody rb;
    public Vector3 moveDirection;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(moveDirection * speed, ForceMode.Force);
    }
}
