using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrueFalseGame2 : MonoBehaviour
{
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI instructionText;
    public TextMeshProUGUI resultText;
    public Button TreasureSprite;
    public Button trueButton;
    public Button falseButton; 
    public GameObject rewardButton;
    public GameObject panel;
    public TreasureBar treasureBar;

    private bool gameWon = false;

    void Start()
    {
        trueButton.onClick.AddListener(() => OnAnswerSelected(1));
        falseButton.onClick.AddListener(() => OnAnswerSelected(2)); 

        ResetGame();
    }

    void Update()
    {
        if (panel.activeSelf && gameWon)
        {
            Invoke("EndGame", 5f);
        }
    }

    void OnAnswerSelected(int answerIndex)
    {
        if (gameWon) return;

        if (answerIndex == 1) 
        {
            gameWon = true;
            DisplayResult("Ganar");
            rewardButton.SetActive(true);
            treasureBar.AddCoin();
            Invoke("EndGame", 5f);
        }
        else
        {
            DisplayResult("Perder");
            Invoke("ResetGame", 5f);
        }
    }

    void DisplayResult(string result)
    {
        trueButton.gameObject.SetActive(false);
        falseButton.gameObject.SetActive(false);
        instructionText.gameObject.SetActive(false);

        if (result == "Ganar")
        {
            resultText.text = "¡Felicidades, has respondido correctamente! Aquí está tu premio.";
            TreasureSprite.gameObject.SetActive(true);
        }
        else
        {
            resultText.text = "Lo siento, respuesta incorrecta. ¡Inténtalo de nuevo!";
        }
    }

    void ResetGame()
    {
        trueButton.gameObject.SetActive(true);
        falseButton.gameObject.SetActive(true);
        instructionText.gameObject.SetActive(true);
        resultText.text = "";
    }

    void EndGame()
    {
        panel.SetActive(false);
        mainText.text = "Ya has ganado este minijuego";
    }
}
