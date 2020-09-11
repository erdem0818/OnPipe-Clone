using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class PlayerMove : BasedObject
{
    [SerializeField]
    private float _speed; 

    public override void BaseObjectFixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * _speed);
    }
}
