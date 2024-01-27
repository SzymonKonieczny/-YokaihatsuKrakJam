using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    List<BoundingArea> Areas = new List<BoundingArea>();
   public List<Transform> TransformsAreas = new List<Transform>();
    public List<Vector2Int> ItemIDPairs = new List<Vector2Int>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < TransformsAreas.Count; i+=2)
        {
            Areas.Add(new BoundingArea(TransformsAreas[i], TransformsAreas[i + 1]));
        }
    }

    public Vector3 GetRandomTransform()
    {
        return Areas[Random.Range(0, Areas.Count - 1)].getRandomSpot();
    }
}
