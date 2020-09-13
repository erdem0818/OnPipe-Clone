using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class LevelGenerator : BasedObject
{
   [SerializeField]
   private GameObject _finishCylinder;
   [SerializeField]
   private GameObject[] _cylinders;

    public override void BaseObjectAwake()
    {
        Vector3 startPos = new Vector3(0f,0f,4f);

        for(int i =0; i<15; i++)
        {
            int random = Random.Range(0,5);
            GameObject cloneCylinder = Instantiate(_cylinders[random],startPos, _cylinders[random].transform.rotation);

            startPos += new Vector3(0f,0f,4f);
        }
        
        Vector3 finisPos = new Vector3(0f,0f,4f) + startPos;
        GameObject cloneFinish = Instantiate(_finishCylinder,finisPos,_finishCylinder.transform.rotation);
    }
}
