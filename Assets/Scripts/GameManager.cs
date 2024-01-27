using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public ItemsContainer ItemsContainer;
    public List<NPC_SO> NPCDataContainer = new List<NPC_SO>();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
