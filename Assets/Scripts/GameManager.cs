using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float TimePassed = 0;
    UnitManager unitManager;
    public static GameManager Instance { get; private set; }
    public ItemsContainer ItemsContainer;
    public List<NPC_SO> NPCDataContainer = new List<NPC_SO>();
    public List<Transform> DestinationPoints = new List<Transform>();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        unitManager = FindObjectOfType<UnitManager>();
    }
    private void Start()
    {
        HappinessController.Instance.GameOver += OnGameOver;

    }

    private void OnDestroy()
    {
        HappinessController.Instance.GameOver -= OnGameOver;
    }

    private void OnGameOver(HappinessInfluence result)
    {
        switch (result)
        {
            case HappinessInfluence.Positive:
                SceneManager.LoadScene("goodEnding");
                break;
            case HappinessInfluence.Negative:
                SceneManager.LoadScene("badEndingScrne");
                break;
        }
    }

    private void Update()
    {
        TimePassed += Time.deltaTime;

        if((int)TimePassed % 20 == 0)
        {
            unitManager.SpawnNPC();
            unitManager.SpawnNPC();
            unitManager.SpawnNPC();
            unitManager.SpawnNPC();
            unitManager.SpawnNPC();
            unitManager.SpawnNPC();

            TimePassed += 1;

        }
        if ((int)TimePassed % 10 == 0)
        {
            TimePassed += 1;
            unitManager.SpawnItemPair();
            unitManager.SpawnItemPair();
            unitManager.SpawnItemPair();
            unitManager.SpawnItemPair();
            unitManager.SpawnItemPair();
            unitManager.SpawnItemPair();

        }
    }

}
