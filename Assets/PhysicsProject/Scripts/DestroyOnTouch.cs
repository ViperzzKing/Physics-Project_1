using System;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    [SerializeField] private LayerMask player;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == player)
        {
            Destroy(gameObject, 0.5f);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
