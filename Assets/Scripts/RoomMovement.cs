using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMovement : MonoBehaviour
{

    private bool isPlaced;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject indicator;
    [SerializeField] private Transform[] rayPoints;
    [SerializeField] private LayerMask roomMask = 6;

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
        }
    }

    private bool CheckIfValid()
    {
        //raycast + layermask
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
