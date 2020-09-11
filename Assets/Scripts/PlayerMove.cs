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
    [SerializeField]
    States states;

    [SerializeField]
    private float _speed;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cylinder"))
        {
            states = States.stopped;
            Debug.Log("durdu");
        }
        else if(other.CompareTag("Grain"))
        {   
            Vector3 forceDirection = new Vector3(0f,1f,10f);
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.AddExplosionForce(10f,forceDirection,10f,10f,ForceMode.Impulse);
            rb.useGravity= true;     
        }
    }
}
