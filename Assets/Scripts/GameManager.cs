using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    #region Variables
    public static GameManager Instance;

    [SerializeField] public List<Room> generatedRooms;
    [SerializeField] private float playerWallet = 100;
    [SerializeField] private float playerHappiness = 0;
    [SerializeField] private TextMeshProUGUI walletText;
    [SerializeField] private TextMeshProUGUI happinessText;
    public float PlayerWallet
    {
        get => playerWallet;
        set
        {
            playerWallet = value;
        }
    } 
    public float PlayerHappiness
    {
        get => playerHappiness;
        set
        {
            playerHappiness = value;
        }
    }
    #endregion


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }


    void Update()
    {
        UpdateCanvas();

        if (!CheckGameEnded())
        {
           //game end screen
        }
    }

    /// <summary>
    /// This method deducts the room's cost from the wallet and adds the generated room to the list
    /// </summary>
    public void AddRooms(GameObject room)
    {
        playerWallet -= room.GetComponent<Room>().Cost;
        generatedRooms.Add(room.GetComponent<Room>());
    }

    private void UpdateCanvas()
    {
        walletText.text = playerWallet.ToString(format: "$0");
        happinessText.text = playerHappiness.ToString();
    }

    /// <summary>
    /// If the overall happiness is less than or equals -75 the game ends
    /// </summary>
    public bool CheckGameEnded()
    {
        if (playerHappiness <= -75)
        {
            return true;
        }
        return false;
    }
}
