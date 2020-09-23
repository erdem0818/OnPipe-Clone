using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleClass 
{
    private int _myAge=3;

    public int myAge
    {
        get 
        {
            return _myAge;
        }
        set
        {
            _myAge = value;
        }
    }
    
    //bu sınıftan oluşacak her yeni "instance" int parametresini girmek zorunda.
    public SampleClass(int age)
    {
        this._myAge =age;
    }
}
