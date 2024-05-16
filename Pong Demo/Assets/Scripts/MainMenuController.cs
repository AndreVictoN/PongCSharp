using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI uiWinner;

    public List<GameObject> gameObjects;
    public List<GameObject> gameObjectsBack;

    public List<GameObject> onePlayer;
    public List<GameObject> twoPlayers;
    public List<GameObject> openRules;
    public List<GameObject> inRules;
    public List<GameObject> inRulesBack;

    public GameObject enterEnemyName;
    public GameObject enterEnemyNameText;
    public GameObject Return;

    public bool duo = false;

    void Start()
    {
        SaveController.instance.Reset();
        string lastWinner = SaveController.instance.GetLastWinner();

        if(lastWinner != "")
        {
            uiWinner.text = "Last winner: " + lastWinner;
        }else
        {
            uiWinner.text = "";
        }

        foreach(GameObject go in gameObjects)
        {
            go.SetActive(false);
        }
    }

    public void OnOnePlayer()
    {
        foreach(GameObject o in onePlayer)
        {
            o.SetActive(true);
        }

        if(enterEnemyName.activeSelf == true && enterEnemyNameText.activeSelf == true)
        {
            enterEnemyName.SetActive(false);
            enterEnemyNameText.SetActive(false);
        }
    }

    public void OpenRules()
    {
        foreach(GameObject b in openRules)
        {
            b.SetActive(false);
        }
        Return.SetActive(true);
    }

    public void BackToMenu()
    {
        foreach (GameObject j in gameObjectsBack)
        {
            j.SetActive(true);
        }
        Return.SetActive(false);

        foreach(GameObject gobje in inRulesBack)
        {
            gobje.SetActive(false);
        }
    }

    public void OnTwoPlayers()
    {
        foreach(GameObject obj in twoPlayers)
        {
            obj.SetActive(true);
        }
    }

    public void InRules()
    {
        foreach(GameObject gobj in inRules)
        {
            gobj.SetActive(true);
        }
    }

    public void TwoPlayers()
    {
        duo = true;

        SaveController.instance.two = duo;
    }

    public void OnePlayer()
    {
        duo = false;

        SaveController.instance.two = duo;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
