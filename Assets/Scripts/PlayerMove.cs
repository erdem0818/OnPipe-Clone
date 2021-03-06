﻿using System.Collections;
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
    private CameraFollow cameraFollow;

    [SerializeField]
    sceneManager _sceneManager;

    [SerializeField]
    ScoreText scoreText;

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
            _sceneManager.GameOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Grain"))
        {
            scoreText.scoreChanged();
            Vector3 forceDirection = new Vector3(0f,5f,-2f);
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.AddForceAtPosition(forceDirection,other.transform.position,ForceMode.Impulse);
            rb.useGravity= true;  
        }
        else if(other.CompareTag("Cylinder"))
        {
            states = States.stopped;   
            _sceneManager.GameOver();   
        }
        else if(other.CompareTag("Finish"))
        {
            cameraFollow.onFinishTriggerEnter();
            _sceneManager.GameOver();
        }
    }
}
