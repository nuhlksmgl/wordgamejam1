using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI wordDisplay;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private float timeLimit = 15f;
    [SerializeField] public GameObject mainGameMenu;
    [SerializeField] public GameObject gameOverMenu;
    [SerializeField] public GameObject mainMenu;

   

    private string currentWord;
    private float currentTime;
    
    private void Start()
    {
        StartNewTurn();
        mainGameMenu.SetActive(true);
        gameOverMenu.SetActive(false);
    }

    private void StartNewTurn()
    {
        // Yeni bir kelime al ve ekrana göster.
        currentWord = GetRandomWord();
        wordDisplay.text = currentWord;

        // Zamaný sýfýrla.
        currentTime = 0f;

        // Input Field'ý temizle.
        inputField.text = "";

        // Sonuç yazýsýný temizle.
        resultText.text = "";

        // Input Field'a odaklan.
        inputField.Select();
        inputField.ActivateInputField();
    }

    private string GetRandomWord()
    {
        string[] words = { "game", "word", "internet", "letter", "computer", "television", "table", "arm", "headphone" , "sun" , "life" , "cup", "glasses", "car", "accident"
        ,"afford", "fish", "glow", "iron", "jacket", "kill", "leaf", "luxury", "nothing", "network"};

        return words[Random.Range(0, words.Length)];
    }

    private void Update()
    {
        // Zamaný takip et ve süre dolduðunda yeni turu baþlat.
        currentTime += Time.deltaTime;
        if (currentTime >= timeLimit)
        {
            StartNewTurn();
        }

        // Enter tuþuna basýldýðýnda kullanýcýnýn girdiðini kontrol et.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckUserInput();
        }
    }

    private void CheckUserInput()
    {
        // Kullanýcýnýn giriþini al.
        string userInput = inputField.text.ToLower();

        // Eðer giriþin ilk harfi doðruysa, yeni bir tur baþlat.
        if (!string.IsNullOrEmpty(userInput) && userInput[0] == currentWord[currentWord.Length - 1])
        {
            resultText.text = "Doðru!";
            StartNewTurn();
        }
        else if (!string.IsNullOrEmpty(userInput))
        {
            resultText.text = "Yanlýþ!";
        }
    }

    public void GameOver()
    {
        mainGameMenu.SetActive(false);
        gameOverMenu.SetActive(true);
    }
    public void StartButton()
    {
        mainMenu.SetActive(false);
        mainGameMenu.SetActive(true);
    }
}
