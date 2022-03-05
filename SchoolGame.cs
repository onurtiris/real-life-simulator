using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolGame : MonoBehaviour
{
    GameManager _GameManager;

    public float Second;
    public Text TimeText;
    public Text QuestionText;

    int FirstNumber = 0;
    int SecondNumber = 0;
    int ThirdNumber = 0;
    int Answer = 0;
    int HappinessIncrease;

    public Text Button1Text;
    public Text Button2Text;
    public Text Button3Text;

    public bool CorrectButton1;
    public bool CorrectButton2;
    public bool CorrectButton3;

    public bool FirstQuestion;

    public GameObject StartButton;
    public GameObject StopButton;
    public GameObject SchoolGamePanel;
    public GameObject SchoolMiniGamePanel;

    public Text CheatButtonText;
    int CheatPrice;
    public int CheatCounter;

    public GameObject BackButton;

    void Start()
    {
        this.enabled = true;
        GM();
        FirstCondition();
        GenerateNew();
        CalculateCheat();
    }

    public void GM()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Cheat()
    {
        GM();
        Load();
        CalculateCheat();

        if (_GameManager.L) { if (_GameManager.Money < CheatPrice) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(_GameManager.Money - CheatPrice) + " eksiğin var."); return; } }
        else { if (_GameManager.Money < CheatPrice) { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(_GameManager.Money - CheatPrice) + " short."); return; } }

        _GameManager.Money -= CheatPrice;
        _GameManager.JobCounter = 7;
        SchoolGamePanel.SetActive(false);
        _GameManager.ShopBlur.SetActive(false);

        if (_GameManager.L) { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Öğretmen: </color>Tebrikler, sınavı başarıyla tamamladın.", "Okul puanı: " + _GameManager.SchoolPoint + " > " + (_GameManager.SchoolPoint + 1) + "\nPara: $" + (_GameManager.Money + CheatPrice) + " > $" + _GameManager.Money); }
        else { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Teacher: </color>Congratulations, you have successfully completed the exam.", "School point: " + _GameManager.SchoolPoint + " > " + (_GameManager.SchoolPoint + 1) + "\nMoney: $" + (_GameManager.Money + CheatPrice) + " > $" + _GameManager.Money); }
        
        _GameManager.ShopDisplayPanel.SetActive(false);
        _GameManager.SchoolPoint += 1;
        CheatCounter += 1;

        Save();
        FirstCondition();
        _GameManager.UpdateUI();
    }

    public void Load()
    {
        CheatCounter = PlayerPrefs.GetInt("CheatCounter");
    }

    public void Save()
    {
        PlayerPrefs.SetInt("CheatCounter", CheatCounter);
    }

    public void GenerateQuestion()
    {
        FirstNumber = Random.Range(1, 100);
        SecondNumber = Random.Range(1, 100);
        ThirdNumber = Random.Range(2, 5);

        int RandomOperation = Random.Range(0, 6);

        if (_GameManager.L)
        {
            switch (RandomOperation)
            {
                case 0:
                Answer = FirstNumber + SecondNumber;
                if (!FirstQuestion) { QuestionText.text = "<color='#3DB4C9'>Öğretmen: </color>Birinci soru, <color='#C1AF80'>" + FirstNumber + " + " + SecondNumber + "</color> işleminin sonucu kaçtır?"; }
                else { QuestionText.text = "<color='#3DB4C9'>Öğretmen: </color>İkinci soru, <color='#C1AF80'>" + FirstNumber + " + " + SecondNumber + "</color> işleminin sonucu kaçtır?"; }
                break;
                case 1:
                Answer = FirstNumber - SecondNumber;
                if (!FirstQuestion) { QuestionText.text = "<color='#3DB4C9'>Öğretmen: </color>Birinci soru, <color='#C1AF80'>" + FirstNumber + " - " + SecondNumber + "</color> işleminin sonucu kaçtır?"; }
                else { QuestionText.text = "<color='#3DB4C9'>Öğretmen: </color>İkinci soru, <color='#C1AF80'>" + FirstNumber + " - " + SecondNumber + "</color> işleminin sonucu kaçtır?"; }
                break;
                case 2:
                Answer = ((FirstNumber - SecondNumber) + ThirdNumber);
                if (!FirstQuestion) { QuestionText.text = "<color='#3DB4C9'>Öğretmen: </color>Birinci soru, <color='#C1AF80'>" + FirstNumber + " - " + SecondNumber + " + " + ThirdNumber + "</color> işleminin sonucu kaçtır?"; }
                else { QuestionText.text = "<color='#3DB4C9'>Öğretmen: </color>İkinci soru, <color='#C1AF80'>" + FirstNumber + " - " + SecondNumber + " + " + ThirdNumber + "</color> işleminin sonucu kaçtır?"; }
                break;
                case 3:
                Answer = ((FirstNumber - SecondNumber) - ThirdNumber);
                if (!FirstQuestion) { QuestionText.text = "<color='#3DB4C9'>Öğretmen: </color>Birinci soru, <color='#C1AF80'>" + FirstNumber + " - " + SecondNumber + " - " + ThirdNumber + "</color> işleminin sonucu kaçtır?"; }
                else { QuestionText.text = "<color='#3DB4C9'>Öğretmen: </color>İkinci soru, <color='#C1AF80'>" + FirstNumber + " - " + SecondNumber + " - " + ThirdNumber + "</color> işleminin sonucu kaçtır?"; }
                break;
                case 4:
                Answer = ((FirstNumber + SecondNumber) + ThirdNumber);
                if (!FirstQuestion) { QuestionText.text = "<color='#3DB4C9'>Öğretmen: </color>Birinci soru, <color='#C1AF80'>" + FirstNumber + " + " + SecondNumber + " + " + ThirdNumber + "</color> işleminin sonucu kaçtır?"; }
                else { QuestionText.text = "<color='#3DB4C9'>Öğretmen: </color>İkinci soru, <color='#C1AF80'>" + FirstNumber + " + " + SecondNumber + " + " + ThirdNumber + "</color> işleminin sonucu kaçtır?"; }
                break;
                case 5:
                Answer = ((FirstNumber + SecondNumber) - ThirdNumber);
                if (!FirstQuestion) { QuestionText.text = "<color='#3DB4C9'>Öğretmen: </color>Birinci soru, <color='#C1AF80'>" + FirstNumber + " + " + SecondNumber + " - " + ThirdNumber + "</color> işleminin sonucu kaçtır?"; }
                else { QuestionText.text = "<color='#3DB4C9'>Öğretmen: </color>İkinci soru, <color='#C1AF80'>" + FirstNumber + " + " + SecondNumber + " - " + ThirdNumber + "</color> işleminin sonucu kaçtır?"; }
                break;
            }
        }
        else
        {
            switch (RandomOperation)
            {
                case 0:
                Answer = FirstNumber + SecondNumber;
                if (!FirstQuestion) { QuestionText.text = "<color='#3DB4C9'>Teacher: </color>First question, what is the result of <color='#C1AF80'>" + FirstNumber + " + " + SecondNumber + "</color> operation?"; }
                else { QuestionText.text = "<color='#3DB4C9'>Teacher: </color>Second question, what is the result of <color='#C1AF80'>" + FirstNumber + " + " + SecondNumber + "</color> operation?"; }
                break;
                case 1:
                Answer = FirstNumber - SecondNumber;
                if (!FirstQuestion) { QuestionText.text = "<color='#3DB4C9'>Teacher: </color>First question, what is the result of <color='#C1AF80'>" + FirstNumber + " - " + SecondNumber + "</color> operation?"; }
                else { QuestionText.text = "<color='#3DB4C9'>Teacher: </color>Second question, what is the result of <color='#C1AF80'>" + FirstNumber + " - " + SecondNumber + "</color> operation?"; }
                break;
                case 2:
                Answer = ((FirstNumber - SecondNumber) + ThirdNumber);
                if (!FirstQuestion) { QuestionText.text = "<color='#3DB4C9'>Teacher: </color>First question, what is the result of <color='#C1AF80'>" + FirstNumber + " - " + SecondNumber + " + " + ThirdNumber + "</color> operation?"; }
                else { QuestionText.text = "<color='#3DB4C9'>Teacher: </color>Second question, what is the result of <color='#C1AF80'>" + FirstNumber + " - " + SecondNumber + " + " + ThirdNumber + "</color> operation?"; }
                break;
                case 3:
                Answer = ((FirstNumber - SecondNumber) - ThirdNumber);
                if (!FirstQuestion) { QuestionText.text = "<color='#3DB4C9'>Teacher: </color>First question, what is the result of <color='#C1AF80'>" + FirstNumber + " - " + SecondNumber + " - " + ThirdNumber + "</color> operation?"; }
                else { QuestionText.text = "<color='#3DB4C9'>Teacher: </color>Second question, what is the result of <color='#C1AF80'>" + FirstNumber + " - " + SecondNumber + " - " + ThirdNumber + "</color> operation?"; }
                break;
                case 4:
                Answer = ((FirstNumber + SecondNumber) + ThirdNumber);
                if (!FirstQuestion) { QuestionText.text = "<color='#3DB4C9'>Teacher: </color>First question, what is the result of <color='#C1AF80'>" + FirstNumber + " + " + SecondNumber + " + " + ThirdNumber + "</color> operation?"; }
                else { QuestionText.text = "<color='#3DB4C9'>Teacher: </color>Second question, what is the result of <color='#C1AF80'>" + FirstNumber + " + " + SecondNumber + " + " + ThirdNumber + "</color> operation?"; }
                break;
                case 5:
                Answer = ((FirstNumber + SecondNumber) - ThirdNumber);
                if (!FirstQuestion) { QuestionText.text = "<color='#3DB4C9'>Teacher: </color>First question, what is the result of <color='#C1AF80'>" + FirstNumber + " + " + SecondNumber + " - " + ThirdNumber + "</color> operation?"; }
                else { QuestionText.text = "<color='#3DB4C9'>Teacher: </color>Second question, what is the result of <color='#C1AF80'>" + FirstNumber + " + " + SecondNumber + " - " + ThirdNumber + "</color> operation?"; }
                break;
            }
        }
    }

    public void GenerateNew()
    {
        this.enabled = true;
        BackButton.SetActive(false);
        StartButton.SetActive(false);
        StopButton.SetActive(false);
        SchoolMiniGamePanel.SetActive(true);

        if (!FirstQuestion) { Second = 16; }

        TimeText.text = "" + (int)Second;
        GenerateQuestion();
        GM();

        _GameManager.Food -= 6;
        _GameManager.JobCounter = 7;

        int SwitchRandom = Random.Range(0,6);

        switch (SwitchRandom)
        {
            case 0:
            CorrectButton1 = true;
            Button1Text.text = "" + Answer;
            Button2Text.text = "" + (Answer + (Random.Range(1, 6)));
            Button3Text.text = "" + (Answer - (Random.Range(1, 6)));
            break;

            case 1:
            CorrectButton1 = true;
            Button1Text.text = "" + Answer;
            Button2Text.text = "" + (Answer - (Random.Range(1, 6)));
            Button3Text.text = "" + (Answer + (Random.Range(1, 6)));
            break;

            case 2:
            CorrectButton2 = true;
            Button1Text.text = "" + (Answer + (Random.Range(1, 6)));
            Button2Text.text = "" + Answer;
            Button3Text.text = "" + (Answer - (Random.Range(1, 6)));
            break;

            case 3:
            CorrectButton2 = true;
            Button1Text.text = "" + (Answer - (Random.Range(1, 6)));
            Button2Text.text = "" + Answer;
            Button3Text.text = "" + (Answer + (Random.Range(1, 6)));
            break;

            case 4:
            CorrectButton3 = true;
            Button1Text.text = "" + (Answer + (Random.Range(1, 6)));
            Button2Text.text = "" + (Answer - (Random.Range(1, 6)));
            Button3Text.text = "" + Answer;
            break;

            case 5:
            CorrectButton3 = true;
            Button1Text.text = "" + (Answer - (Random.Range(1, 6)));
            Button2Text.text = "" + (Answer + (Random.Range(1, 6)));
            Button3Text.text = "" + Answer;
            break;
        }

        _GameManager.UpdateUI();
    }

    public void FirstCondition()
    {
        Load();

        BackButton.SetActive(true);
        FirstQuestion = false;
        CorrectButton1 = false;
        CorrectButton2 = false;
        CorrectButton3 = false;
        StartButton.SetActive(true);
        StopButton.SetActive(true);
        SchoolMiniGamePanel.SetActive(false);

        if (_GameManager.L) { QuestionText.text = "<color='#3DB4C9'>Öğretmen: </color>Sana vereceğim sınavı geçersen, <color='#C1AF80'>1 okul puanı</color> kazanacaksın."; }
        else { QuestionText.text = "<color='#3DB4C9'>Teacher: </color>If you pass the exam I will give you, you will earn <color='#C1AF80'>1 school point.</color>"; }

        CalculateCheat();
    }

    public void CalculateCheat()
    {
        CheatPrice = CheatCounter * 1500;
        if (CheatPrice <= 0) { CheatPrice = 500; }
        if (CheatPrice >= 50000) { CheatPrice = 50000; }
        if (_GameManager.L) { }
        else { CheatButtonText.text = "Cheat ($" + CheatPrice + ")"; }
    }

    public void SecondCondition()
    {
        FirstQuestion = true;
        CorrectButton1 = false;
        CorrectButton2 = false;
        CorrectButton3 = false;
        StartButton.SetActive(false); 
        StopButton.SetActive(false); 
        SchoolMiniGamePanel.SetActive(true);
    }

    public void Button1Check()
    {
        if (!FirstQuestion)
        {
            if (CorrectButton1 && !CorrectButton2 && !CorrectButton3)
            {
                SecondCondition();
                GenerateNew();
                return;
            }
            else
            {
                SchoolGamePanel.SetActive(false);
                _GameManager.ShopBlur.SetActive(false);
                if (_GameManager.L) { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Öğretmen: </color>Yanlış cevap verdin. Daha sonra tekrar deneyebilirsin.", _GameManager.RemoveHappinessText(2)); }
                else { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Teacher: </color>You gave the wrong answer. You can try again later.", _GameManager.RemoveHappinessText(2)); }
                _GameManager.ShopDisplayPanel.SetActive(false);
                FirstCondition();
            }
        }

        else
        {
            if (CorrectButton1 && !CorrectButton2 && !CorrectButton3)
            {
                SchoolGamePanel.SetActive(false);
                _GameManager.ShopBlur.SetActive(false);
                if (_GameManager.L) { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Öğretmen: </color>Tebrikler, sınavı başarıyla tamamladın.", "Okul puanı: " + _GameManager.SchoolPoint + " > " + (_GameManager.SchoolPoint + 1) + "\n" + _GameManager.AddHappinessText(1)); }
                else { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Teacher: </color>Congratulations, you have successfully completed the exam.", "School point: " + _GameManager.SchoolPoint + " > " + (_GameManager.SchoolPoint + 1) + "\n" + _GameManager.AddHappinessText(1)); }
                _GameManager.ShopDisplayPanel.SetActive(false);
                _GameManager.SchoolPoint += 1;
            }
            else
            {
                SchoolGamePanel.SetActive(false);
                _GameManager.ShopBlur.SetActive(false);
                if (_GameManager.L) { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Öğretmen: </color>Yanlış cevap verdin. Daha sonra tekrar deneyebilirsin.", _GameManager.RemoveHappinessText(2)); }
                else { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Teacher: </color>You gave the wrong answer. You can try again later.", _GameManager.RemoveHappinessText(2)); }
                _GameManager.ShopDisplayPanel.SetActive(false);

            }
            FirstCondition();
        }
        FirstCondition();
        _GameManager.UpdateUI();
    }

    public void Button2Check()
    {
        if (!FirstQuestion)
        {
            if (CorrectButton2 && !CorrectButton1 && !CorrectButton3)
            {
                SecondCondition();
                GenerateNew();
                return;
            }
            else
            {
                SchoolGamePanel.SetActive(false);
                _GameManager.ShopBlur.SetActive(false);
                if (_GameManager.L) { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Öğretmen: </color>Yanlış cevap verdin. Daha sonra tekrar deneyebilirsin.", _GameManager.RemoveHappinessText(2)); }
                else { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Teacher: </color>You gave the wrong answer. You can try again later.", _GameManager.RemoveHappinessText(2)); }
                _GameManager.ShopDisplayPanel.SetActive(false);
                FirstCondition();
            }
        }

        else
        {
            if (CorrectButton2 && !CorrectButton1 && !CorrectButton3)
            {
                SchoolGamePanel.SetActive(false);
                _GameManager.ShopBlur.SetActive(false);
                if (_GameManager.L) { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Öğretmen: </color>Tebrikler, sınavı başarıyla tamamladın.", "Okul puanı: " + _GameManager.SchoolPoint + " > " + (_GameManager.SchoolPoint + 1) + "\n" + _GameManager.AddHappinessText(1)); }
                else { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Teacher: </color>Congratulations, you have successfully completed the exam.", "School point: " + _GameManager.SchoolPoint + " > " + (_GameManager.SchoolPoint + 1) + "\n" + _GameManager.AddHappinessText(1)); }
                _GameManager.ShopDisplayPanel.SetActive(false);
                _GameManager.SchoolPoint += 1;

            }
            else
            {
                SchoolGamePanel.SetActive(false);
                _GameManager.ShopBlur.SetActive(false);
                if (_GameManager.L) { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Öğretmen: </color>Yanlış cevap verdin. Daha sonra tekrar deneyebilirsin.", _GameManager.RemoveHappinessText(2)); }
                else { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Teacher: </color>You gave the wrong answer. You can try again later.", _GameManager.RemoveHappinessText(2)); }
                _GameManager.ShopDisplayPanel.SetActive(false);
            }
            FirstCondition();
        }
        FirstCondition();
        _GameManager.UpdateUI();
    }

    public void Button3Check()
    {
        if (!FirstQuestion)
        {
            if (CorrectButton3 && !CorrectButton2 && !CorrectButton1)
            {
                SecondCondition();
                GenerateNew();
                return;
            }
            else
            {
                SchoolGamePanel.SetActive(false);
                _GameManager.ShopBlur.SetActive(false);
                if (_GameManager.L) { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Öğretmen: </color>Yanlış cevap verdin. Daha sonra tekrar deneyebilirsin.", _GameManager.RemoveHappinessText(2)); }
                else { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Teacher: </color>You gave the wrong answer. You can try again later.", _GameManager.RemoveHappinessText(2)); }
                _GameManager.ShopDisplayPanel.SetActive(false);
                FirstCondition();
            }
        }

        else
        {
            if (CorrectButton3 && !CorrectButton2 && !CorrectButton1)
            {
                SchoolGamePanel.SetActive(false);
                _GameManager.ShopBlur.SetActive(false);
                if (_GameManager.L) { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Öğretmen: </color>Tebrikler, sınavı başarıyla tamamladın.", "Okul puanı: " + _GameManager.SchoolPoint + " > " + (_GameManager.SchoolPoint + 1) + "\n" + _GameManager.AddHappinessText(1)); }
                else { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Teacher: </color>Congratulations, you have successfully completed the exam.", "School point: " + _GameManager.SchoolPoint + " > " + (_GameManager.SchoolPoint + 1) + "\n" + _GameManager.AddHappinessText(1)); }
                _GameManager.ShopDisplayPanel.SetActive(false);
                _GameManager.SchoolPoint += 1;

            }
            else
            {
                SchoolGamePanel.SetActive(false);
                _GameManager.ShopBlur.SetActive(false);
                if (_GameManager.L) { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Öğretmen: </color>Yanlış cevap verdin. Daha sonra tekrar deneyebilirsin.", _GameManager.RemoveHappinessText(2)); }
                else { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Teacher: </color>You gave the wrong answer. You can try again later.", _GameManager.RemoveHappinessText(2)); }
                _GameManager.ShopDisplayPanel.SetActive(false);
            }
            FirstCondition();
        }
        _GameManager.UpdateUI();
    }

    public void CloseButton()
    {
        SchoolGamePanel.SetActive(false);
        _GameManager.SchoolBool = false;
        FirstCondition();
    }

    void Update()
    {
        Second -= Time.deltaTime;
        if (Second <=6)
        {
            TimeText.text = "<color='#F77F64'>" + (int)Second + "</color>";
        }
        else
        {
            TimeText.text = "" + (int)Second;
        }
        if (Second <= 0)
        {
            FirstCondition();
            this.enabled = false;
            SchoolGamePanel.SetActive(false);
            _GameManager.ShopBlur.SetActive(false);
            if (_GameManager.L) { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Öğretmen: </color>Testi zamanında bitiremedin, daha sonra tekrar deneyebilirsin.", _GameManager.RemoveHappinessText(2) + "\n" + _GameManager.RemoveFoodText(1)); }
            else { _GameManager.CloseDisplayMessage("teacher", "<color='#3DB4C9'>Teacher: </color>You did not finish the test in time, you can try again later.", _GameManager.RemoveHappinessText(2) + "\n" + _GameManager.RemoveFoodText(1)); }
            _GameManager.ShopDisplayPanel.SetActive(false);
            _GameManager.UpdateUI();
        }
    }
}
