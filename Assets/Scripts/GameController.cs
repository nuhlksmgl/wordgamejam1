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
        // Yeni bir kelime al ve ekrana g�ster.
        currentWord = GetRandomWord();
        wordDisplay.text = currentWord;

        // Zaman� s�f�rla.
        currentTime = 0f;

        // Input Field'� temizle.
        inputField.text = "";

        // Sonu� yaz�s�n� temizle.
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
        // Zaman� takip et ve s�re doldu�unda yeni turu ba�lat.
        currentTime += Time.deltaTime;
        if (currentTime >= timeLimit)
        {
            StartNewTurn();
        }

        // Enter tu�una bas�ld���nda kullan�c�n�n girdi�ini kontrol et.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckUserInput();
        }
    }

    private void CheckUserInput()
    {
        // Kullan�c�n�n giri�ini al.
        string userInput = inputField.text.ToLower();

        // E�er giri�in ilk harfi do�ruysa, yeni bir tur ba�lat.
        if (!string.IsNullOrEmpty(userInput) && userInput[0] == currentWord[currentWord.Length - 1])
        {
            resultText.text = "Do�ru!";
            StartNewTurn();
        }
        else if (!string.IsNullOrEmpty(userInput))
        {
            resultText.text = "Yanl��!";
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
