using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float destroyTime;
    [SerializeField] private Rigidbody rb;
    
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector3(0, 0, rb.linearVelocity.z * moveSpeed);

        for (int i = 0; i < 5; i++)
        {
            Debug.Log(i);
        }
    }
}
