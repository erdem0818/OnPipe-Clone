using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class GrainGenerator : BasedObject
{
    [SerializeField]
    private GameObject _grains;

    Vector3 _grainPos;

    [SerializeField]
    private float grainYpos;

    private void OnEnable()
    {
        _grainPos = new Vector3(transform.position.x,grainYpos,(transform.position.z - 1f));
        generetaGrains();
    }
    public void generetaGrains()
    {
        int randomQueue = Random.Range(7,12);
        for(int i=0; i<randomQueue; i++)
        {
            GameObject grainsClone = Instantiate(_grains,_grainPos,_grains.transform.rotation);

            _grainPos += new Vector3(0f,0f,0.25f);
        }
    }

}
