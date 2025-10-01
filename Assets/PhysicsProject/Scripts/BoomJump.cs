using UnityEngine;

public class BoomJump : MonoBehaviour
{

    public Rigidbody rb;

    public float explosionForce;
    public Vector3 explosionPosition;
    public float explosionRadius;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("bom");
            rb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
        }
    }
}
