using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RekenMiniGame : MonoBehaviour
{
    int getal1;
    int getal2;
    int operat;
    int antwoord;
    [SerializeField] Text vraag;
    [SerializeField] InputField userInput;
    int userInputValue;
    int streak;
    bool streakStart = false;
    [SerializeField] Text streakText;
    float timer = 120f;
    [SerializeField] Text timerText;
    [SerializeField] Text coinsWin;
    [SerializeField] Text warning;
    GameManager gameManager;
    public void Retry()
    {
        SceneManager.LoadScene("CoinGame");
    }
    public void QuitKnop()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        getal1 = Random.Range(100, 1000); // Er wordt een random nummer gegenereerd tussen de 100 en 1000
        getal2 = Random.Range(1, 500);
        operat = Random.Range(1, 3);

        streakText.text = "Streak = " + streak; // De tekst van de variabel streakTekst wordt "Aantal correct = " + (variabel) streak

        if (operat == 1)
        {
            antwoord = getal1 + getal2;
        }
        else if (operat == 2)
        {
            antwoord = getal1 - getal2;
        }

        if (streakStart == true)
        {
            streak++;
            streakText.text = "Streak = " + streak;
        }

        if (streak == 0)
        {
            coinsWin.text = "";
        }
        else if (streak % 3 == 0)
        {
            if (gameManager.coins == 5)
            {
                coinsWin.text = "You can't get more coins!";
            }
            else
            {
                coinsWin.text = "You won a coin!";
                gameManager.coins++;
            }
        }
        else
        {
            coinsWin.text = "";
        }
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime; // De variabel timer wordt min de echte tijd gedaan
            timerText.text = timer.ToString("F0"); // De tekst van variabel timerText wordt (variabel) timer. timer wordt verandert naar een string en wordt afgerond naar hele seconden
        }
        else
        {
            StartCoroutine(Timer()); // De Method Timer wordt opgeroepen door middel van StartCoroutine
        }
        if (timer < 11)
        {
            timerText.color = Color.red;
        }

        if (operat == 1)
        {
            vraag.text = getal1 + " + " + getal2 + " =";
        }
        else if (operat == 2)
        {
            vraag.text = getal1 + " - " + getal2 + " =";
        }

        if (int.TryParse(userInput.text, out userInputValue)) // Probeer de stringwaarde in 'userInput.text' om te zetten naar een getal. Als dit lukt wordt dit opgeslagen in userInputValue
        {
            if (userInputValue == antwoord)
            {
                userInput.text = "";
                streakStart = true;
                Start();
            }
        }
    }

    IEnumerator Timer()
    {
        warning.text = "The time is up!";
        yield return new WaitForSeconds(2); // Dit geeft de Method mee dat hij hier 2 seconden moet wachten voordat die de code hieronder runt 
        SceneManager.LoadScene("CoinGame"); // CoinGame
    }
}
