using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caretaker : MonoBehaviour
{
    #region fields
    public Vector3 direction;
    public float speed;
    public Rigidbody rb;
    #endregion

    void Start()
    {
        
    }

    void Update()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(direction.x * speed, 0, direction.z * speed);
    }
}
