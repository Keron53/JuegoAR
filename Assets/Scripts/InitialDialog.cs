using System.Collections;
using UnityEngine;
using TMPro;

public class InitialDialog : MonoBehaviour
{
    public GameObject dialogPanel;
    public GameObject continueButton;
    public GameObject continueButton2;
    public GameObject continueButton3;
    public TextMeshProUGUI dialogText;
    public string[] messages;
    public float displayDuration = 5f;
    public float textSpeed = 0.1f;

    private int index;

    void Start()
    {
        dialogText.text = string.Empty;
        index = 0;
        continueButton.SetActive(false);
        continueButton2.SetActive(false);
        continueButton3.SetActive(false);

        StartCoroutine(DisplayMessage());
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetMouseButtonUp(0))
        {
            if (dialogText.text == messages[index])
            {
                NextMessage();
            }
            else
            {
                StopAllCoroutines();
                dialogText.text = messages[index];
            }
        }
    }

    IEnumerator DisplayMessage()
    {
        foreach (char letter in messages[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        yield return new WaitForSeconds(displayDuration);

        NextMessage();
    }

    void NextMessage()
    {
        if (index < messages.Length - 1)
        {
            index++;
            dialogText.text = string.Empty;
            StartCoroutine(DisplayMessage());
        }
        else
        {
            dialogPanel.SetActive(false);
            continueButton.SetActive(true);
            continueButton2.SetActive(true);
            continueButton3.SetActive(true);
        }
    }
}
