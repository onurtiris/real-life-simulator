using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileSlider : MonoBehaviour
{
    GameManager _GameManager;

    public int Intelligence = 4;
    public int Diligence = 2;
    public int Persuasion = 3;

    public int Counter = 1;

    public Text Slider1Text;
    public Slider Slider1;

    public Text Slider2Text;
    public Slider Slider2;

    public Text Slider3Text;
    public Slider Slider3;

    public Text RemainingPoints;
    public Text PointText;

    public Text GenderButtonText;

    void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (_GameManager.L) { RemainingPoints.text = "Kalan puan:"; }
        else { RemainingPoints.text = "Points:"; }
        
        Slider1.maxValue = 5;
        Slider2.maxValue = 5;
        Slider3.maxValue = 5;

        Slider1.value = Intelligence;
        Slider2.value = Diligence;
        Slider3.value = Persuasion;

        if (_GameManager.L) { Slider1Text.text = "Zekilik: " + Intelligence; }
        else { Slider1Text.text = "Intelligence: " + Intelligence; }

        if (_GameManager.L) { Slider2Text.text = "Çalışkanlık: " + Diligence; }
        else { Slider2Text.text = "Diligence: " + Diligence; }

        if (_GameManager.L) { Slider3Text.text = "İkna: " + Persuasion; }
        else { Slider3Text.text = "Persuasion: " + Persuasion; }

        if (_GameManager.L) { GenderButtonText.text = "CİNSİYET DEĞİŞTİR"; }
        else { GenderButtonText.text = "CHANGE GENDER"; }

    }


    public void IncreaseSlider1()
    {
        if (Intelligence < 5 && Counter >= 1)
        {
            Intelligence += 1;
            Counter -= 1;
            Slider1.value += 1;

            if (_GameManager.L) { Slider1Text.text = "Zekilik: " + Intelligence; }
            else { Slider1Text.text = "Intelligence: " + Intelligence; }
            
            PointText.text = "" + Counter;
        } 
    }

    public void DecraseSlider1()
    {
        if (Intelligence > 0 && Counter < 10)
        {
            Intelligence -= 1;
            Counter += 1;
            Slider1.value -= 1;

            if (_GameManager.L) { Slider1Text.text = "Zekilik: " + Intelligence; }
            else { Slider1Text.text = "Intelligence: " + Intelligence; }
            
            PointText.text = "" + Counter;
        }       
    }

    public void IncreaseSlider2()
    {
        if (Diligence < 5 && Counter >= 1)
        {
            Diligence += 1;
            Counter -= 1;
            Slider2.value += 1;

            if (_GameManager.L) { Slider2Text.text = "Çalışkanlık: " + Diligence; }
            else { Slider2Text.text = "Diligence: " + Diligence; }
            
            PointText.text = "" + Counter;
        }
    }

    public void DecraseSlider2()
    {
        if (Diligence > 0 && Counter < 10)
        {
            Diligence -= 1;
            Counter += 1;
            Slider2.value -= 1;

            if (_GameManager.L) { Slider2Text.text = "Çalışkanlık: " + Diligence; }
            else { Slider2Text.text = "Diligence: " + Diligence; }
            
            PointText.text = "" + Counter;
        }
    }

    public void IncreaseSlider3()
    {
        if (Persuasion < 5 && Counter >= 1)
        {
            Persuasion += 1;
            Counter -= 1;
            Slider3.value += 1;

            if (_GameManager.L) { Slider3Text.text = "İkna: " + Persuasion; }
            else { Slider3Text.text = "Persuasion: " + Persuasion; }
            
            PointText.text = "" + Counter;
        }
    }

    public void DecraseSlider3()
    {
        if (Persuasion > 0 && Counter < 10)
        {
            Persuasion -= 1;
            Counter += 1;
            Slider3.value -= 1;

            if (_GameManager.L) { Slider3Text.text = "İkna: " + Persuasion; }
            else { Slider3Text.text = "Persuasion: " + Persuasion; }
            
            PointText.text = "" + Counter;
        }
    }
    
    public void AddValues()
    {
        _GameManager.SchoolPoint += Intelligence;
        _GameManager.Money += Diligence * 100;
    }
}
