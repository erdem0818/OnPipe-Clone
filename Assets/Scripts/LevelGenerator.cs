using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class LevelGenerator : BasedObject
{

   [SerializeField]
   private GameObject[] _cylinders;

    public override void BaseObjectAwake()
    {
        Vector3 startPos = new Vector3(0f,0f,4f);

        for(int i =0; i<10; i++)
        {
            int random = Random.Range(0,3);
            GameObject cloneCylinder = Instantiate(_cylinders[random],startPos, _cylinders[random].transform.rotation);

            startPos += new Vector3(0f,0f,4f);
        }
    }
}
