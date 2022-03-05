using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bank : MonoBehaviour
{
    GameManager _GameManager;

    public int Installment, MaximumLoan;
    public double Debt;
    public Text DebtText;
    public Text InstallmentText;
    public Text MaximumLoanText;

    public GameObject BankPanel;

    public Button Pay100;
    public Button Pay500;
    public Button Pay1000;
    public Button Pay5000;
    public Button Pay10000;
    public Button PayMax;

    public Button Get100;
    public Button Get500;
    public Button Get1000;
    public Button Get5000;
    public Button Get10000;
    public Button GetMax;

    void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Debt = _GameManager.Debt;
        MaximumLoan = _GameManager.MaximumLoan;

        UpdateText();
    }

    public void UpdateText()
    {
        if (Debt <= 1){ Debt = 0; }

        if (Debt <= 0)
        {
            MaximumLoan = (_GameManager.Money) / 4;

            if (_GameManager.Money >= 1000000000) { MaximumLoan = (MaximumLoan - (MaximumLoan % 100000000)); }
            else if (_GameManager.Money >= 100000000) { MaximumLoan = (MaximumLoan - (MaximumLoan % 10000000)); }
            else if (_GameManager.Money >= 10000000) { MaximumLoan = (MaximumLoan - (MaximumLoan % 1000000)); }
            else if (_GameManager.Money >= 1000000) { MaximumLoan = (MaximumLoan - (MaximumLoan % 100000)); }
            else if (_GameManager.Money >= 100000) { MaximumLoan = (MaximumLoan - (MaximumLoan % 10000)); }
            else if (_GameManager.Money >= 10000) { MaximumLoan = (MaximumLoan - (MaximumLoan % 1000)); }
            else if (_GameManager.Money >= 2000) { MaximumLoan = (MaximumLoan - (MaximumLoan % 100)); }
            else { MaximumLoan = 500; }
        }

        Installment = (int)(Debt / 4);
        _GameManager.Debt = (int)Debt;
        _GameManager.MaximumLoan = MaximumLoan;
        MaximumLoanText.text = "$" + MaximumLoan;
        DebtText.text = "$" + (int)Debt;

        if (Installment <= 0)
        {
            if (_GameManager.L) { InstallmentText.text = "Bankaya borcunuz yoktur"; }
            else { InstallmentText.text = "You don't owe the bank"; }  
        }
        else
        {
            if (_GameManager.L) { InstallmentText.text = "Faiz bedeli olarak her ay $" + Installment + " ödenecektir"; }
            else { InstallmentText.text = "$" + Installment + " will be paid each month in interest"; }
        }
    }

    public void MaxGetLoanButton()
    {
        if (MaximumLoan >= 1) { GetLoan(MaximumLoan); }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMessage("Kredi limitini aştınız.\n<color='#D9C89D'>Yeni bir kredi için önce borcunuzu ödeyin.</color>"); }
            else { _GameManager.DisplayMessage("You have exceeded the loan limit.\n<color='#D9C89D'>Pay off your debt first for a new loan.</color>"); }
        }
    }

    public void MaxPayLoanButton()
    {
        if ((int)Debt == 0)
        {
            if (_GameManager.L) { _GameManager.DisplayMessage("Borcunuz yoktur."); }
            else { _GameManager.DisplayMessage("You have no debt."); }
            return;
        }

        if (_GameManager.Money >= (int)Debt) { PayLoan((int)Debt); }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs((int)Debt - _GameManager.Money) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs((int)Debt - _GameManager.Money) + " short."); } 
        }
    }

    public void GetLoan(int Amount)
    {
        if (Amount > MaximumLoan)
        {
            if (_GameManager.L) { _GameManager.DisplayMessage("Kredi limitini aştınız.\n<color='#D9C89D'>Yeni bir kredi için önce borcunuzu ödeyin.</color>"); }
            else { _GameManager.DisplayMessage("You have exceeded the loan limit.\n<color='#D9C89D'>Pay off your debt first for a new loan.</color>"); }
            return;
        }

        _GameManager.Money += Amount;
        MaximumLoan -= Amount;
        Debt += (double)(Amount + (Amount * 0.20));

        if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Amount + " kredi çektiniz."); }
        else { _GameManager.DisplayMiniMessage("You took out a $" + Amount + " loan."); }

        UpdateText();
        _GameManager.UpdateUI();
    }

    public void PayLoan(int Amount)
    {
        if ((int)Debt == 0)
        {
            if (_GameManager.L) { _GameManager.DisplayMessage("Borcunuz yoktur."); }
            else { _GameManager.DisplayMessage("You have no debt."); }
            return;
        }

        if ((int)Debt < Amount)
        {
            if (_GameManager.L) { _GameManager.DisplayMessage("Bu miktar borcun üstünde."); }
            else { _GameManager.DisplayMessage("This amount is above debt."); }
            return;
        }

        if (_GameManager.Money < Amount)
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(Amount - _GameManager.Money) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(Amount - _GameManager.Money) + " short."); }
            return;
        }

        _GameManager.Money -= Amount;
        Debt -= Amount;

        if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Amount + " kredi ödediniz."); }
        else { _GameManager.DisplayMiniMessage("You paid $" + Amount + " loan."); }
        
        UpdateText();
        _GameManager.UpdateUI();
    }

    public void CloseButton()
    {
        BankPanel.SetActive(false);
        UpdateText();
    }

    void Update()
    {
        if(MaximumLoan > 0)
        {
            if (MaximumLoan < 100) { Get100.interactable = false; } else { Get100.interactable = true; }
            if (MaximumLoan < 500) { Get500.interactable = false; } else { Get500.interactable = true; }
            if (MaximumLoan < 1000) { Get1000.interactable = false; } else { Get1000.interactable = true; }
            if (MaximumLoan < 5000) { Get5000.interactable = false; } else { Get5000.interactable = true; }
            if (MaximumLoan < 10000) { Get10000.interactable = false; } else { Get10000.interactable = true; }
            GetMax.interactable = true;
        }
        else
        {
            Get10000.interactable = false; Get5000.interactable = false; Get1000.interactable = false; Get500.interactable = false; Get100.interactable = false; GetMax.interactable = false;
        }

        if (Debt > 0)
        {
            if (_GameManager.Money < 10000 || Debt < 10000) { Pay10000.interactable = false; } else { Pay10000.interactable = true; }
            if (_GameManager.Money < 5000 || Debt < 5000) { Pay5000.interactable = false; } else { Pay5000.interactable = true; }
            if (_GameManager.Money < 1000 || Debt < 1000) { Pay1000.interactable = false; } else { Pay1000.interactable = true; }
            if (_GameManager.Money < 500 || Debt < 500) { Pay500.interactable = false; } else { Pay500.interactable = true; }
            if (_GameManager.Money < 100 || Debt < 100) { Pay100.interactable = false; } else { Pay100.interactable = true; }
            PayMax.interactable = true;
        }
        else
        {
            Pay10000.interactable = false; Pay5000.interactable = false; Pay1000.interactable = false; Pay500.interactable = false; Pay100.interactable = false; PayMax.interactable = false;
        }
    }
}
