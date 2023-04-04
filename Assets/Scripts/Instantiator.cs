using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Instantiator : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject menu;
    [SerializeField] private Transform parentRoom;
    [Space]
    [Header("Change Sprite:")]
    [SerializeField] private Image playerHappinessImage;
    [SerializeField] private Sprite veryHappy;
    [SerializeField] private Sprite happy;
    [SerializeField] private Sprite sad;
    [SerializeField] private Sprite angry;

    private void Update()
    {
        if(GameManager.Instance.CheckGameEnded())
        {
            GameOver();
        }
        ChangeSprite();

    }

    public void OpenMenu()
    {
        button.GetComponent<Button>().enabled = false;
        menu.SetActive(true);
    }

    public void GenerateRoom(GameObject prefab)
    {
        menu.SetActive(false);
        button.GetComponent<Button>().enabled = true;
        GameObject room = Instantiate(prefab, parentRoom);
        GameManager.Instance.AddRooms(room);
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        button.GetComponent<Button>().enabled = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        button.SetActive(false);
        gameOver.SetActive(true);
    }

    private void ChangeSprite()
    {
        if(GameManager.Instance.PlayerHappiness >= 250)
        {
            playerHappinessImage.sprite = veryHappy;
        }else if(GameManager.Instance.PlayerHappiness >= 75 && GameManager.Instance.PlayerHappiness < 250)
        {
            playerHappinessImage.sprite = happy;
        }
        else if (GameManager.Instance.PlayerHappiness >= 0 && GameManager.Instance.PlayerHappiness < 75)
        {
            playerHappinessImage.sprite = sad;
        }
        else if (GameManager.Instance.PlayerHappiness <= -25)
        {
            playerHappinessImage.sprite = angry;
        }
    }
}
