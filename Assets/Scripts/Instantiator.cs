using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instantiator : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject menu;

    public void OpenMenu()
    {
        button.enabled = false;
        menu.SetActive(true);
    }

    public void GenerateRoom(GameObject prefab)
    {
        menu.SetActive(false);
        button.enabled = true;
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
