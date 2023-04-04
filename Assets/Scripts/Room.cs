using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoomType
{
    Office,
    Restauraunt,
    Restroom,
    Lounge,
}


public class Room : MonoBehaviour
{

    #region Variables
    private LayerMask roomMask = (1 << 6);
    [SerializeField] private float timer;

    [Space]
    [Header("Stats:")]
    [SerializeField] protected float cost;
    [SerializeField] protected float value;
    [SerializeField] protected float happiness;
    [SerializeField] protected float frequency;

    [Space]
    [Header("Walls:")]
    [SerializeField] private GameObject rightWall;
    [SerializeField] private GameObject leftWall;
    [SerializeField] private GameObject rightDoorWall;
    [SerializeField] private GameObject leftDoorWall;
    [SerializeField] private RoomType roomType;
    public RoomType Type => roomType;
    public float Cost => cost;
    #endregion


    private void Start()
    {
        RoomMovement.PlaceRoomEvent += WallBehaviour;
    }

    /// <summary>
    /// Method to check to see what type of wall to add depending on what's next to the room
    /// A raycast is cast from each wall and checks to the left or right
    /// </summary>
    protected void WallBehaviour()
    {
        if (Physics.Raycast(rightWall.transform.position, Vector3.right, out RaycastHit hit, 0.1f, roomMask))
        {
           
            rightWall.SetActive(false);

            if (!hit.collider.GetComponent<Room>().Type.Equals(roomType))
            {
                rightDoorWall.SetActive(true);
            }
        }
        else
        {
            rightWall.SetActive(true);
        }

        if (Physics.Raycast(leftWall.transform.position, Vector3.left, out RaycastHit _hit, 0.1f, roomMask))
        {
            
            leftWall.SetActive(false);

            if (!_hit.collider.GetComponent<Room>().Type.Equals(roomType))
            {
                leftDoorWall.SetActive(true);
            }
        }
        else
        {
            leftWall.SetActive(true);
        }

    }

    /// <summary>
    /// This method first checks if the game ended (happiness < -75).
    /// Each room has a frequency, once the timer reaches the frequency it adds the room's value to wallet
    /// and the room's happiness score to the overall happiness. Then the timer resets.
    /// For example, every 5 seconds or every 10 seconds.
    /// </summary>
    protected void BalancingEconomy()
    {
        if (!GameManager.Instance.CheckGameEnded())
        {
            timer += Time.deltaTime;
            if (timer >= frequency)
            {
                GameManager.Instance.PlayerWallet += value;
                GameManager.Instance.PlayerHappiness += happiness;
                timer = 0;
            }
        }
       
    }

}
