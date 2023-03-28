using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMovement : MonoBehaviour
{

    private bool isPlaced;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject indicator;
    [SerializeField] private Transform[] rayPoints;

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

    void PlaceRoom()
    {
        if(CheckIfValid() && Input.GetMouseButtonDown(0))
        {
            isPlaced = true;
            indicator.SetActive(false);
        }
    }

    private bool CheckIfValid()
    {
        return true;
        //raycast + layermask
    }
}