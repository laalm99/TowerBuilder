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

    protected void BalacingBehaviour()
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


/*
 * Office: Lower Cost, Higher Income, Lower Happiness
 * Restaurant: Higher Cost, Higher Money, Higher Happiness
 * Lounge: Higher Cost, Lower Income, Higher Happiness
 * Restroom: Lower Cost, Lower Income, Higher Happiness
 * 
 * cast shadows only
 * 
 * 
 */