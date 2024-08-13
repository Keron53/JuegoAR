using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizGame : MonoBehaviour
{
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI instructionText;
    public TextMeshProUGUI resultText;
    public Button TreasureSprite;
    public Button answerButton1;
    public Button answerButton2;
    public Button answerButton3;
    public Button answerButton4;
    public GameObject rewardButton;
    public GameObject panel;
    public TreasureBar treasureBar;

    private bool gameWon = false;

    void Start()
    {
        answerButton1.onClick.AddListener(() => OnAnswerSelected(1));
        answerButton2.onClick.AddListener(() => OnAnswerSelected(2));
        answerButton3.onClick.AddListener(() => OnAnswerSelected(3));
        answerButton4.onClick.AddListener(() => OnAnswerSelected(4));

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

        if (answerIndex == 3)
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
        answerButton1.gameObject.SetActive(false);
        answerButton2.gameObject.SetActive(false);
        answerButton3.gameObject.SetActive(false);
        answerButton4.gameObject.SetActive(false);
        instructionText.gameObject.SetActive(false);

        if (result == "Ganar")
        {
            resultText.text = "Felicidades, has respondido correctamente! Aquí está tu premio.";
            TreasureSprite.gameObject.SetActive(true);
        }
        else
        {
            resultText.text = "Lo siento, respuesta incorrecta. Inténtalo de nuevo!";
        }
    }

    void ResetGame()
    {
        answerButton1.gameObject.SetActive(true);
        answerButton2.gameObject.SetActive(true);
        answerButton3.gameObject.SetActive(true);
        answerButton4.gameObject.SetActive(true);
        instructionText.gameObject.SetActive(true);
        resultText.text = "";
    }

    void EndGame()
    {
        panel.SetActive(false);
        mainText.text = "Ya has ganado este minijuego";
    }
}
