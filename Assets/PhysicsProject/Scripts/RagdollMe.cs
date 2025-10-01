using System;
using System.Collections.Generic;
using UnityEngine;

public class RagdollMe : MonoBehaviour
{
    private Joint[] joints;
    private Dictionary<Joint, float> previousForce;
    public float totalScore;

    private void Awake()
    {
        SetChildColliders(false);
        SetChildRigidBodies(false, Vector3.zero);

        joints = GetComponentsInChildren<Joint>();
        previousForce = new Dictionary<Joint, float>();
        foreach (var joint in joints)
        {
            previousForce.Add(joint, joint.currentForce.magnitude);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            var force = GetComponent<Rigidbody>().linearVelocity;
            
            SetChildColliders(true);
            SetChildRigidBodies(true, force);

            GetComponent<PlayerMovement>().enabled = false;
        }
    }

    private void FixedUpdate()
    {
        foreach (var joint in joints)
        {
            float lastForce = previousForce[joint];
            float difference = Mathf.Abs(lastForce - joint.currentForce.magnitude);
            previousForce[joint] = joint.currentForce.magnitude;
            
            if(difference > 1000) totalScore += difference;
        }
    }

    void SetChildColliders(bool enabled)
    {
        var currentCollider = GetComponent<Collider>();
        currentCollider.enabled = !enabled;
        foreach (var collider in GetComponentsInChildren<Collider>())
        {
            if (collider != currentCollider)
            {
                collider.enabled = enabled;
            }
        }
    }
    
    void SetChildRigidBodies(bool enabled, Vector3 force)
    {
        var currentRB = GetComponent<Rigidbody>();
        currentRB.isKinematic = enabled;
        Vector3 forcePerRB = force;
        foreach (var rb in GetComponentsInChildren<Rigidbody>())
        {
            if (rb != currentRB)
            {
                rb.isKinematic = !enabled;
                rb.linearVelocity = forcePerRB;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RagdollWall"))
        {
            var force = GetComponent<Rigidbody>().linearVelocity;
            
            SetChildColliders(true);
            SetChildRigidBodies(true, force);

            GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
