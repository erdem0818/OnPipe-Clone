using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Base;

public enum Cam
{
    follow, notFollow
}
public class CameraFollow : BasedObject
{
    Cam cam;
     
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private float _smoothRatio;

    private Vector3 _offset;
    

    public event Action finishTriggerEnter;

    public override void BaseObjectStart()
    {
        _offset = transform.position - _target.transform.position;
   
        cam = Cam.follow;

        finishTriggerEnter +=StopCameraFollow;
    }

    public override void BaseObjectFixedUpdate()
    {
        if(cam == Cam.follow)
        {
            Vector3 targetPos = _target.transform.position + _offset;
            Vector3 followVector = Vector3.Lerp(transform.position,targetPos,_smoothRatio);
            transform.position = followVector;
        }
    }
    public override void BaseObjectOnDestroy()
    {
        finishTriggerEnter -=StopCameraFollow;
    }

    private void StopCameraFollow()
    {
        cam = Cam.notFollow;
    }
    
    public void onFinishTriggerEnter()
    {
        if(finishTriggerEnter != null)
        {
            finishTriggerEnter();
        }
    }
}
