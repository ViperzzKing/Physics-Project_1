using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 input;
    private Rigidbody rb;
    [SerializeField] private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0f,  Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        rb.AddForce(input * speed);
    }
}
