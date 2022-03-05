using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumSlot : MonoBehaviour
{
    GameManager _GameManager;

    string[] NumbersRand = { "<color='#2FC39F'>1</color>", "<color='#F77F64'>2</color>", "<color='#7767E1'>3</color>", "0", "0", "<color='#2FC39F'>1</color>", "<color='#F77F64'>2</color>", "0", "0" };
    
    public Text SlotNum1;
    public Text SlotNum2;
    public Text SlotNum3;
    public Text StopText;

    public GameObject but1;
    public GameObject but2;
    public GameObject but3;
    public GameObject but4;
    public GameObject but5;
    public GameObject StopButton;
    public GameObject ProtectBlur;

    public Image SlotMachine;

    public Sprite Default;
    public Sprite Won;

    int BetCost;

    void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        SlotNum1.text = NumbersRand[Random.Range(0, NumbersRand.Length)].ToString();
        SlotNum2.text = NumbersRand[Random.Range(0, NumbersRand.Length)].ToString();
        SlotNum3.text = NumbersRand[Random.Range(0, NumbersRand.Length)].ToString();
    }

    public void OffEnable()
    {
        enabled = false;
        ProtectBlur.SetActive(false);
        _GameManager.Blur.SetActive(false);
        _GameManager.BlurExit.SetActive(true);
        _GameManager.Invoke("HideBlurExit", 0.20f);
        _GameManager.Happiness -= 1;

        if (SlotNum1.text == "<color='#2FC39F'>1</color>" && SlotNum2.text == "<color='#2FC39F'>1</color>" && SlotNum3.text == "<color='#2FC39F'>1</color>")
        {
            SlotMachine.sprite = Won;
            _GameManager.Money += BetCost * 4;
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Slot makinesinde $" + (BetCost * 4) + " kazandın."); }
            else { _GameManager.DisplayMiniMessage("You won $" + (BetCost * 4) + "on the slot machine."); }
            _GameManager.Happiness += 4;
        }
        else if (SlotNum1.text == "<color='#2FC39F'>1</color>" && SlotNum2.text == "<color='#2FC39F'>1</color>")
        {
            SlotMachine.sprite = Won;
            _GameManager.Money += BetCost * 2;
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Slot makinesinde $" + (BetCost * 2) + " kazandın."); }
            else { _GameManager.DisplayMiniMessage("You won $" + (BetCost * 2) + " on the slot machine."); }
            _GameManager.Happiness += 2;
        }
        else if (SlotNum2.text == "<color='#2FC39F'>1</color>" && SlotNum3.text == "<color='#2FC39F'>1</color>")
        {
            SlotMachine.sprite = Won;
            _GameManager.Money += BetCost * 2;
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Slot makinesinde $" + (BetCost * 2) + " kazandın."); }
            else { _GameManager.DisplayMiniMessage("You won $" + (BetCost * 2) + " on the slot machine."); }
            _GameManager.Happiness += 2;
        }
        else if (SlotNum1.text == "<color='#2FC39F'>1</color>" && SlotNum3.text == "<color='#2FC39F'>1</color>")
        {
            SlotMachine.sprite = Won;
            _GameManager.Money += BetCost * 2;
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Slot makinesinde $" + (BetCost * 2) + " kazandın."); }
            else { _GameManager.DisplayMiniMessage("You won $" + (BetCost * 2) + " on the slot machine."); }
            _GameManager.Happiness += 2;
        }
        else if (SlotNum1.text == "<color='#F77F64'>2</color>" && SlotNum2.text == "<color='#F77F64'>2</color>" && SlotNum3.text == "<color='#F77F64'>2</color>")
        {
            SlotMachine.sprite = Won;
            _GameManager.Money += BetCost * 6;
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Slot makinesinde $" + (BetCost * 6) + " kazandın."); }
            else { _GameManager.DisplayMiniMessage("You won $" + (BetCost * 6) + " on the slot machine."); }
            _GameManager.Happiness += 6;
        }
        else if (SlotNum1.text == "<color='#F77F64'>2</color>" && SlotNum2.text == "<color='#F77F64'>2</color>")
        {
            SlotMachine.sprite = Won;
            _GameManager.Money += BetCost * 3;
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Slot makinesinde $" + (BetCost * 3) + " kazandın."); }
            else { _GameManager.DisplayMiniMessage("You won $" + (BetCost * 3) + " on the slot machine."); }
            _GameManager.Happiness += 3;
        }
        else if (SlotNum2.text == "<color='#F77F64'>2</color>" && SlotNum3.text == "<color='#F77F64'>2</color>")
        {
            SlotMachine.sprite = Won;
            _GameManager.Money += BetCost * 3;
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Slot makinesinde $" + (BetCost * 3) + " kazandın."); }
            else { _GameManager.DisplayMiniMessage("You won $" + (BetCost * 3) + " on the slot machine."); }
            _GameManager.Happiness += 3;
        }
        else if (SlotNum1.text == "<color='#F77F64'>2</color>" && SlotNum3.text == "<color='#F77F64'>2</color>")
        {
            SlotMachine.sprite = Won;
            _GameManager.Money += BetCost * 3;
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Slot makinesinde $" + (BetCost * 3) + " kazandın."); }
            else { _GameManager.DisplayMiniMessage("You won $" + (BetCost * 3) + " on the slot machine."); }
            _GameManager.Happiness += 3;
        }
        else if (SlotNum1.text == "<color='#7767E1'>3</color>" && SlotNum2.text == "<color='#7767E1'>3</color>" && SlotNum3.text == "<color='#7767E1'>3</color>")
        {
            SlotMachine.sprite = Won;
            _GameManager.Money += BetCost * 8;
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Slot makinesinde $" + (BetCost * 8) + " kazandın."); }
            else { _GameManager.DisplayMiniMessage("You won $" + (BetCost * 8) + " on the slot machine."); }
            _GameManager.Happiness += 11;
        }
        else if (SlotNum1.text == "<color='#7767E1'>3</color>" && SlotNum2.text == "<color='#7767E1'>3</color>")
        {
            SlotMachine.sprite = Won;
            _GameManager.Money += BetCost * 4;
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Slot makinesinde $" + (BetCost * 4) + " kazandın."); }
            else { _GameManager.DisplayMiniMessage("You won $" + (BetCost * 4) + " on the slot machine."); }
            _GameManager.Happiness += 4;
        }
        else if (SlotNum2.text == "<color='#7767E1'>3</color>" && SlotNum3.text == "<color='#7767E1'>3</color>")
        {
            SlotMachine.sprite = Won;
            _GameManager.Money += BetCost * 4;
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Slot makinesinde $" + (BetCost * 4) + " kazandın."); }
            else { _GameManager.DisplayMiniMessage("You won $" + (BetCost * 4) + " on the slot machine."); }
            _GameManager.Happiness += 4;
        }
        else if (SlotNum1.text == "<color='#7767E1'>3</color>" && SlotNum3.text == "<color='#7767E1'>3</color>")
        {
            SlotMachine.sprite = Won;
            _GameManager.Money += BetCost * 4;
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Slot makinesinde $" + (BetCost * 4) + " kazandın."); }
            else { _GameManager.DisplayMiniMessage("You won $" + (BetCost * 4) + " on the slot machine."); }
            _GameManager.Happiness += 4;
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Kaybettin!"); }
            else { _GameManager.DisplayMiniMessage("You lost!"); }
        }

        _GameManager.UpdateUI();
    }

    public void BlurEffect()
    {
        _GameManager.Blur.SetActive(true);
    }

    public void Dollar100()
    {
        enabled = true;
        SlotMachine.sprite = Default;
        BetCost = 100;
        but1.SetActive(true);
        StopButton.SetActive(false);
        if (_GameManager.Money >= BetCost)
        {
            StopButton.SetActive(true);
            _GameManager.Money -= BetCost;
            _GameManager.UpdateUI();
            ProtectBlur.SetActive(true);
            if (_GameManager.L) { StopText.text = "$" + BetCost + " için şansını dene"; }
            else { StopText.text = "Try your luck for $" + BetCost; }
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(_GameManager.Money - BetCost) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(_GameManager.Money - BetCost) + " short."); }
            enabled = false;
        }
    }

    public void Dollar500()
    {
        enabled = true;
        SlotMachine.sprite = Default;
        BetCost = 500;
        but2.SetActive(true);
        StopButton.SetActive(false);

        if (_GameManager.Money >= BetCost)
        {
            StopButton.SetActive(true);
            _GameManager.Money -= BetCost;
            _GameManager.UpdateUI();
            ProtectBlur.SetActive(true);
            if (_GameManager.L) { StopText.text = "$" + BetCost + " için şansını dene"; }
            else { StopText.text = "Try your luck for $" + BetCost; }
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(_GameManager.Money - BetCost) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(_GameManager.Money - BetCost) + " short."); }
            enabled = false;
        }
    }

    public void Dollar1000()
    {
        enabled = true;
        SlotMachine.sprite = Default;
        BetCost = 1000;
        but3.SetActive(true);
        StopButton.SetActive(false);
        if (_GameManager.Money >= BetCost)
        {
            StopButton.SetActive(true);
            _GameManager.Money -= BetCost;
            _GameManager.UpdateUI();
            ProtectBlur.SetActive(true);
            if (_GameManager.L) { StopText.text = "$" + BetCost + " için şansını dene"; }
            else { StopText.text = "Try your luck for $" + BetCost; }
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(_GameManager.Money - BetCost) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(_GameManager.Money - BetCost) + " short."); }
            enabled = false;
        }
    }

    public void Dollar2500()
    {
        enabled = true;
        SlotMachine.sprite = Default;
        BetCost = 2500;
        but4.SetActive(true);
        StopButton.SetActive(false);

        if (_GameManager.Money >= BetCost)
        {
            StopButton.SetActive(true);
            _GameManager.Money -= BetCost;
            _GameManager.UpdateUI();
            ProtectBlur.SetActive(true);
            if (_GameManager.L) { StopText.text = "$" + BetCost + " için şansını dene"; }
            else { StopText.text = "Try your luck for $" + BetCost; }
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(_GameManager.Money - BetCost) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(_GameManager.Money - BetCost) + " short."); }
            enabled = false;
        }
    }

    public void Dollar5000()
    {
        enabled = true;
        SlotMachine.sprite = Default;
        BetCost = 5000;
        but5.SetActive(true);
        StopButton.SetActive(false);

        if (_GameManager.Money >= BetCost)
        {
            StopButton.SetActive(true);
            _GameManager.Money -= BetCost;
            _GameManager.UpdateUI();
            ProtectBlur.SetActive(true);
            if (_GameManager.L) { StopText.text = "$" + BetCost + " için şansını dene"; }
            else { StopText.text = "Try your luck for $" + BetCost; }
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(_GameManager.Money - BetCost) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(_GameManager.Money - BetCost) + " short."); }
            enabled = false;
            ProtectBlur.SetActive(false);
        }
    }

    public void StartTheGame()
    {
        enabled = true;
        ProtectBlur.SetActive(false);
    }
}
