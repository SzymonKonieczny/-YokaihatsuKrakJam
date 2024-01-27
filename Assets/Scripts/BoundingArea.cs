using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingArea
{
    Vector3 _Min, _Max;
    public BoundingArea(Vector3 Min, Vector3 Max) {
        _Min = Min;
        _Max = Max;
    }
    public BoundingArea(Transform Min, Transform Max)
    {
        _Min = Min.position;
        _Max = Max.position;
    }
    public Vector3 getRandomSpot()
    {
        return new Vector3(Random.Range(_Min.x, _Max.x),
            Random.Range(_Min.y, _Max.y),
            Random.Range(_Min.z, _Max.z));
    }

}
