using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            AudioManager.Instance.CollideSound();
            Destroy(gameObject);
        }
    }
}
