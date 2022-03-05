using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseGame : MonoBehaviour
{
    GameManager _GameManager;
    public Text CaseGameMessageText;
    public float Second;
    public Text TimeText;
    public Text OpenedCaseText;
    public Text P1Text;
    public Text P2Text;
    public Text P3Text;
    public Text P4Text;

    public Text P1CheckText;
    public Text P2CheckText;
    public Text P3CheckText;
    public Text P4CheckText;

    int P1, P2, P3, P4;
    int RandomCensor;
    int P1Check, P2Check, P3Check, P4Check;
    int OpenedCase;
    int RandomPrize;
    int TotalPrize;

    public GameObject BackButton;

    public GameObject CaseMiniGamePanel;
    public GameObject CaseGamePanel;
    public GameObject InformationPanel;

    public GameObject StartButton;
    public GameObject StopButton;

    public Image BackgroundImage;
    public Sprite WithCharacter;
    public Sprite flat;

    public void CloseButton()
    {
        BackButton.SetActive(true);
        CaseGamePanel.SetActive(false);
        StartButton.SetActive(true);
        StopButton.SetActive(true);
        DefaultValues();
        CaseMiniGamePanel.SetActive(false);
        InformationPanel.SetActive(true);
        BackgroundImage.sprite = WithCharacter;
        if (_GameManager.L) { CaseGameMessageText.text = "<color='#3DB4C9'>Gizemli Adam: </color>Dostum elimdeki kasaların şifrelerini kırar mısın? Eminim içerisinde <color='#C1AF80'>değerli şeyler</color> vardır."; }
        else { CaseGameMessageText.text = "<color='#3DB4C9'>Mysterious Man: </color>Dude, can you crack the codes on my safes? I'm sure it has <color='#C1AF80'>something valuable</color> in it."; }
        this.enabled = false;
        _GameManager.ShopDisplayPanel.SetActive(false);
        _GameManager.ShopBlur.SetActive(false);
        _GameManager.BlurExit.SetActive(true);
        _GameManager.Invoke("HideBlurExit", 0.20f);
        _GameManager.ParkBool = false;
    }

    public void DontGetTheJob()
    {
        BackButton.SetActive(true);
        CaseGamePanel.SetActive(false);
        StartButton.SetActive(true);
        StopButton.SetActive(true);
        DefaultValues();
        CaseMiniGamePanel.SetActive(false);
        InformationPanel.SetActive(true);
        BackgroundImage.sprite = WithCharacter;
        if (_GameManager.L) { CaseGameMessageText.text = "<color='#3DB4C9'>Gizemli Adam: </color>Dostum elimdeki kasaların şifrelerini kırar mısın? Eminim içerisinde <color='#C1AF80'>değerli şeyler</color> vardır."; }
        else { CaseGameMessageText.text = "<color='#3DB4C9'>Mysterious Man: </color>Dude, can you crack the codes on my safes? I'm sure it has <color='#C1AF80'>something valuable</color> in it."; }
        this.enabled = false;
    }

    void Start()
    {
        this.enabled = true;
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void DefaultValues()
    {
        Second = 30;
        OpenedCase = 0;

        if (_GameManager.L) { OpenedCaseText.text = "KASA NO: " + (OpenedCase + 1); }
        else { OpenedCaseText.text = "CASE NO: " + (OpenedCase + 1); }
        
        TotalPrize = 0;
        P1Check = 1;
        P2Check = 2;
        P3Check = 3;
        P4Check = 4;
        P1CheckText.text = "" + P1Check;
        P2CheckText.text = "" + P2Check;
        P3CheckText.text = "" + P3Check;
        P4CheckText.text = "" + P4Check;
    }

    public void StartTheGame()
    {
        Start();
        BackButton.SetActive(false);

        if (_GameManager.BoolItems[27] == 1)
        {
            DefaultValues();

            GeneratePassword();

            CaseMiniGamePanel.SetActive(true);
            InformationPanel.SetActive(false);
            BackgroundImage.sprite = flat;
            _GameManager.CaseEvent = false;

            _GameManager.BoolItems[27] = 0;


            CheckProcessItem();
            _GameManager.AllGameItems[27].ItemCostText.text = "$" + _GameManager.AllGameItems[27].ConvertNegative.Substring(1);
            
            _GameManager.UpdateUI();
            _GameManager.SaveLoad();
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Bunun için " + _GameManager.AllGameItems[27].ToString().Substring(0, _GameManager.AllGameItems[27].ToString().Length - 7) + " gereklidir."); }
            else { _GameManager.DisplayMiniMessage("The Key is required for this."); }
            
            BackButton.SetActive(true);
            this.enabled = false;
        }
    }

    public void CheckProcessItem()
    {
        for (int i = 0; i < ((_GameManager.BoolItems).Length); i++)
        {
            if (_GameManager.BoolItems[i] == 0)
            {
                _GameManager.AllGameItems[i].Purchased = false;
                PlayerPrefs.SetInt("boolitem" + (i + 1), 0);
            }
            if (_GameManager.BoolItems[i] == 1)
            {
                _GameManager.AllGameItems[i].Purchased = true;
            }

            if (_GameManager.AllGameItems[i].OneTimePurchase && _GameManager.AllGameItems[i].Purchased)
            {
                _GameManager.AllGameItems[i].Purchased = true;
                _GameManager.AllGameItems[i].ItemIcon.enabled = true;
                PlayerPrefs.SetInt("boolitem" + (i + 1), 1);
            }
            else
            {
                _GameManager.AllGameItems[i].ItemIcon.enabled = false;
            }
        }

        _GameManager.SaveData();
    }

    public void CheckButton1()
    {
        if (P1Check >= 4){ P1Check = 1; }
        else { P1Check += 1; }

        P1CheckText.text = "" + P1Check;
    }

    public void CheckButton2()
    {
        if (P2Check >= 4){ P2Check = 1; }
        else { P2Check += 1; }

        P2CheckText.text = "" + P2Check;
    }

    public void CheckButton3()
    {
        if (P3Check >= 4){ P3Check = 1; }
        else { P3Check += 1; }

        P3CheckText.text = "" + P3Check;
    }

    public void CheckButton4()
    {
        if (P4Check >= 4){ P4Check = 1; }
        else { P4Check += 1; }

        P4CheckText.text = "" + P4Check;
    }

    public void GeneratePassword()
    {
        P1 = Random.Range(1, 5);
        P2 = Random.Range(1, 5);
        P3 = Random.Range(1, 5);
        P4 = Random.Range(1, 5);

        RandomCensor = Random.Range(0, 6);
        switch (RandomCensor)
        {
            case 0:
            P1Text.text = "" + P1; P2Text.text = "" + P2; P3Text.text = "*"; P4Text.text = "*";
            break;
            case 1:
            P1Text.text = "*"; P2Text.text = "*"; P3Text.text = "" + P3; P4Text.text = "" + P4;
            break;
            case 2:
            P1Text.text = "*"; P2Text.text = "" + P2; P3Text.text = "" + P3; P4Text.text = "*";
            break;
            case 3:
            P1Text.text = "" + P1; P2Text.text = "*"; P3Text.text = "*"; P4Text.text = "" + P4;
            break;
            case 4:
            P1Text.text = "" + P1; P2Text.text = "*"; P3Text.text = "" + P3; P4Text.text = "*";
            break;
            case 5:
            P1Text.text = "*"; P2Text.text = "" + P2; P3Text.text = "*"; P4Text.text = "" + P4;
            break;
        }
    }

    void Update()
    {
        if (P1Check == P1 && P2Check == P2 && P3Check == P3 && P4Check == P4)
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Şifre doğru!"); }
            else { _GameManager.DisplayMiniMessage("Password is correct!"); }
            
            GeneratePassword();
            OpenedCase += 1;

            if (_GameManager.L) { OpenedCaseText.text = "KASA NO: " + (OpenedCase + 1); }
            else { OpenedCaseText.text = "CASE NO: " + (OpenedCase + 1); }
            
            if (_GameManager.L) { if (OpenedCase == 7) { Second = 0; _GameManager.DisplayMiniMessage("En fazla 7 tane kasa açabilirsiniz."); } }
            else { if (OpenedCase == 7) { Second = 0; _GameManager.DisplayMiniMessage("You can open up to 7 safes."); } }
        }

        Second -= Time.deltaTime;

        if (_GameManager.L) { TimeText.text = (int)Second + " SN"; }
        else { TimeText.text = (int)Second + " SEC"; }
        
        if (Second <= 0)
        {
            CaseMiniGamePanel.SetActive(false);
            InformationPanel.SetActive(true);
            BackgroundImage.sprite = WithCharacter;

            StartButton.SetActive(false);
            StopButton.SetActive(false);

            if (OpenedCase <= 0)
            {
                if (_GameManager.L) { CaseGameMessageText.text = "<color='#3DB4C9'>Gizemli Adam: </color>Hiç kasa açamadın.\n\n<color='#D9C89D'>" + _GameManager.RemoveHappinessText(2) + "</color>"; }
                else { CaseGameMessageText.text = "<color='#3DB4C9'>Mysterious Man: </color>You never opened a safe.\n\n<color='#D9C89D'>" + _GameManager.RemoveHappinessText(2) + "</color>"; }
                _GameManager.UpdateUI();
            }
            else
            {
                if (_GameManager.L) { CaseGameMessageText.text = "<color='#3DB4C9'>Gizemli Adam: </color>Kontrol edelim.\n"; }
                else { CaseGameMessageText.text = "<color='#3DB4C9'>Mysterious Man: </color>Let's check.\n"; }
                for (int i = 0; i < OpenedCase; i++)
                {
                    
                    if (i == (OpenedCase-1))
                    {
                        RandomPrize = Random.Range(5, 251);
                        if (_GameManager.L) { CaseGameMessageText.text += (i + 1) + ". kasadan <color='#D9C89D'>$" + RandomPrize + "</color>"; }
                        else { CaseGameMessageText.text += "<color='#D9C89D'>$" + RandomPrize + "</color> out of the " + (i + 1) + ". safe"; }
                        TotalPrize += RandomPrize;
                    }
                    else
                    {
                        RandomPrize = Random.Range(5, 151);
                        if (_GameManager.L) { CaseGameMessageText.text += (i + 1) + ". kasadan <color='#D9C89D'>$" + RandomPrize + "</color>, "; }
                        else { CaseGameMessageText.text += "<color='#D9C89D'>$" + RandomPrize + "</color> out of the " + (i + 1) + ". safe, "; }
                        TotalPrize += RandomPrize;
                    }
                }

                int WhichOne = Random.Range(1, 4);

                if(WhichOne == 1)
                {
                    if (_GameManager.L) { CaseGameMessageText.text += " çıktı ve toplam miktar <color='#D9C89D'>$" + TotalPrize + ",</color> bunu yarı yarıya paylaşalım.\n\n<color='#D9C89D'>Para $" + _GameManager.Money + " > $" + (_GameManager.Money + (TotalPrize / 2)) + "</color>"; }
                    else { CaseGameMessageText.text += " and the total amount is <color='#D9C89D'>$" + TotalPrize + ",</color> let's share it in half.\n<color='#D9C89D'>Money $" + _GameManager.Money + " > $" + (_GameManager.Money + (TotalPrize / 2)) + "</color>"; }
                    
                    _GameManager.Money += TotalPrize / 2;
                }
                else if (WhichOne == 2)
                {
                    if (_GameManager.L) { CaseGameMessageText.text += " çıktı ve toplam miktar <color='#D9C89D'>$" + TotalPrize + ",</color> yarıdan fazlasını ben alacağım.\n\n<color='#D9C89D'>Para $" + _GameManager.Money + " > $" + (_GameManager.Money + (TotalPrize / 3)) + "</color>"; }
                    else { CaseGameMessageText.text += " and the total amount is <color='#D9C89D'>$" + TotalPrize + ",</color> I'll take more than half.\n<color='#D9C89D'>Money $" + _GameManager.Money + " > $" + (_GameManager.Money + (TotalPrize / 3)) + "</color>"; }
                    
                    _GameManager.Money += TotalPrize / 3;
                }
                else
                {
                    if (_GameManager.L) { CaseGameMessageText.text += " çıktı ve toplam miktar <color='#D9C89D'>$" + TotalPrize + ",</color> yarıdan fazlasını sana vereceğim.\n\n<color='#D9C89D'>Para $" + _GameManager.Money + " > $" + (_GameManager.Money + ((TotalPrize / 2) + (TotalPrize / 4))) + "</color>"; }
                    else { CaseGameMessageText.text += " and the total amount is <color='#D9C89D'>$" + TotalPrize + ",</color> I'll give you more than half.\n<color='#D9C89D'>Money $" + _GameManager.Money + " > $" + (_GameManager.Money + ((TotalPrize / 2) + (TotalPrize / 4))) + "</color>"; }
                    
                    _GameManager.Money += (TotalPrize / 2) + (TotalPrize / 4);
                }
                
                _GameManager.UpdateUI();
            }
            this.enabled = false;
        }
    }
}
