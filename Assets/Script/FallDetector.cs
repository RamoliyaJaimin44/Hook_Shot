using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    private int hitCount = 0;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitCount++;

            if (hitCount == 1)
            {
                if (meshRenderer != null)
                {
                    meshRenderer.enabled = false;
                    AudioManager.Instance.CollideSound();
                }
            }
            else if (hitCount >= 2)
            {

                if (GameManager.Instance != null)
                {
                    GameManager.Instance.LoseGame();
                    AudioManager.Instance.CollideSound();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {

            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoseGame();
                AudioManager.Instance.CollideSound();
            }
        }
    }
}
