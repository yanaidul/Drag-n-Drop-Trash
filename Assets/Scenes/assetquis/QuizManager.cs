using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [Header("Question")]
    public GameObject questionPanel;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI questionNumberText; // UI untuk menampilkan nomor soal
    public Button[] answerButtons;
    public TextMeshProUGUI[] answerTexts;
    public List<QuestionData> questionData;
    private List<QuestionData> shuffledQuestionData; // Menyimpan urutan acak pertanyaan
    private int questionIndex;

    [Header("Result")]
    public GameObject resultPanel;
    public TextMeshProUGUI resultText;
    public Text txtNamePlayer;
    public string Nama;
    public float correctAnswerCount;
    public float wrongAnswerCount;
    public float score;
    public float totalQuestions;
    public bool isEnd;

    [Header("Stars")]
    public GameObject[] stars; // UI bintang

    private void Awake()
    {
        isEnd = false;
    }

    private void Start()
    {
        questionIndex = -1;

        // Menyalin daftar pertanyaan ke daftar acak
        shuffledQuestionData = new List<QuestionData>(questionData);
        ShuffleQuestions(shuffledQuestionData);

        questionPanel.SetActive(true);
        correctAnswerCount = 0;
        wrongAnswerCount = 0;
        totalQuestions = GetTotalQuestions();

        StartQuestion(); // Memulai soal secara otomatis saat permainan dimulai
    }

    private int GetTotalQuestions()
    {
        return shuffledQuestionData.Count;
    }

    private void StartQuestion()
    {
        questionPanel.SetActive(true);
        questionIndex++;
        ApplyQuestionUI();
    }

    private void ApplyQuestionUI()
    {
        questionText.text = shuffledQuestionData[questionIndex].question;
        
        // Menampilkan nomor soal di UI
        questionNumberText.text = "Soal No. " + (questionIndex + 1).ToString();

        int correctAnswerIndex = GenerateCorrectAnswer(4);
        Debug.Log($"Correct answer on index : {correctAnswerIndex}");

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].onClick.RemoveAllListeners();
        }

        List<Button> wrongAnswerButtons = new List<Button>();
        List<TextMeshProUGUI> wrongAnswerTexts = new List<TextMeshProUGUI>();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i != correctAnswerIndex)
            {
                wrongAnswerButtons.Add(answerButtons[i]);
                wrongAnswerTexts.Add(answerTexts[i]);
            }
            else
            {
                answerButtons[i].onClick.AddListener(delegate { OnClickCorrectAnswer(); });
                answerTexts[i].text = shuffledQuestionData[questionIndex].correctAnswer;
            }
        }

        for (int i = 0; i < wrongAnswerButtons.Count; i++)
        {
            wrongAnswerButtons[i].onClick.AddListener(delegate { OnClickWrongAnswer(); });
        }

        wrongAnswerTexts[0].text = shuffledQuestionData[questionIndex].wrongAnswer1;
        wrongAnswerTexts[1].text = shuffledQuestionData[questionIndex].wrongAnswer2;
        wrongAnswerTexts[2].text = shuffledQuestionData[questionIndex].wrongAnswer3;
    }

    private int GenerateCorrectAnswer(int maxValue)
    {
        return Random.Range(0, maxValue);
    }

    private void OnClickCorrectAnswer()
    {
        Debug.Log("Correct!");
        correctAnswerCount++;

        questionPanel.SetActive(false);

        UpdateScore();
        CheckWinLose();
    }

    private void OnClickWrongAnswer()
    {
        Debug.Log("Wrong!");
        wrongAnswerCount++;

        questionPanel.SetActive(false);

        UpdateScore();
        CheckWinLose();
    }

    private void UpdateScore()
    {
        score = (correctAnswerCount / totalQuestions) * 100f;
    }

    private void CheckWinLose()
    {
        if (questionIndex >= shuffledQuestionData.Count - 1)
        {
            DisplayResult();
        }
        else
        {
            StartQuestion(); // Memulai soal berikutnya jika masih ada pertanyaan tersisa
        }
    }

    private void DisplayResult()
    {
        resultPanel.SetActive(true);
        resultText.text = $"{Welcome.namePlayer}\n\n\nNilai: {score}\n\nBenar: {correctAnswerCount}\nSalah: {wrongAnswerCount}";
        

        
        // Menampilkan bintang berdasarkan skor
        if (score == 100)
        {
            ShowStars(3);
        }
        else if (score >= 80)
        {
            ShowStars(2);
        }
        else if (score >= 60)
        {
            ShowStars(1);
        }
        else if (score >= 50)
        {
            ShowStars(1);
        }
        else if (score >= 40)
        {
            ShowStars(1);
        }
        else if (score >= 30)
        {
            ShowStars(1);
        }
        else if (score >= 20)
        {
            ShowStars(1);
        }
        else if (score >= 10)
        {
            ShowStars(1);
        }
        else
        {
            ShowStars(0);
        }
    }

    private void ShowStars(int starCount)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].SetActive(i < starCount);
        }
    }

    public void BackToMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Mengacak urutan pertanyaan
    private void ShuffleQuestions(List<QuestionData> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            QuestionData temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}

[System.Serializable]
public class QuestionData
{
    public string question;
    public string correctAnswer;
    public string wrongAnswer1;
    public string wrongAnswer2;
    public string wrongAnswer3;
}