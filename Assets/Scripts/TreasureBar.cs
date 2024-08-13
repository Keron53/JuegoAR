using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TreasureBar : MonoBehaviour
{
    public TextMeshProUGUI TreasureText;
    public Button nextLevelButton; 
    private int TreasureCount = 0;
    public int maxTreasure = 3;

    void Start()
    {
        nextLevelButton.gameObject.SetActive(false); 
        UpdateTreasureBar();
    }

    public void AddCoin()
    {
        TreasureCount++;
        UpdateTreasureBar();

        if (TreasureCount >= maxTreasure)
        {
            ShowNextLevelButton();
        }
    }

    void UpdateTreasureBar()
    {
        TreasureText.text = $"Tesoros encontrados: {TreasureCount}/{maxTreasure}";
    }

    void ShowNextLevelButton()
    {
        nextLevelButton.gameObject.SetActive(true); 
    }
}
