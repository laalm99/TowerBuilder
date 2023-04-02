using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Vector3 currentPosition;
    private Vector3 targetPosition;


    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovementControl();
    }

    void CameraMovementControl()
    {

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetPosition = new Vector3(currentPosition.x - 1, currentPosition.y, currentPosition.z);
            if (targetPosition.x >= -10)
            {
                currentPosition = targetPosition;
                transform.position = currentPosition;
            }
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetPosition = new Vector3(currentPosition.x + 1, currentPosition.y, currentPosition.z);
            if (targetPosition.x <= 10)
            {
                currentPosition = targetPosition;
                transform.position = currentPosition;
            }  
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            targetPosition = new Vector3(currentPosition.x, currentPosition.y+1, currentPosition.z);
            currentPosition = targetPosition;
            transform.position = currentPosition;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            targetPosition = new Vector3(currentPosition.x, currentPosition.y - 1, currentPosition.z);
            if (targetPosition.y >= 2.5)
            {
                currentPosition = targetPosition;
                transform.position = currentPosition;
            }
           
        }

    }
}
