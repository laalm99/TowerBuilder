using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMovement : MonoBehaviour
{

    private bool isPlaced;
    private bool isOverlapping;
    private Camera mainCamera;
    private LayerMask roomMask = (1 << 6);
    [SerializeField] private GameObject indicator;
    [SerializeField] private Transform[] rayPoints;
    public static event Action PlaceRoomEvent;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        MoveWithMouse();
        PlaceRoom();
    }

    void MoveWithMouse()
    {
        if (isPlaced) return;

        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 10;
        //z represents the distance from the camera
        Vector3 targetPos = mainCamera.ScreenToWorldPoint(mousePoint);
        targetPos.x = Mathf.RoundToInt(targetPos.x);
        targetPos.y = Mathf.RoundToInt(Mathf.Clamp(targetPos.y, 0, int.MaxValue));
        transform.position = targetPos;
    }

    /// <summary>
    /// This method places a room if the room is valid and the player clicks.
    /// It invoke the PlaceRoomEvent that then checks the Wall Behaviour in the Room script
    /// </summary>
    void PlaceRoom()
    {
        if(CheckIfValid() && Input.GetMouseButtonDown(0))
        {
            isPlaced = true;
            PlaceRoomEvent?.Invoke();
        }
    }

    /// <summary>
    /// This method makes it that as long as the collider is triggered, it's overlapping
    /// </summary>
    private void OnTriggerStay(Collider other)
    {
        if (isPlaced)
            return;

        isOverlapping = true;
    }

    /// <summary>
    /// Once the room is not triggering another room's collider it's not overlapping
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (isPlaced)
            return;

        isOverlapping = false;
    }

    /// <summary>
    /// This method activates the indicator if it's overlapping.
    /// It also checks using the raypoints if there is no hit then it returns false and activates the indicator
    /// </summary>
    private bool CheckIfValid()
    {
        if (isOverlapping)
        {
            indicator.SetActive(true);
            return false;
        }

        for (int i = 0; i<rayPoints.Length; i++)
        {

            if(!Physics.Raycast(rayPoints[i].position, Vector3.down, out RaycastHit hit, 1.5f, roomMask))
            {
                indicator.SetActive(true);

                return false;
            }
        }

        indicator.SetActive(false);
        return true;
    }
}

/*
 * 
 * grid layout group
 * vertical/horizontal layout group
 * content size fitter (prefered size) >> in the text 
 * layoutrebuilder.forcelayout
 */