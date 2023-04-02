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
            UpdateCanvas();
        }
    } 
    public float PlayerHappiness
    {
        get => playerHappiness;
        set
        {
            playerHappiness = value;
            UpdateCanvas();
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCanvas();
       

        if (!CheckGameEnded())
        {
           
        }
    }

    public void AddRooms(GameObject room)
    {
        playerWallet -= room.GetComponent<Room>().Cost;
        generatedRooms.Add(room.GetComponent<Room>());
    }

    private void UpdateCanvas()
    {
        walletText.text = playerWallet.ToString(format: "$00");
        happinessText.text = playerHappiness.ToString();
    }

    public void RemoveLastRoom()
    {
        if(generatedRooms.Count > 0)
            generatedRooms.RemoveAt(generatedRooms.Count-1);
    }

    public bool CheckGameEnded()
    {
        if (playerHappiness <= -75)
        {
            return true;
        }
        return false;
    }
}
