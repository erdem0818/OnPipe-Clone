using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
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
    

    public event UnityAction OnFinishTriggerEnter;

    public override void BaseObjectStart()
    {
        _offset = transform.position - _target.transform.position;
   
        cam = Cam.follow;

        OnFinishTriggerEnter +=StopCameraFollow;
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
        OnFinishTriggerEnter -=StopCameraFollow;
    }

    private void StopCameraFollow()
    {
        cam = Cam.notFollow;
    }
    
    public void FinishTriggerEnter()
    {
        if(OnFinishTriggerEnter != null)
        {
            OnFinishTriggerEnter();
        }
    }
}
