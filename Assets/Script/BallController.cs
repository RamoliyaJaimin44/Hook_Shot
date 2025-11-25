using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float rotationSpeed = 180f;
    public float moveForce = 8f;

    private Rigidbody rb;
    private bool canMove = true;
    private LineRenderer lineRenderer;
    public float lineLength = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();

        rb.freezeRotation = true;
    }

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver())
        {
            return;
        }

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        DrawDirectionLine();

        if (Input.GetMouseButtonDown(0))
        {
            MoveForward();
        }
    }

    void DrawDirectionLine()
    {
        Vector3 start = transform.position;
        Vector3 direction = transform.forward;
        float maxDistance = lineLength;

        RaycastHit hit;

        if (Physics.Raycast(start, direction, out hit, maxDistance))
        {
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            Vector3 end = start + direction * maxDistance;
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end);
        }
    }

    void MoveForward()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.forward * moveForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        StopBall();
    }

    private void StopBall()
    {
        rb.velocity = Vector3.zero;
    }
}

