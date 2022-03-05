using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HorseRace : MonoBehaviour
{
    GameManager _GameManager;

    public float timeLeft1;
    public float maxTime1 = 100;
    public float duration = 0;

    public float timeLeft2;
    public float maxTime2 = 100;

    public float timeLeft3;
    public float maxTime3 = 100;

    public Slider slider;
    public Slider slider2;
    public Slider slider3;

    public Text Title;
    public Text HorseInformation;

    public GameObject ProtectBlur;

    bool Plays1, Plays2, Plays3, Plays4, Plays5, Plays6, Plays7, Plays8, Plays9, Plays10, Plays11, Plays12;

    public GameObject red1, red2, red3, red4, yellow1, yellow2, yellow3, yellow4, blue1, blue2, blue3, blue4;

    private void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_GameManager.L) { HorseInformation.text = "Seçtiğin at birinci olursa 3 katını kazanacaksın."; Title.text = "At Yarışı"; }
        else { HorseInformation.text = "If the horse you chose wins, you will win 3 times."; Title.text = "Horse Racing"; }
    }

    public void SetActiveFalse()
    {
        ProtectBlur.SetActive(true);
    }

    public void SetActiveTrue()
    {
        if (_GameManager.L) { HorseInformation.text = "Seçtiğin at birinci olursa 3 katını kazanacaksın."; Title.text = "At Yarışı"; }
        else { HorseInformation.text = "If the horse you chose wins, you will win 3 times."; Title.text = "Horse Racing"; }
        ProtectBlur.SetActive(false);

        red1.SetActive(true);
        red2.SetActive(true);
        red3.SetActive(true);
        red4.SetActive(true);
        yellow1.SetActive(true);
        yellow2.SetActive(true);
        yellow3.SetActive(true);
        yellow4.SetActive(true);
        blue1.SetActive(true);
        blue2.SetActive(true);
        blue3.SetActive(true);
        blue4.SetActive(true);
    }

    public void PlaysFalse()
    {
        Plays1 = false;
        Plays2 = false;
        Plays3 = false;
        Plays4 = false;
        Plays5 = false;
        Plays6 = false;
        Plays7 = false;
        Plays8 = false;
        Plays9 = false;
        Plays10 = false;
        Plays11 = false;
        Plays12 = false;
    }

    public void SetupGame()
    {
        _GameManager.UpdateUI();
        timeLeft1 = maxTime1;
        slider.value = timeLeft1;

        timeLeft2 = maxTime2;
        slider2.value = timeLeft2;

        timeLeft3 = maxTime3;
        slider3.value = timeLeft3;

        this.enabled = true;
        SetActiveFalse();
        Start();

        timeLeft1 = 100;
        maxTime1 = 100;

        timeLeft2 = 100;
        maxTime2 = 100;

        timeLeft3 = 100;
        maxTime3 = 100;
    }

    public void PlayGame1()
    {
        if (_GameManager.Money >= 100)
        {
            red1.SetActive(false);
            Plays1 = true;
            _GameManager.Money -= 100;
            _GameManager.Blur.SetActive(true);
            SetupGame();
            if (_GameManager.L)
            {
                HorseInformation.text = "Kırmızı At: $100, Ödül: $300";
                _GameManager.DisplayMiniMessage("Kırmızı at birinci olursa $300 kazanacaksın.");
            }
            else
            {
                HorseInformation.text = "Red Horse: $100, Prize: $300";
                _GameManager.DisplayMiniMessage("If the red horse comes first, you will win $300.");
            }   
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(_GameManager.Money - 100) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(_GameManager.Money - 100) + " short."); }
        }
    }

    public void PlayGame2()
    {
        if (_GameManager.Money >= 500)
        {
            red2.SetActive(false);
            Plays2 = true;
            _GameManager.Money -= 500;
            _GameManager.Blur.SetActive(true);
            SetupGame();
            if (_GameManager.L)
            {
                HorseInformation.text = "Kırmızı At: $500, Ödül: $1500";
                _GameManager.DisplayMiniMessage("Kırmızı at birinci olursa $1500 kazanacaksın.");
            }
            else
            {
                HorseInformation.text = "Red Horse: $500, Prize: $1500";
                _GameManager.DisplayMiniMessage("If the red horse comes first, you will win $1500.");
            }
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(_GameManager.Money - 500) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(_GameManager.Money - 500) + " short."); }
        }
    }

    public void PlayGame3()
    {
        if (_GameManager.Money >= 1000)
        {
            red3.SetActive(false);
            Plays3 = true;
            _GameManager.Money -= 1000;
            _GameManager.Blur.SetActive(true);
            SetupGame();
            if (_GameManager.L)
            {
                HorseInformation.text = "Kırmızı At: $1000, Ödül: $3000";
                _GameManager.DisplayMiniMessage("Kırmızı at birinci olursa $3000 kazanacaksın.");
            }
            else
            {
                HorseInformation.text = "Red Horse: $1000, Prize: $3000";
                _GameManager.DisplayMiniMessage("If the red horse comes first, you will win $3000.");
            }
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(_GameManager.Money - 1000) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(_GameManager.Money - 1000) + " short."); }
        }
    }

    public void PlayGame4()
    {
        if (_GameManager.Money >= 2500)
        {
            red4.SetActive(false);
            Plays4 = true;
            _GameManager.Money -= 2500;
            _GameManager.Blur.SetActive(true);
            SetupGame();
            if (_GameManager.L)
            {
                HorseInformation.text = "Kırmızı At: $2500, Ödül: $7500";
                _GameManager.DisplayMiniMessage("Kırmızı at birinci olursa $7500 kazanacaksın.");
            }
            else
            {
                HorseInformation.text = "Red Horse: $2500, Prize: $7500";
                _GameManager.DisplayMiniMessage("If the red horse comes first, you will win $7500.");
            }
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(_GameManager.Money - 2500) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(_GameManager.Money - 2500) + " short."); }
        }
    }

    public void PlayGame5()
    {
        if (_GameManager.Money >= 100)
        {
            yellow1.SetActive(false);
            Plays5 = true;
            _GameManager.Money -= 100;
            _GameManager.Blur.SetActive(true);
            SetupGame();
            if (_GameManager.L)
            {
                HorseInformation.text = "Sarı At: $100, Ödül: $300";
                _GameManager.DisplayMiniMessage("Sarı at birinci olursa $300 kazanacaksın.");
            }
            else
            {
                HorseInformation.text = "Yellow Horse: $100, Prize: $300";
                _GameManager.DisplayMiniMessage("If the yellow horse comes first, you will win $300.");
            }
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(_GameManager.Money - 100) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(_GameManager.Money - 100) + " short."); }
        }
    }

    public void PlayGame6()
    {
        if (_GameManager.Money >= 500)
        {
            yellow2.SetActive(false);
            Plays6 = true;
            _GameManager.Money -= 500;
            _GameManager.Blur.SetActive(true);
            SetupGame();
            if (_GameManager.L)
            {
                HorseInformation.text = "Sarı At: $500, Ödül: $1500";
                _GameManager.DisplayMiniMessage("Sarı at birinci olursa $1500 kazanacaksın.");
            }
            else
            {
                HorseInformation.text = "Yellow Horse: $500, Prize: $1500";
                _GameManager.DisplayMiniMessage("If the yellow horse comes first, you will win $1500.");
            }
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(_GameManager.Money - 500) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(_GameManager.Money - 500) + " short."); }
        }
    }

    public void PlayGame7()
    {
        if (_GameManager.Money >= 1000)
        {
            yellow3.SetActive(false);
            Plays7 = true;
            _GameManager.Money -= 1000;
            _GameManager.Blur.SetActive(true);
            SetupGame();
            if (_GameManager.L)
            {
                HorseInformation.text = "Sarı At: $1000, Ödül: $3000";
                _GameManager.DisplayMiniMessage("Sarı at birinci olursa $3000 kazanacaksın.");
            }
            else
            {
                HorseInformation.text = "Yellow Horse: $1000, Prize: $3000";
                _GameManager.DisplayMiniMessage("If the yellow horse comes first, you will win $3000.");
            }
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(_GameManager.Money - 1000) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(_GameManager.Money - 1000) + " short."); }
        }
    }

    public void PlayGame8()
    {
        if (_GameManager.Money >= 2500)
        {
            yellow4.SetActive(false);
            Plays8 = true;
            _GameManager.Money -= 2500;
            _GameManager.Blur.SetActive(true);
            SetupGame();
            if (_GameManager.L)
            {
                HorseInformation.text = "Sarı At: $2500, Ödül: $7500";
                _GameManager.DisplayMiniMessage("Sarı at birinci olursa $7500 kazanacaksın.");
            }
            else
            {
                HorseInformation.text = "Yellow Horse: $2500, Prize: $7500";
                _GameManager.DisplayMiniMessage("If the yellow horse comes first, you will win $7500.");
            }
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(_GameManager.Money - 2500) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(_GameManager.Money - 2500) + " short."); }
        }
    }

    public void PlayGame9()
    {
        if (_GameManager.Money >= 100)
        {
            blue1.SetActive(false);
            Plays9 = true;
            _GameManager.Money -= 100;
            _GameManager.Blur.SetActive(true);
            SetupGame();
            if (_GameManager.L)
            {
                HorseInformation.text = "Mavi At: $100, Ödül: $300";
                _GameManager.DisplayMiniMessage("Mavi at birinci olursa $300 kazanacaksın.");
            }
            else
            {
                HorseInformation.text = "Blue Horse: $100, Prize: $300";
                _GameManager.DisplayMiniMessage("If the blue horse comes first, you will win $300.");
            }
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(_GameManager.Money - 100) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(_GameManager.Money - 100) + " short."); }
        }
    }

    public void PlayGame10()
    {
        if (_GameManager.Money >= 500)
        {
            blue2.SetActive(false);
            Plays10 = true;
            _GameManager.Money -= 500;
            _GameManager.Blur.SetActive(true);
            SetupGame();
            if (_GameManager.L)
            {
                HorseInformation.text = "Mavi At: $500, Ödül: $1500";
                _GameManager.DisplayMiniMessage("Mavi at birinci olursa $1500 kazanacaksın.");
            }
            else
            {
                HorseInformation.text = "Blue Horse: $500, Prize: $1500";
                _GameManager.DisplayMiniMessage("If the blue horse comes first, you will win $1500.");
            }
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(_GameManager.Money - 500) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(_GameManager.Money - 500) + " short."); }
        }
    }

    public void PlayGame11()
    {
        if (_GameManager.Money >= 1000)
        {
            blue3.SetActive(false);
            Plays11 = true;
            _GameManager.Money -= 1000;
            _GameManager.Blur.SetActive(true);
            SetupGame();
            if (_GameManager.L)
            {
                HorseInformation.text = "Mavi At: $1000, Ödül: $3000";
                _GameManager.DisplayMiniMessage("Mavi at birinci olursa $3000 kazanacaksın.");
            }
            else
            {
                HorseInformation.text = "Blue Horse: $1000, Prize: $3000";
                _GameManager.DisplayMiniMessage("If the blue horse comes first, you will win $3000.");
            }
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(_GameManager.Money - 1000) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(_GameManager.Money - 1000) + " short."); }
        }
    }

    public void PlayGame12()
    {
        if (_GameManager.Money >= 2500)
        {
            blue4.SetActive(false);
            Plays12 = true;
            _GameManager.Money -= 2500;
            _GameManager.Blur.SetActive(true);
            SetupGame();
            if (_GameManager.L)
            {
                HorseInformation.text = "Mavi At: $2500, Ödül: $7500";
                _GameManager.DisplayMiniMessage("Mavi at birinci olursa $7500 kazanacaksın.");
            }
            else
            {
                HorseInformation.text = "Blue Horse: $2500, Prize: $7500";
                _GameManager.DisplayMiniMessage("If the blue horse comes first, you will win $7500.");
            }
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(_GameManager.Money - 2500) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(_GameManager.Money - 2500) + " short."); }
        }
    }

    void Update()
    {
        if (timeLeft1 > 0)
        {
            timeLeft1 -= Random.Range(-0.10f, 0.35f);
            slider.value = timeLeft1 / maxTime1;
        }

        if (slider.value <= 0)
        {
            if (Plays1)
            {
                _GameManager.Money += 300;
                if (_GameManager.L) { _GameManager.DisplayMiniMessage("Tebrikler! $300 kazandın!"); }
                else { _GameManager.DisplayMiniMessage("Congratulations! You won $300!"); }
                _GameManager.Happiness += 2;

            }

            else if (Plays2)
            {
                _GameManager.Money += 1500;
                if (_GameManager.L) { _GameManager.DisplayMiniMessage("Tebrikler! $1500 kazandın!"); }
                else { _GameManager.DisplayMiniMessage("Congratulations! You won $1500!"); }
                _GameManager.Happiness += 2;
            }

            else if (Plays3)
            {
                _GameManager.Money += 3000;
                if (_GameManager.L) { _GameManager.DisplayMiniMessage("Tebrikler! $3000 kazandın!"); }
                else { _GameManager.DisplayMiniMessage("Congratulations! You won $3000!"); }
                _GameManager.Happiness += 2;
            }

            else if (Plays4)
            {
                _GameManager.Money += 7500;
                if (_GameManager.L) { _GameManager.DisplayMiniMessage("Tebrikler! $7500 kazandın!"); }
                else { _GameManager.DisplayMiniMessage("Congratulations! You won $7500!"); }
                _GameManager.Happiness += 2;
            }

            else
            {
                _GameManager.Happiness -= 1;
                _GameManager.AlertSound4.Play();
                if (_GameManager.L) { _GameManager.DisplayMiniMessage("Kaybettin!"); }
                else { _GameManager.DisplayMiniMessage("You lost!"); }
            }

            _GameManager.Blur.SetActive(false);
            _GameManager.BlurExit.SetActive(true);
            _GameManager.Invoke("HideBlurExit", 0.20f);

            PlaysFalse();
            SetActiveTrue();
            this.enabled = false;
            
            _GameManager.UpdateUI();
        }

        if (timeLeft2 > 0)
        {
            timeLeft2 -= Random.Range(-0.10f, 0.35f);
            slider2.value = timeLeft2 / maxTime2;
        }

        if (slider2.value <= 0)
        {
            if (Plays5)
            {
                _GameManager.Money += 300;
                if (_GameManager.L) { _GameManager.DisplayMiniMessage("Tebrikler! $300 kazandın!"); }
                else { _GameManager.DisplayMiniMessage("Congratulations! You won $300!"); }
                _GameManager.Happiness += 2;
            }
            else if (Plays6)
            {
                _GameManager.Money += 1500;
                if (_GameManager.L) { _GameManager.DisplayMiniMessage("Tebrikler! $1500 kazandın!"); }
                else { _GameManager.DisplayMiniMessage("Congratulations! You won $1500!"); }
                _GameManager.Happiness += 2;
            }
            else if (Plays7)
            {
                _GameManager.Money += 3000;
                if (_GameManager.L) { _GameManager.DisplayMiniMessage("Tebrikler! $3000 kazandın!"); }
                else { _GameManager.DisplayMiniMessage("Congratulations! You won $3000!"); }
                _GameManager.Happiness += 2;
            }
            else if (Plays8)
            {
                _GameManager.Money += 7500;
                if (_GameManager.L) { _GameManager.DisplayMiniMessage("Tebrikler! $7500 kazandın!"); }
                else { _GameManager.DisplayMiniMessage("Congratulations! You won $7500!"); }
                _GameManager.Happiness += 2;
            }
            else
            {
                _GameManager.Happiness -= 1;
                _GameManager.AlertSound4.Play();
                if (_GameManager.L) { _GameManager.DisplayMiniMessage("Kaybettin!"); }
                else { _GameManager.DisplayMiniMessage("You lost!"); }
            }

            _GameManager.Blur.SetActive(false);
            _GameManager.BlurExit.SetActive(true);
            _GameManager.Invoke("HideBlurExit", 0.20f);

            PlaysFalse();
            SetActiveTrue();
            this.enabled = false;

            _GameManager.UpdateUI();
        }

        if (timeLeft3 > 0)
        {
            timeLeft3 -= Random.Range(-0.10f, 0.35f);
            slider3.value = timeLeft3 / maxTime3;
        }

        if (slider3.value <= 0)
        {
            if (Plays9)
            {
                _GameManager.Money += 300;
                if (_GameManager.L) { _GameManager.DisplayMiniMessage("Tebrikler! $300 kazandın!"); }
                else { _GameManager.DisplayMiniMessage("Congratulations! You won $300!"); }
                _GameManager.Happiness += 2;
            }
            else if (Plays10)
            {
                _GameManager.Money += 1500;
                if (_GameManager.L) { _GameManager.DisplayMiniMessage("Tebrikler! $1500 kazandın!"); }
                else { _GameManager.DisplayMiniMessage("Congratulations! You won $1500!"); }
                _GameManager.Happiness += 2;
            }
            else if (Plays11)
            {
                _GameManager.Money += 3000;
                if (_GameManager.L) { _GameManager.DisplayMiniMessage("Tebrikler! $3000 kazandın!"); }
                else { _GameManager.DisplayMiniMessage("Congratulations! You won $3000!"); }
                _GameManager.Happiness += 2;
            }
            else if (Plays12)
            {
                _GameManager.Money += 7500;
                if (_GameManager.L) { _GameManager.DisplayMiniMessage("Tebrikler! $7500 kazandın!"); }
                else { _GameManager.DisplayMiniMessage("Congratulations! You won $7500!"); }
                _GameManager.Happiness += 2;
            }
            else
            {
                _GameManager.Happiness -= 1;
                _GameManager.AlertSound4.Play();
                if (_GameManager.L) { _GameManager.DisplayMiniMessage("Kaybettin!"); }
                else { _GameManager.DisplayMiniMessage("You lost!"); }
            }

            _GameManager.Blur.SetActive(false);
            _GameManager.BlurExit.SetActive(true);
            _GameManager.Invoke("HideBlurExit", 0.20f);

            PlaysFalse();
            SetActiveTrue();
            this.enabled = false;

            _GameManager.UpdateUI();
        }
    }
}
