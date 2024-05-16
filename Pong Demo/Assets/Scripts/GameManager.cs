using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform playerPaddle;
    public Transform enemyPaddle;

    public BallControler ballController;

    public GameObject screenEndGame;

    public bool isPaused = false;

    public TextMeshProUGUI textEndGame;

    [Header("Score")]
    public int playerScore = 0;
    public int enemyScore = 0;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;
    public TextMeshProUGUI textRounds;
    public TextMeshProUGUI textRoundsWin;
    public TextMeshProUGUI textRoundsLost;
    public TextMeshProUGUI textMatchesLost;
    public TextMeshProUGUI textMatchesWin;
    public TextMeshProUGUI textMatchesNum;

    public int winPoints = 5;

    public int round = 1;

    public int roundsWin = 0;
    public int roundsLost = 0;

    public int matchesWin = 0;
    public int matchesLost = 0;

    public int matchesNumber = 1;

    void Start()
    {
        ResetGame();
    }

    void Update()
    {
        CheckKeys();
    }

    public void ResetGame()
    {
        playerScore = 0;
        enemyScore = 0;

        roundsWin = 0;
        roundsLost = 0;

        matchesWin = 0;
        matchesLost = 0;

        matchesNumber = 1;

        round = 1;

        textPointsEnemy.text = enemyScore.ToString();
        textPointsPlayer.text = playerScore.ToString();

        textRounds.text = "Round " + round.ToString();
        textRoundsWin.text = "Wins: " + roundsWin.ToString();
        textRoundsLost.text = "Wins: " + roundsLost.ToString();
        textMatchesWin.text = "Matches Won: " + matchesWin.ToString();
        textMatchesLost.text = "Matches Won: " + matchesLost.ToString();
        textMatchesNum.text = "Match: " + matchesNumber.ToString();

        ballController.ResetBall();

        playerPaddle.position = new Vector3(-7f, 0f, 0f);

        enemyPaddle.position = new Vector3(7f, 0f, 0f);

        screenEndGame.SetActive(false);
    }

    public void NewMatch()
    {
        playerScore = 0;
        enemyScore = 0;

        roundsWin = 0;
        roundsLost = 0;

        round = 1;

        matchesNumber++;

        textPointsEnemy.text = enemyScore.ToString();
        textPointsPlayer.text = playerScore.ToString();

        textRounds.text = "Round " + round.ToString();
        textRoundsWin.text = "Wins: " + roundsWin.ToString();
        textRoundsLost.text = "Wins: " + roundsLost.ToString();
        textMatchesNum.text = "Match: " + matchesNumber.ToString();

        ballController.ResetBall();

        playerPaddle.position = new Vector3(-7f, 0f, 0f);

        enemyPaddle.position = new Vector3(7f, 0f, 0f);

        screenEndGame.SetActive(false);
    }

    public void ScorePlayer()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }

    public void ScoreEnemy()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if(enemyScore == winPoints || playerScore == winPoints)
        {
            round++;

            if(playerScore > enemyScore)
            {
                roundsWin++;
                textRoundsWin.text = "Wins: " + roundsWin.ToString();
            }else if(enemyScore > playerScore)
            {
                roundsLost++;
                textRoundsLost.text = "Wins: " + roundsLost.ToString();
            }

            playerScore = 0;
            enemyScore = 0;

            textPointsEnemy.text = enemyScore.ToString();
            textPointsPlayer.text = playerScore.ToString();

            textRounds.text = "Round " + round.ToString();

            if(round >= 4 && matchesNumber < 3)
            {
                if(roundsWin > roundsLost)
                {
                    matchesWin++;
                    textMatchesWin.text = "Matches Won: " + matchesWin.ToString();
                }else if(roundsLost > roundsWin)
                {
                    matchesLost++;
                    textMatchesLost.text = "Matches Won: " + matchesLost.ToString();
                }

                NewMatch();
            }else if(round >= 4 && matchesNumber >= 3)
            {
                if(roundsWin > roundsLost)
                {
                    matchesWin++;
                    textMatchesWin.text = "Matches Won: " + matchesWin.ToString();
                }else if(roundsLost > roundsWin)
                {
                    matchesLost++;
                    textMatchesLost.text = "Matches Won: " + matchesLost.ToString();
                }
                
                string winner = SaveController.instance.GetName(matchesWin > matchesLost);

                screenEndGame.SetActive(true);

                if(winner == "")
                {
                    winner = "Unknown";
                }

                textEndGame.text = winner + " wins!";
                SaveController.instance.SaveWinner(winner);

                Invoke("LoadMenu",2f);
            }
        }
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void CheckKeys()
    {
        if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            ResetGame();
        }
    }
}
