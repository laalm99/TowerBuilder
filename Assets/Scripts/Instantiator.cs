using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instantiator : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject menu;
    [SerializeField] private Transform parentRoom;

    private void Update()
    {
        if(GameManager.Instance.CheckGameEnded())
        {
            button.enabled = false;
        }
    }

    public void OpenMenu()
    {
        button.enabled = false;
        menu.SetActive(true);
    }

    public void GenerateRoom(GameObject prefab)
    {
        menu.SetActive(false);
        button.enabled = true;
        GameObject room = Instantiate(prefab, parentRoom);
        GameManager.Instance.AddRooms(room);
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        GameManager.Instance.RemoveLastRoom();
        button.enabled = true;
    }
}
