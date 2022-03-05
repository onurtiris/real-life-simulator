using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrestigeBonus : MonoBehaviour
{
    GameManager _GameManager;

    public Sprite NoBonusBackground;
    public Sprite BonusBackground;

    public Sprite NoBonusHorizontalLine;
    public Sprite BonusHorizontalLine;

    public Image HorizontalLineImage1;
    public Image HorizontalLineImage2;
    public Image HorizontalLineImage3;
    public Image HorizontalLineImage4;

    public Image VerticalLineImage;
    public Sprite NoBonusVerticalLine;
    public Sprite BonusVerticalLine;

    public Text Bonus1Text;
    public Text Bonus1PriceText;
    public Image Bonus1Background;

    public Text Bonus2Text;
    public Text Bonus2PriceText;
    public Image Bonus2Background;

    public Text Bonus3Text;
    public Text Bonus3PriceText;
    public Image Bonus3Background;

    public Text Bonus4Text;
    public Text Bonus4PriceText;
    public Image Bonus4Background;

    public Text Bonus5Text;
    public Text Bonus5PriceText;
    public Image Bonus5Background;

    public Text Bonus6Text;
    public Text Bonus6PriceText;
    public Image Bonus6Background;

    int Prestige;
    int PrestigeBonusPrice;

    public GameObject PrestigeBonusProgressionPanel;
    public Text BonusButtonText;
    public Button BonusButton;

    public GameObject Blur;
    public GameObject BlurExit;

    void Start()
    {
        GM();
        Setup();
    }

    public void GM()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void HideBlurExit()
    {
        BlurExit.SetActive(false);
    }
    public void Setup()
    {
        Blur.SetActive(true);

        Prestige = PlayerPrefs.GetInt("Prestige");
        BonusButton.interactable = true;

        if (_GameManager.L)
        {
            if (Prestige < 0) { PrestigeBonusPrice = 50; }
            if (Prestige >= 0) { Bonus1Text.text = "İtibar +0%"; Bonus1PriceText.text = "$150"; PrestigeBonusPrice = 150; Bonus1Background.sprite = BonusBackground; HorizontalLineImage1.sprite = BonusHorizontalLine; } else { Bonus1Background.sprite = NoBonusBackground; Bonus1Text.text = "<color='#928668'>İtibar +0%</color>"; Bonus1PriceText.text = "<color='#A89D81'>$150</color>"; }
            if (Prestige >= 20) { Bonus2Text.text = "İtibar +20%"; Bonus2PriceText.text = "$200"; PrestigeBonusPrice = 350; Bonus2Background.sprite = BonusBackground; } else { Bonus2Background.sprite = NoBonusBackground; Bonus2Text.text = "<color='#928668'>İtibar +20%</color>"; Bonus2PriceText.text = "<color='#A89D81'>$200</color>"; HorizontalLineImage1.sprite = NoBonusHorizontalLine; }
            if (Prestige >= 35) { Bonus3Text.text = "İtibar +35%"; Bonus3PriceText.text = "$250"; PrestigeBonusPrice = 600; Bonus3Background.sprite = BonusBackground; HorizontalLineImage2.sprite = BonusHorizontalLine; } else { Bonus3Background.sprite = NoBonusBackground; Bonus3Text.text = "<color='#928668'>İtibar +35%</color>"; Bonus3PriceText.text = "<color='#A89D81'>$250</color>"; HorizontalLineImage2.sprite = NoBonusHorizontalLine; }
            if (Prestige >= 55) { Bonus4Text.text = "İtibar +55%"; Bonus4PriceText.text = "$300"; PrestigeBonusPrice = 900; Bonus4Background.sprite = BonusBackground; VerticalLineImage.sprite = BonusVerticalLine; } else { Bonus4Background.sprite = NoBonusBackground; Bonus4Text.text = "<color='#928668'>İtibar +55%</color>"; Bonus4PriceText.text = "<color='#A89D81'>$300</color>"; VerticalLineImage.sprite = NoBonusVerticalLine; }
            if (Prestige >= 80) { Bonus5Text.text = "İtibar +80%"; Bonus5PriceText.text = "$700"; PrestigeBonusPrice = 1600; Bonus5Background.sprite = BonusBackground; HorizontalLineImage3.sprite = BonusHorizontalLine; } else { Bonus5Background.sprite = NoBonusBackground; Bonus5Text.text = "<color='#928668'>İtibar +80%</color>"; Bonus5PriceText.text = "<color='#A89D81'>$700</color>"; HorizontalLineImage3.sprite = NoBonusHorizontalLine; }
            if (Prestige >= 100) { Bonus6Text.text = "İtibar 100%"; Bonus6PriceText.text = "$900"; PrestigeBonusPrice = 2500; Bonus6Background.sprite = BonusBackground; HorizontalLineImage4.sprite = BonusHorizontalLine; } else { Bonus6Background.sprite = NoBonusBackground; Bonus6Text.text = "<color='#928668'>İtibar 100%</color>"; Bonus6PriceText.text = "<color='#A89D81'>$900</color>"; HorizontalLineImage4.sprite = NoBonusHorizontalLine; }
            BonusButtonText.text = "$" + PrestigeBonusPrice + " bonus çek";
        }
        else
        {
            if (Prestige < 0) { PrestigeBonusPrice = 50; }
            if (Prestige >= 0) { Bonus1Text.text = "<size='28'>Prestige </size>+0%"; Bonus1PriceText.text = "$150"; PrestigeBonusPrice = 150; Bonus1Background.sprite = BonusBackground; HorizontalLineImage1.sprite = BonusHorizontalLine; } else { Bonus1Background.sprite = NoBonusBackground; Bonus1Text.text = "<color='#928668'><size='28'>Prestige </size>+0%</color>"; Bonus1PriceText.text = "<color='#A89D81'>$150</color>"; }
            if (Prestige >= 20) { Bonus2Text.text = "<size='28'>Prestige </size>+20%"; Bonus2PriceText.text = "$200"; PrestigeBonusPrice = 350; Bonus2Background.sprite = BonusBackground; } else { Bonus2Background.sprite = NoBonusBackground; Bonus2Text.text = "<color='#928668'><size='28'>Prestige </size>+20%</color>"; Bonus2PriceText.text = "<color='#A89D81'>$200</color>"; HorizontalLineImage1.sprite = NoBonusHorizontalLine; }
            if (Prestige >= 35) { Bonus3Text.text = "<size='28'>Prestige </size>+35%"; Bonus3PriceText.text = "$250"; PrestigeBonusPrice = 600; Bonus3Background.sprite = BonusBackground; HorizontalLineImage2.sprite = BonusHorizontalLine; } else { Bonus3Background.sprite = NoBonusBackground; Bonus3Text.text = "<color='#928668'><size='28'>Prestige </size>+35%</color>"; Bonus3PriceText.text = "<color='#A89D81'>$250</color>"; HorizontalLineImage2.sprite = NoBonusHorizontalLine; }
            if (Prestige >= 55) { Bonus4Text.text = "<size='28'>Prestige </size>+55%"; Bonus4PriceText.text = "$300"; PrestigeBonusPrice = 900; Bonus4Background.sprite = BonusBackground; VerticalLineImage.sprite = BonusVerticalLine; } else { Bonus4Background.sprite = NoBonusBackground; Bonus4Text.text = "<color='#928668'><size='28'>Prestige </size>+55%</color>"; Bonus4PriceText.text = "<color='#A89D81'>$300</color>"; VerticalLineImage.sprite = NoBonusVerticalLine; }
            if (Prestige >= 80) { Bonus5Text.text = "<size='28'>Prestige </size>+80%"; Bonus5PriceText.text = "$700"; PrestigeBonusPrice = 1600; Bonus5Background.sprite = BonusBackground; HorizontalLineImage3.sprite = BonusHorizontalLine; } else { Bonus5Background.sprite = NoBonusBackground; Bonus5Text.text = "<color='#928668'><size='28'>Prestige </size>+80%</color>"; Bonus5PriceText.text = "<color='#A89D81'>$700</color>"; HorizontalLineImage3.sprite = NoBonusHorizontalLine; }
            if (Prestige >= 100) { Bonus6Text.text = "<size='28'>Prestige </size>100%"; Bonus6PriceText.text = "$900"; PrestigeBonusPrice = 2500; Bonus6Background.sprite = BonusBackground; HorizontalLineImage4.sprite = BonusHorizontalLine; } else { Bonus6Background.sprite = NoBonusBackground; Bonus6Text.text = "<color='#928668'><size='28'>Prestige </size>100%</color>"; Bonus6PriceText.text = "<color='#A89D81'>$900</color>"; HorizontalLineImage4.sprite = NoBonusHorizontalLine; }
            BonusButtonText.text = "Withdraw $" + PrestigeBonusPrice + " bonus";
        }
    }

    public void CloseButton()
    {
        PrestigeBonusProgressionPanel.SetActive(false);
        Blur.SetActive(false);
        BlurExit.SetActive(true);
        Invoke("HideBlurExit", 0.20f);
    }

    public void WithdrawBonus()
    {
        _GameManager.Money += PrestigeBonusPrice;
        if (_GameManager.L)
        {
            _GameManager.DisplayMiniMessage("$" + PrestigeBonusPrice + " itibar bonusu çekildi.");
            BonusButtonText.text = "Bonus yok";
        }
        else
        {
            _GameManager.DisplayMiniMessage("$" + PrestigeBonusPrice + " prestige bonus withdrawn.");
            BonusButtonText.text = "No bonus";
        }
        
        BonusButton.interactable = false;
        _GameManager.Day += 1;
        _GameManager.SkipCheckEvent = true;
        _GameManager.BalloonDay = _GameManager.Day + _GameManager.BalloonDayAmount;
        _GameManager.UpdateUI();
    }
}
