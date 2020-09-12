using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class LevelGenerator : BasedObject
{
   [SerializeField]
   private GameObject[] _cylinders;

   private float _distanceBtwCylinders;

    public override void BaseObjectStart()
    {
        Vector3 startPos = new Vector3(0f,0f,4f);

        for(int i =0; i<10; i++)
        {
            int random = Random.Range(0,2);
            GameObject cloneCylinder = Instantiate(_cylinders[random],startPos, _cylinders[random].transform.rotation);

            startPos += new Vector3(0f,0f,4f);
        }
    }
}
