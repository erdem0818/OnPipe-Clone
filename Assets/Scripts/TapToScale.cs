using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class TapToScale : BasedObject
{
    [SerializeField]
    private float _scaleRatio;

    float scaleX;
    float scaleY;

    float minScale;
    float maxScale;
    
    [SerializeField]
    bool isMouseUp=false;

    public override void BaseObjectStart()
    {
        minScale = 0.6f;
        maxScale = 1f;
    }
    public override void BaseObjectFixedUpdate()
    {
   
        ScaleObject(_scaleRatio);
        ChangeScaleMinAndMax();       
    }

    private void ScaleObject(float scaleRt)
    {
        if(Input.GetMouseButton(0))
        {       
            isMouseUp =false;
            if(!isMouseUp)
            {
                scaleX += scaleRt;
                scaleY += scaleRt;
            }
        }
        else
        {
            isMouseUp =true;
            if(isMouseUp)
            {
               scaleX -= scaleRt*3;
               scaleY -= scaleRt*3;
            }
        }
    }

    private void ChangeScaleMinAndMax()
    {
        scaleX = Mathf.Clamp(scaleX, minScale,maxScale);
        scaleY = Mathf.Clamp(scaleY, minScale,maxScale);

        transform.localScale = new Vector3(scaleX,scaleY,transform.localScale.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MinAndMaxData"))
        {
            MinAndMaxData minAndMaxData= other.GetComponent<MinAndMaxData>();

            minScale = minAndMaxData.minScaleData;
            maxScale = minAndMaxData.maxScaleData;

            Debug.Log(minScale +" "+ maxScale);
        }
    }

}
