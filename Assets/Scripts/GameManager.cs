using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float TimePassed = 0;
    [SerializeField] UnitManager unitManager;
    public static GameManager Instance { get; private set; }
    public ItemsContainer ItemsContainer;
    public List<NPC_SO> NPCDataContainer = new List<NPC_SO>();
    public List<Transform> DestinationPoints = new List<Transform>();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Update()
    {
        TimePassed += Time.deltaTime;

        if((int)TimePassed % 30 == 0)
        {
            unitManager.SpawnNPC();
            unitManager.SpawnNPC();
            TimePassed += 1;

        }
        if ((int)TimePassed % 15 == 0)
        {
            TimePassed += 1;
            unitManager.SpawnItemPair();
            unitManager.SpawnItemPair();

        }
    }

}
