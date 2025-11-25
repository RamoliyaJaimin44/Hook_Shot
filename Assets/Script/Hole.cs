using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Rigidbody ballRb = other.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                ballRb.velocity = Vector3.zero;
                ballRb.isKinematic = true;
            }

            BallController ballController = other.GetComponent<BallController>();
            if (ballController != null)
            {
                ballController.enabled = false;
            }

            Transform ballTransform = other.transform;
            ballTransform.position = new Vector3(transform.position.x, ballTransform.position.y, transform.position.z);

            Invoke(nameof(WinLevel), 0.3f);
        }
    }

    void WinLevel()
    {

        if (GameManager.Instance != null)
        {
            GameManager.Instance.WinGame();
        }
    }
}

