using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI wordDisplay;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private float timeLimit = 15f;

    private string currentWord;
    private float currentTime;

    private void Start()
    {
        StartNewTurn();
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
        string[] words = { "oyun", "kelime", "�ans", "harf", "bilgisayar" };
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
}
