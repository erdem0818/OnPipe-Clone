using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public enum States
{
    moving,stopped
}
public class PlayerMove : BasedObject
{   
   
    public States states;

    [SerializeField]
    private float _speed;
    
    [SerializeField]
    private Transform _rayOrigin;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private LayerMask layerMask;

    public override void BaseObjectStart()
    {
        states = States.moving;
    }
    public override void BaseObjectFixedUpdate()
    {
        if(states == States.moving)
        {
            transform.Translate(Vector3.forward * Time.fixedDeltaTime * _speed);
        }
        
        rayHit();
    }

    private void rayHit()
    {
        RaycastHit hitInfo;

        if(Physics.Raycast(_rayOrigin.position,Vector3.forward,out hitInfo,maxDistance,layerMask))
        {
            states = States.stopped;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Grain"))
        {
            Vector3 forceDirection = new Vector3(0f,5f,-2f);
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.AddForceAtPosition(forceDirection,other.transform.position,ForceMode.Impulse);
            rb.useGravity= true;  
        }
        else if(other.CompareTag("Cylinder"))
        {
            states = States.stopped;
            Debug.Log("yandın");
        }
    }
}
