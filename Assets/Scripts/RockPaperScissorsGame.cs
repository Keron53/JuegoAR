using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RockPaperScissorsGame : MonoBehaviour
{
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI instructionText;
    public TextMeshProUGUI resultText;
    public Button TreasureSprite;
    public Button rockButton;
    public Button paperButton;
    public Button scissorsButton;
    public GameObject rewardButton;
    public GameObject panel;
    public TreasureBar treasureBar;

    private bool gameWon = false;
    private string[] choices = { "Piedra", "Papel", "Tijeras" };

    void Start()
    {
        rockButton.onClick.AddListener(() => OnPlayerChoice(0));
        paperButton.onClick.AddListener(() => OnPlayerChoice(1));
        scissorsButton.onClick.AddListener(() => OnPlayerChoice(2));

        ResetGame();
    }

    void Update()
    {
        if (panel.activeSelf && gameWon)
        {
            Invoke("EndGame", 5f);
        }
    }

    void OnPlayerChoice(int playerChoice)
    {
        if (gameWon) return;

        int aiChoice = Random.Range(0, 3);
        string result = DetermineWinner(playerChoice, aiChoice);

        DisplayResult(result, aiChoice);

        if (result == "Ganar")
        {
            gameWon = true;
            rewardButton.SetActive(true);
            treasureBar.AddCoin();
            Invoke("EndGame", 5f);
        }
        else
        {
            Invoke("ResetGame", 5f);
        }
    }

    string DetermineWinner(int playerChoice, int aiChoice)
    {
        if (playerChoice == aiChoice) return "Empate";

        if ((playerChoice == 0 && aiChoice == 2) ||
            (playerChoice == 1 && aiChoice == 0) ||
            (playerChoice == 2 && aiChoice == 1))
        {
            return "Ganar";
        }

        return "Perder";
    }

    void DisplayResult(string result, int aiChoice)
    {
        rockButton.gameObject.SetActive(false);
        paperButton.gameObject.SetActive(false);
        scissorsButton.gameObject.SetActive(false);
        instructionText.gameObject.SetActive(false);

        string aiChoiceText = choices[aiChoice];

        if (result == "Ganar")
        {
            resultText.text = $"Felicidades, Aquí está tu premio! Yo escogí {aiChoiceText}.";
            TreasureSprite.gameObject.SetActive(true);
        }
        else if (result == "Empate")
        {
            resultText.text = $"Empate? También escogí {aiChoiceText}. Bueno, juguemos de nuevo!";
        }
        else
        {
            resultText.text = $"Jajaja, soy muy bueno en este juego, inténtalo de nuevo! Acabo de escoger {aiChoiceText}.";
        }
    }

    void ResetGame()
    {
        rockButton.gameObject.SetActive(true);
        paperButton.gameObject.SetActive(true);
        scissorsButton.gameObject.SetActive(true);
        instructionText.gameObject.SetActive(true);
        resultText.text = "";
    }

    void EndGame()
    {
        panel.SetActive(false);
        mainText.text = "Ya has ganado este minijuego";
    }
}
