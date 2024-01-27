using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct ItemPair
{
public ItemID PositiveItem;
public ItemID NegativeItem;
}
public class UnitManager : MonoBehaviour
{
    List<BoundingArea> Areas = new List<BoundingArea>();
   public List<Transform> TransformsAreas = new List<Transform>();
    public List<ItemPair> ItemIDPairs = new List<ItemPair>();
    [SerializeField] GameObject ItemPrefab;
    [SerializeField] GameObject NPCPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < TransformsAreas.Count; i+=2)
        {
            Areas.Add(new BoundingArea(TransformsAreas[i], TransformsAreas[i + 1]));
        }
        SpawnItemPair();
        SpawnNPC();
    }
    public void SpawnNPC()
    {


        GameObject NpcGO = Instantiate(NPCPrefab);
        NpcGO.transform.position = GetRandomTransform();
        NPCScript NPC = NpcGO.GetComponent<NPCScript>();
        NPC.SetData(GameManager.Instance.NPCDataContainer[UnityEngine.Random.Range(0,
        GameManager.Instance.NPCDataContainer.Count-1)],Areas[UnityEngine.Random.Range(0,Areas.Count-1)]);



    }
    public void SpawnItemPair()
    {

        ItemPair ItemPair = ItemIDPairs[UnityEngine.Random.Range(0, ItemIDPairs.Count - 1)];

        GameObject Item1GO = Instantiate(ItemPrefab);
        Item1GO.transform.position = GetRandomTransform();
        ItemScript Item1 = Item1GO.GetComponent<ItemScript>();
        Item1.setItemData(ItemPair.PositiveItem);

        GameObject Item2GO = Instantiate(ItemPrefab);
        Item2GO.transform.position = GetRandomTransform();
        ItemScript Item2 = Item2GO.GetComponent<ItemScript>();
        Item2.setItemData(ItemPair.NegativeItem);

    }
    public Vector3 GetRandomTransform()
    {
        return Areas[UnityEngine.Random.Range(0, Areas.Count - 1)].getRandomSpot();
    }
}
