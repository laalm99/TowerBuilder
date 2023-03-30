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
    private LayerMask roomMask = (1 << 6);
    [SerializeField] private GameObject rightWall;
    [SerializeField] private GameObject leftWall;
    [SerializeField] private RoomType roomType;
    public RoomType Type => roomType;


    protected void WallBehaviour()
    {
        if (Physics.Raycast(rightWall.transform.position, Vector3.right, out RaycastHit hit, 0.5f, roomMask))
        {
            if (hit.collider.GetComponent<Room>().Type.Equals(roomType))
            {
                rightWall.SetActive(false);
            }
            else
            {
                rightWall.SetActive(true);
            }
        }
        else
        {
            rightWall.SetActive(true);
        }

        if (Physics.Raycast(leftWall.transform.position, Vector3.left, out RaycastHit _hit, 0.5f, roomMask))
        {
            if (_hit.collider.GetComponent<Room>().Type.Equals(roomType))
            {
                leftWall.SetActive(false);
            }
            else
            {
                leftWall.SetActive(true);
            }
        }
        else
        {
            leftWall.SetActive(true);
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