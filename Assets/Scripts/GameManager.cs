using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    BasedObject[] _basedObjects;
    
    private void Awake()
    {
        SetUpBaseObjects();
        CallBaseObjectsAwake();
    }
    private void Start()
    {
        CallBaseObjectsStart();
    }
    private void Update()
    {
        CallBaseObjectsUpdate();
    }
    private void FixedUpdate()
    {
        CallBaseObjectsFixedUpdate();
    }
    private void LateUpdate()
    {
        CallBaseObjectsLateUpdate();
    }
    private void OnDestroy()
    {
        CallBaseObjectsOnDestroy();
    }
    private void SetUpBaseObjects()
    {
        _basedObjects = FindObjectsOfType<BasedObject>();
    }
    private void CallBaseObjectsAwake()
    {
        foreach (var e in _basedObjects)
        {
            e.BaseObjectAwake();
        }
    }
    private void CallBaseObjectsStart()
    {
        foreach (var e in _basedObjects)
        {
            e.BaseObjectStart();
        }
    }
    private void CallBaseObjectsUpdate()
    {
        foreach (var e in _basedObjects)
        {
            e.BaseObjectUpdate();
        }
    }
    private void CallBaseObjectsFixedUpdate()
    {
        foreach (var e in _basedObjects)
        {
            e.BaseObjectFixedUpdate();
        }
    }
    private void CallBaseObjectsLateUpdate()
    {
        foreach (var e in _basedObjects)
        {
            e.BaseObjectLateUpdate();
        }
    }
    private void CallBaseObjectsOnDestroy()
    {
        foreach (var e in _basedObjects)
        {
            e.BaseObjectOnDestroy();
        }
    }

}
