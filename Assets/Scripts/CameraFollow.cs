using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class CameraFollow : BasedObject
{
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private float _smoothRatio;

    private Vector3 _offset;

    public override void BaseObjectStart()
    {
        _offset = transform.position - _target.transform.position;
    }

    public override void BaseObjectFixedUpdate()
    {
        Vector3 targetPos = _target.transform.position + _offset;
        Vector3 followVector = Vector3.Lerp(transform.position,targetPos,_smoothRatio);
        transform.position = followVector;
    }

    
}
