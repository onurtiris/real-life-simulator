using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour
{
    GameManager _GameManager;

    int TotalExpense;
    int TotalWealth;

    public Text TotalExpenseText;
    public Text TotalWealthText;

    int Prestige;
    int PrestigeIncrease;
    public Text PrestigeText;
    public Slider PrestigeSlider;

    int HouseLevel;
    int HouseExpense;
    public Text HouseText;
    public Text HouseDescriptionText;
    public Text HouseUpgradeText;
    int UpgradeHouseMoney;

    int AppearanceLevel;
    int AppearanceExpense;
    public Text AppearanceText;
    public Text AppearanceDescriptionText;
    public Text AppearanceUpgradeText;
    int UpgradeAppearanceMoney;

    int CarLevel;
    int CarExpense;
    public Text CarText;
    public Text CarDescriptionText;
    public Text CarUpgradeText;
    int UpgradeCarMoney;

    public GameObject HousingPanel;

    public Text SellHouseText;
    public Text SellCarText;
    public Text SellAppearanceText;

    public Button HouseButton;
    public Button AppearanceButton;
    public Button CarButton;

    public Button HouseUpgrade;
    public Button AppearanceUpgrade;
    public Button CarUpgrade;

    int NowHouseMoney;
    int NowCarMoney;
    int NowAppearanceMoney;

    public Text HouseLevelText;
    public Text AppearanceLevelText;
    public Text CarLevelText;

    bool Repeat;

    void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Setup();
    }

    public void Setup()
    {
        Load();
        ShowStatus();
        Save();
    }

    public void CloseButton()
    {
        HousingPanel.SetActive(false);
        Repeat = true;
        _GameManager.ShopBlur.SetActive(false);
        _GameManager.BlurExit.SetActive(true);
        _GameManager.Invoke("HideBlurExit", 0.20f);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("HouseLevel", HouseLevel);
        PlayerPrefs.SetInt("HouseExpense", HouseExpense);

        PlayerPrefs.SetInt("AppearanceLevel", AppearanceLevel);
        PlayerPrefs.SetInt("AppearanceExpense", AppearanceExpense);

        PlayerPrefs.SetInt("CarLevel", CarLevel);
        PlayerPrefs.SetInt("CarExpense", CarExpense);

        PlayerPrefs.SetInt("Prestige", Prestige);
    }

    public void Load()
    {
        HouseLevel = PlayerPrefs.GetInt("HouseLevel");
        AppearanceLevel = PlayerPrefs.GetInt("AppearanceLevel");
        CarLevel = PlayerPrefs.GetInt("CarLevel");

        Prestige = PlayerPrefs.GetInt("Prestige");
    }

    public void SellHouse()
    {
        if(HouseLevel >= 1)
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + NowHouseMoney + " karşılığında " + (HouseText.text).ToLower() + " satıldı."); }
            else { _GameManager.DisplayMiniMessage("The " + (HouseText.text).ToLower() + "sold for $" + NowHouseMoney); }
            
            _GameManager.Money += NowHouseMoney;
            if (HouseLevel == 1) { PrestigeIncrease = 3; } else if (HouseLevel == 2) { PrestigeIncrease = 4; } else if (HouseLevel == 3) { PrestigeIncrease = 6; } else if (HouseLevel == 4) { PrestigeIncrease = 7; } else if (HouseLevel == 5) { PrestigeIncrease = 9; } else if (HouseLevel == 6) { PrestigeIncrease = 9; }
            Prestige -= PrestigeIncrease;
            PlayerPrefs.SetInt("Prestige", Prestige);
            PlayerPrefs.SetInt("HouseLevel", (HouseLevel - 1));
            Setup();
            _GameManager.UpdateUI();
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Bunu satamazsınız."); }
            else { _GameManager.DisplayMiniMessage("You can't sell this."); }
        }
    }

    public void SellAppearance()
    {
        if (AppearanceLevel >= 1)
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + NowAppearanceMoney + " karşılığında " + (AppearanceText.text).ToLower() + " satıldı."); }
            else { _GameManager.DisplayMiniMessage("The " + (AppearanceText.text).ToLower() + " sold for $" + NowAppearanceMoney); }
            
            _GameManager.Money += NowAppearanceMoney;
            if (AppearanceLevel == 1) { PrestigeIncrease = 6; } else if (AppearanceLevel == 2) { PrestigeIncrease = 7; } else if (AppearanceLevel == 3) { PrestigeIncrease = 9; }
            Prestige -= PrestigeIncrease;
            PlayerPrefs.SetInt("Prestige", Prestige);
            PlayerPrefs.SetInt("AppearanceLevel", (AppearanceLevel - 1));
            Setup();
            _GameManager.UpdateUI();
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Bunu satamazsınız."); }
            else { _GameManager.DisplayMiniMessage("You can't sell this."); }
        }
    }

    public void SellCar()
    {
        if (CarLevel >= 1)
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + NowCarMoney + " karşılığında " + (CarText.text).ToLower() + " satıldı."); }
            else { _GameManager.DisplayMiniMessage("The" + (CarText.text).ToLower() + " sold for $" + NowCarMoney); }
            
            _GameManager.Money += NowCarMoney;
            if (CarLevel == 1) { PrestigeIncrease = 4; } else if (CarLevel == 2) { PrestigeIncrease = 5; } else if (CarLevel == 3) { PrestigeIncrease = 6; } else if (CarLevel == 4) { PrestigeIncrease = 7; } else if (CarLevel == 5) { PrestigeIncrease = 9; } else if (CarLevel == 6) { PrestigeIncrease = 9; }
            Prestige -= PrestigeIncrease;
            PlayerPrefs.SetInt("Prestige", Prestige);
            PlayerPrefs.SetInt("CarLevel", (CarLevel - 1));
            Setup();
            _GameManager.UpdateUI();
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Bunu satamazsınız."); }
            else { _GameManager.DisplayMiniMessage("You can't sell this."); }
        }
    }

    public void ShowStatus()
    {
        TotalExpense = 0;
        TotalWealth = 0;

        if (_GameManager.L)
        {
            if (HouseLevel == 0) { HouseText.text = "ÇADIR"; HouseExpense = 10; HouseDescriptionText.text = "Aylık masraf $" + HouseExpense; UpgradeHouseMoney = 5000; NowHouseMoney = 0; HouseLevelText.text = "1/7"; HouseUpgradeText.text = "Yükselt $" + UpgradeHouseMoney + "\n<size='28'><color='#93E1BE'>+3 İtibar $250 Masraf</color></size>"; TotalExpense += HouseExpense; TotalWealth += 0; }
            else if (HouseLevel == 1) { HouseText.text = "PANSİYON"; HouseExpense = 250; HouseDescriptionText.text = "Aylık masraf $" + HouseExpense; UpgradeHouseMoney = 12500; NowHouseMoney = (int)(5000 * 0.85); HouseLevelText.text = "2/7"; HouseUpgradeText.text = "Yükselt $" + UpgradeHouseMoney + "\n<size='28'><color='#93E1BE'>+4 İtibar $350 Masraf</color></size>"; TotalExpense += HouseExpense; TotalWealth += 5000; }
            else if (HouseLevel == 2) { HouseText.text = "PAYLAŞIMLI ODA"; HouseExpense = 350; HouseDescriptionText.text = "Aylık masraf $" + HouseExpense; UpgradeHouseMoney = 60000; NowHouseMoney = (int)(12500 * 0.85); HouseLevelText.text = "3/7"; HouseUpgradeText.text = "Yükselt $" + UpgradeHouseMoney + "\n<size='28'><color='#93E1BE'>+6 İtibar $600 Masraf</color></size>"; TotalExpense += HouseExpense; TotalWealth += 17500; }
            else if (HouseLevel == 3) { HouseText.text = "APARTMAN DAİRESİ"; HouseExpense = 600; HouseDescriptionText.text = "Aylık masraf $" + HouseExpense; UpgradeHouseMoney = 100000; NowHouseMoney = (int)(60000 * 0.85); HouseLevelText.text = "4/7"; HouseUpgradeText.text = "Yükselt $" + UpgradeHouseMoney + "\n<size='28'><color='#93E1BE'>+7 İtibar $1400 Masraf</color></size>"; TotalExpense += HouseExpense; TotalWealth += 77500; }
            else if (HouseLevel == 4) { HouseText.text = "MÜSTAKİL EV"; HouseExpense = 1400; HouseDescriptionText.text = "Aylık masraf $" + HouseExpense; UpgradeHouseMoney = 150000; NowHouseMoney = (int)(100000 * 0.85); HouseLevelText.text = "5/7"; HouseUpgradeText.text = "Yükselt $" + UpgradeHouseMoney + "\n<size='28'><color='#93E1BE'>+9 İtibar $2200 Masraf</color></size>"; TotalExpense += HouseExpense; TotalWealth += 177500; }
            else if (HouseLevel == 5) { HouseText.text = "VİLLA"; HouseExpense = 2200; HouseDescriptionText.text = "Aylık masraf $" + HouseExpense; UpgradeHouseMoney = 200000; NowHouseMoney = (int)(150000 * 0.85); HouseLevelText.text = "6/7"; HouseUpgradeText.text = "Yükselt $" + UpgradeHouseMoney + "\n<size='28'><color='#93E1BE'>+9 İtibar $4500 Masraf</color></size>"; TotalExpense += HouseExpense; TotalWealth += 327500; }
            else if (HouseLevel == 6) { HouseText.text = "MALİKANE"; HouseExpense = 4500; HouseDescriptionText.text = "Aylık masraf $" + HouseExpense; UpgradeHouseMoney = 300000; NowHouseMoney = (int)(200000 * 0.85); HouseLevelText.text = "7/7"; HouseUpgradeText.text = "Tamamlandı"; TotalExpense += HouseExpense; TotalWealth += 527500; }

            if (AppearanceLevel == 0) { AppearanceText.text = "UCUZ GÖRÜNÜŞ"; AppearanceExpense = 10; AppearanceDescriptionText.text = "Aylık masraf $" + AppearanceExpense; UpgradeAppearanceMoney = 5000; NowAppearanceMoney = 0; AppearanceLevelText.text = "1/4"; AppearanceUpgradeText.text = "Yükselt $" + UpgradeAppearanceMoney + "\n<size='28'><color='#93E1BE'>+6 İtibar $125 Masraf</color></size>"; TotalExpense += AppearanceExpense; TotalWealth += 0; }
            else if (AppearanceLevel == 1) { AppearanceText.text = "SADE GÖRÜNÜŞ"; AppearanceExpense = 125; AppearanceDescriptionText.text = "Aylık masraf $" + AppearanceExpense; UpgradeAppearanceMoney = 10000; NowAppearanceMoney = (int)(5000 * 0.85); AppearanceLevelText.text = "2/4"; AppearanceUpgradeText.text = "Yükselt $" + UpgradeAppearanceMoney + "\n<size='28'><color='#93E1BE'>+7 İtibar $650 Masraf</color></size>"; TotalExpense += AppearanceExpense; TotalWealth += 5000; }
            else if (AppearanceLevel == 2) { AppearanceText.text = "PAHALI GÖRÜNÜŞ"; AppearanceExpense = 650; AppearanceDescriptionText.text = "Aylık masraf $" + AppearanceExpense; UpgradeAppearanceMoney = 25000; NowAppearanceMoney = (int)(10000 * 0.85); AppearanceLevelText.text = "3/4"; AppearanceUpgradeText.text = "Yükselt $" + UpgradeAppearanceMoney + "\n<size='28'><color='#93E1BE'>+9 İtibar $1400 Masraf</color></size>"; TotalExpense += AppearanceExpense; TotalWealth += 15000; }
            else if (AppearanceLevel == 3) { AppearanceText.text = "ZENGİN GÖRÜNÜŞ"; AppearanceExpense = 1400; AppearanceDescriptionText.text = "Aylık masraf $" + AppearanceExpense; UpgradeAppearanceMoney = 50000; NowAppearanceMoney = (int)(25000 * 0.85); AppearanceLevelText.text = "4/4"; AppearanceUpgradeText.text = "Tamamlandı"; TotalExpense += AppearanceExpense; TotalWealth += 40000; }

            if (CarLevel == 0) { CarText.text = "BİSİKLET"; CarExpense = 10; CarDescriptionText.text = "Aylık masraf $" + CarExpense; UpgradeCarMoney = 5000; NowCarMoney = 0; CarLevelText.text = "1/7"; CarUpgradeText.text = "Yükselt $" + UpgradeCarMoney + "\n<size='28'><color='#93E1BE'>+4 İtibar $175 Masraf</color></size>"; TotalExpense += CarExpense; TotalWealth += 0; }
            else if (CarLevel == 1) { CarText.text = "MOTOSİKLET"; CarExpense = 175; CarDescriptionText.text = "Aylık masraf $" + CarExpense; UpgradeCarMoney = 12500; NowCarMoney = (int)(5000 * 0.85); CarLevelText.text = "2/7"; CarUpgradeText.text = "Yükselt $" + UpgradeCarMoney + "\n<size='28'><color='#93E1BE'>+5 İtibar $225 Masraf</color></size>"; TotalExpense += CarExpense; TotalWealth += 5000; }
            else if (CarLevel == 2) { CarText.text = "MİNİ ARABA"; CarExpense = 225; CarDescriptionText.text = "Aylık masraf $" + CarExpense; UpgradeCarMoney = 40000; NowCarMoney = (int)(12500 * 0.85); CarLevelText.text = "3/7"; CarUpgradeText.text = "Yükselt $" + UpgradeCarMoney + "\n<size='28'><color='#93E1BE'>+6 İtibar $500 Masraf</color></size>"; TotalExpense += CarExpense; TotalWealth += 17500; }
            else if (CarLevel == 3) { CarText.text = "ORTA SINIF ARABA"; CarExpense = 500; CarDescriptionText.text = "Aylık masraf $" + CarExpense; UpgradeCarMoney = 60000; NowCarMoney = (int)(40000 * 0.85); CarLevelText.text = "4/7"; CarUpgradeText.text = "Yükselt $" + UpgradeCarMoney + "\n<size='28'><color='#93E1BE'>+7 İtibar $1000 Masraf</color></size>"; TotalExpense += CarExpense; TotalWealth += 57500; }
            else if (CarLevel == 4) { CarText.text = "LÜKS ARABA"; CarExpense = 1000; CarDescriptionText.text = "Aylık masraf $" + CarExpense; UpgradeCarMoney = 100000; NowCarMoney = (int)(60000 * 0.85); CarLevelText.text = "5/7"; CarUpgradeText.text = "Yükselt $" + UpgradeCarMoney + "\n<size='28'><color='#93E1BE'>+9 İtibar $2000 Masraf</color></size>"; TotalExpense += CarExpense; TotalWealth += 117500; }
            else if (CarLevel == 5) { CarText.text = "SPOR ARABA"; CarExpense = 2000; CarDescriptionText.text = "Aylık masraf $" + CarExpense; UpgradeCarMoney = 150000; NowCarMoney = (int)(100000 * 0.85); CarLevelText.text = "6/7"; CarUpgradeText.text = "Yükselt $" + UpgradeCarMoney + "\n<size='28'><color='#93E1BE'>+9 İtibar $3250 Masraf</color></size>"; TotalExpense += CarExpense; TotalWealth += 217500; }
            else if (CarLevel == 6) { CarText.text = "SÜPER SPOR ARABA"; CarExpense = 3250; CarDescriptionText.text = "Aylık masraf $" + CarExpense; UpgradeCarMoney = 200000; NowCarMoney = (int)(150000 * 0.85); CarLevelText.text = "7/7"; CarUpgradeText.text = "Tamamlandı"; TotalExpense += CarExpense; TotalWealth += 367500; }
        }
        else
        {
            if (HouseLevel == 0) { HouseText.text = "TENT"; HouseExpense = 10; HouseDescriptionText.text = "Monthly -$" + HouseExpense; UpgradeHouseMoney = 5000; NowHouseMoney = 0; HouseLevelText.text = "1/7"; HouseUpgradeText.text = "Upgrade $" + UpgradeHouseMoney + "\n<size='26'><color='#93E1BE'>Prestige +3 Expense $250</color></size>"; TotalExpense += HouseExpense; TotalWealth += 0; }
            else if (HouseLevel == 1) { HouseText.text = "HOSTEL"; HouseExpense = 250; HouseDescriptionText.text = "Monthly -$" + HouseExpense; UpgradeHouseMoney = 12500; NowHouseMoney = (int)(5000 * 0.85); HouseLevelText.text = "2/7"; HouseUpgradeText.text = "Upgrade $" + UpgradeHouseMoney + "\n<size='26'><color='#93E1BE'>Prestige +4 Expense $350</color></size>"; TotalExpense += HouseExpense; TotalWealth += 5000; }
            else if (HouseLevel == 2) { HouseText.text = "SHARED ROOM"; HouseExpense = 350; HouseDescriptionText.text = "Monthly -$" + HouseExpense; UpgradeHouseMoney = 60000; NowHouseMoney = (int)(12500 * 0.85); HouseLevelText.text = "3/7"; HouseUpgradeText.text = "Upgrade $" + UpgradeHouseMoney + "\n<size='26'><color='#93E1BE'>Prestige +6 Expense $600</color></size>"; TotalExpense += HouseExpense; TotalWealth += 17500; }
            else if (HouseLevel == 3) { HouseText.text = "APARTMENT"; HouseExpense = 600; HouseDescriptionText.text = "Monthly -$" + HouseExpense; UpgradeHouseMoney = 100000; NowHouseMoney = (int)(60000 * 0.85); HouseLevelText.text = "4/7"; HouseUpgradeText.text = "Upgrade $" + UpgradeHouseMoney + "\n<size='26'><color='#93E1BE'>Prestige +7 Expense $1400</color></size>"; TotalExpense += HouseExpense; TotalWealth += 77500; }
            else if (HouseLevel == 4) { HouseText.text = "DETACHED HOUSE"; HouseExpense = 1400; HouseDescriptionText.text = "Monthly -$" + HouseExpense; UpgradeHouseMoney = 150000; NowHouseMoney = (int)(100000 * 0.85); HouseLevelText.text = "5/7"; HouseUpgradeText.text = "Upgrade $" + UpgradeHouseMoney + "\n<size='26'><color='#93E1BE'>Prestige +9 Expense $2200</color></size>"; TotalExpense += HouseExpense; TotalWealth += 177500; }
            else if (HouseLevel == 5) { HouseText.text = "VILLA"; HouseExpense = 2200; HouseDescriptionText.text = "Monthly -$" + HouseExpense; UpgradeHouseMoney = 200000; NowHouseMoney = (int)(150000 * 0.85); HouseLevelText.text = "6/7"; HouseUpgradeText.text = "Upgrade $" + UpgradeHouseMoney + "\n<size='26'><color='#93E1BE'>Prestige +9 Expense $4500</color></size>"; TotalExpense += HouseExpense; TotalWealth += 327500; }
            else if (HouseLevel == 6) { HouseText.text = "MANOR"; HouseExpense = 4500; HouseDescriptionText.text = "Monthly -$" + HouseExpense; UpgradeHouseMoney = 300000; NowHouseMoney = (int)(200000 * 0.85); HouseLevelText.text = "7/7"; HouseUpgradeText.text = "Completed"; TotalExpense += HouseExpense; TotalWealth += 527500; }

            if (AppearanceLevel == 0) { AppearanceText.text = "CHEAP APPEARANCE"; AppearanceExpense = 10; AppearanceDescriptionText.text = "Monthly -$" + AppearanceExpense; UpgradeAppearanceMoney = 5000; NowAppearanceMoney = 0; AppearanceLevelText.text = "1/4"; AppearanceUpgradeText.text = "Upgrade $" + UpgradeAppearanceMoney + "\n<size='26'><color='#93E1BE'>Prestige +6 Expense $125</color></size>"; TotalExpense += AppearanceExpense; TotalWealth += 0; }
            else if (AppearanceLevel == 1) { AppearanceText.text = "SIMPLE APPEARANCE"; AppearanceExpense = 125; AppearanceDescriptionText.text = "Monthly -$" + AppearanceExpense; UpgradeAppearanceMoney = 10000; NowAppearanceMoney = (int)(5000 * 0.85); AppearanceLevelText.text = "2/4"; AppearanceUpgradeText.text = "Upgrade $" + UpgradeAppearanceMoney + "\n<size='26'><color='#93E1BE'>Prestige +7 Expense $650</color></size>"; TotalExpense += AppearanceExpense; TotalWealth += 5000; }
            else if (AppearanceLevel == 2) { AppearanceText.text = "EXPENSIVE APPEARANCE"; AppearanceExpense = 650; AppearanceDescriptionText.text = "Monthly -$" + AppearanceExpense; UpgradeAppearanceMoney = 25000; NowAppearanceMoney = (int)(10000 * 0.85); AppearanceLevelText.text = "3/4"; AppearanceUpgradeText.text = "Upgrade $" + UpgradeAppearanceMoney + "\n<size='26'><color='#93E1BE'>Prestige +9 Expense $1400</color></size>"; TotalExpense += AppearanceExpense; TotalWealth += 15000; }
            else if (AppearanceLevel == 3) { AppearanceText.text = "RICH APPEARANCE"; AppearanceExpense = 1400; AppearanceDescriptionText.text = "Monthly -$" + AppearanceExpense; UpgradeAppearanceMoney = 50000; NowAppearanceMoney = (int)(25000 * 0.85); AppearanceLevelText.text = "4/4"; AppearanceUpgradeText.text = "Completed"; TotalExpense += AppearanceExpense; TotalWealth += 40000; }

            if (CarLevel == 0) { CarText.text = "BICYCLE"; CarExpense = 10; CarDescriptionText.text = "Monthly -$" + CarExpense; UpgradeCarMoney = 5000; NowCarMoney = 0; CarLevelText.text = "1/7"; CarUpgradeText.text = "Upgrade $" + UpgradeCarMoney + "\n<size='26'><color='#93E1BE'>Prestige +4 Expense $175</color></size>"; TotalExpense += CarExpense; TotalWealth += 0; }
            else if (CarLevel == 1) { CarText.text = "MOTORCYCLE"; CarExpense = 175; CarDescriptionText.text = "Monthly -$" + CarExpense; UpgradeCarMoney = 12500; NowCarMoney = (int)(5000 * 0.85); CarLevelText.text = "2/7"; CarUpgradeText.text = "Upgrade $" + UpgradeCarMoney + "\n<size='26'><color='#93E1BE'>Prestige +5 Expense $225</color></size>"; TotalExpense += CarExpense; TotalWealth += 5000; }
            else if (CarLevel == 2) { CarText.text = "MINI CAR"; CarExpense = 225; CarDescriptionText.text = "Monthly -$" + CarExpense; UpgradeCarMoney = 40000; NowCarMoney = (int)(12500 * 0.85); CarLevelText.text = "3/7"; CarUpgradeText.text = "Upgrade $" + UpgradeCarMoney + "\n<size='26'><color='#93E1BE'>Prestige +6 Expense $500</color></size>"; TotalExpense += CarExpense; TotalWealth += 17500; }
            else if (CarLevel == 3) { CarText.text = "MIDDLE CLASS CAR"; CarExpense = 500; CarDescriptionText.text = "Monthly -$" + CarExpense; UpgradeCarMoney = 60000; NowCarMoney = (int)(40000 * 0.85); CarLevelText.text = "4/7"; CarUpgradeText.text = "Upgrade $" + UpgradeCarMoney + "\n<size='26'><color='#93E1BE'>Prestige +7 Expense $1000</color></size>"; TotalExpense += CarExpense; TotalWealth += 57500; }
            else if (CarLevel == 4) { CarText.text = "LUXURY CAR"; CarExpense = 1000; CarDescriptionText.text = "Monthly -$" + CarExpense; UpgradeCarMoney = 100000; NowCarMoney = (int)(60000 * 0.85); CarLevelText.text = "5/7"; CarUpgradeText.text = "Upgrade $" + UpgradeCarMoney + "\n<size='26'><color='#93E1BE'>Prestige +9 Expense $2000</color></size>"; TotalExpense += CarExpense; TotalWealth += 117500; }
            else if (CarLevel == 5) { CarText.text = "SPORTS CAR"; CarExpense = 2000; CarDescriptionText.text = "Monthly -$" + CarExpense; UpgradeCarMoney = 150000; NowCarMoney = (int)(100000 * 0.85); CarLevelText.text = "6/7"; CarUpgradeText.text = "Upgrade $" + UpgradeCarMoney + "\n<size='26'><color='#93E1BE'>Prestige +9 Expense $3250</color></size>"; TotalExpense += CarExpense; TotalWealth += 217500; }
            else if (CarLevel == 6) { CarText.text = "SUPER SPORTS CAR"; CarExpense = 3250; CarDescriptionText.text = "Monthly -$" + CarExpense; UpgradeCarMoney = 200000; NowCarMoney = (int)(150000 * 0.85); CarLevelText.text = "7/7"; CarUpgradeText.text = "Completed"; TotalExpense += CarExpense; TotalWealth += 367500; }
        }

        if (_GameManager.L) { PrestigeText.text = "İtibar: %" + Prestige; }
        else { PrestigeText.text = "Prestige: %" + Prestige; }
        
        PrestigeSlider.maxValue = 100;
        PrestigeSlider.value = Prestige;

        if (_GameManager.L) {
            if (HouseLevel == 0) { SellHouseText.text = "Satılamaz"; HouseButton.interactable = false; } else { SellHouseText.text = "Sat $" + NowHouseMoney; HouseButton.interactable = true; }
            if (AppearanceLevel == 0) { SellAppearanceText.text = "Satılamaz"; AppearanceButton.interactable = false; } else { SellAppearanceText.text = "Sat $" + NowAppearanceMoney; AppearanceButton.interactable = true; }
            if (CarLevel == 0) { SellCarText.text = "Satılamaz"; CarButton.interactable = false; } else { SellCarText.text = "Sat $" + NowCarMoney; CarButton.interactable = true; }
            TotalExpenseText.text = "Aylık toplam masraf\n<size='36'><color='#C6BD94'>$" + TotalExpense + "</color></size>";
            TotalWealthText.text = "Mal varlıklarının bedeli\n<size='36'><color='#C6BD94'>$" + (int)(TotalWealth * 0.85) + "</color></size>";
        }
        else {
            if (HouseLevel == 0) { SellHouseText.text = "Not for sale"; HouseButton.interactable = false; } else { SellHouseText.text = "Sell $" + NowHouseMoney; HouseButton.interactable = true; }
            if (AppearanceLevel == 0) { SellAppearanceText.text = "Not for sale"; AppearanceButton.interactable = false; } else { SellAppearanceText.text = "Sell $" + NowAppearanceMoney; AppearanceButton.interactable = true; }
            if (CarLevel == 0) { SellCarText.text = "Not for sale"; CarButton.interactable = false; } else { SellCarText.text = "Sell $" + NowCarMoney; CarButton.interactable = true; }
            TotalExpenseText.text = "Total expense per month\n<size='36'><color='#C6BD94'>$" + TotalExpense + "</color></size>";
            TotalWealthText.text = "Value of assets\n<size='36'><color='#C6BD94'>$" + (int)(TotalWealth * 0.85) + "</color></size>";
        }
        
        if(HouseLevel != 6) { HouseUpgrade.interactable = true; } else { HouseUpgrade.interactable = false; }
        if (AppearanceLevel != 3) { AppearanceUpgrade.interactable = true; } else { AppearanceUpgrade.interactable = false; }
        if (CarLevel != 6) { CarUpgrade.interactable = true; } else { CarUpgrade.interactable = false; }

    }

    public void HouseUpgradeButton()
    {
        if (HouseLevel >= 6)
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Barınma son seviyededir."); }
            else { _GameManager.DisplayMiniMessage("Housing is at the last level"); }
            return;
        }

        if (_GameManager.Money >= UpgradeHouseMoney)
        {
            _GameManager.Money -= UpgradeHouseMoney;
            
            if(HouseLevel == 0) { PrestigeIncrease = 3; } else if(HouseLevel == 1) { PrestigeIncrease = 4; } else if (HouseLevel == 2) { PrestigeIncrease = 6; } else if (HouseLevel == 3) { PrestigeIncrease = 7; } else if (HouseLevel == 4) { PrestigeIncrease = 9; } else if (HouseLevel == 5) { PrestigeIncrease = 9; }
            Prestige += PrestigeIncrease;
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("İtibar %" + PrestigeIncrease + " arttı."); }
            else { _GameManager.DisplayMiniMessage("Prestige increased by %" + PrestigeIncrease); }
            HouseLevel += 1;
            ShowStatus();
            Save();
            _GameManager.UpdateUI();
        }
        else
        {
            if (_GameManager.L) { }
            else { }
            _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(UpgradeHouseMoney - _GameManager.Money) + " short.");
        }
    }

    public void AppearanceUpgradeButton()
    {
        if (AppearanceLevel >= 3)
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Görünüş son seviyededir."); }
            else { _GameManager.DisplayMiniMessage("Appearance is at the last level."); }
            return;
        }

        if (_GameManager.Money >= UpgradeAppearanceMoney)
        {
            _GameManager.Money -= UpgradeAppearanceMoney;
            
            if (AppearanceLevel == 0) { PrestigeIncrease = 6; } else if (AppearanceLevel == 1) { PrestigeIncrease = 7; } else if (AppearanceLevel == 2) { PrestigeIncrease = 9; }
            Prestige += PrestigeIncrease;
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("İtibar %" + PrestigeIncrease + " arttı."); }
            else { _GameManager.DisplayMiniMessage("Prestige increased by %" + PrestigeIncrease); }
            AppearanceLevel += 1;
            ShowStatus();
            Save();
            _GameManager.UpdateUI();
        }
        else
        {
            if (_GameManager.L) { }
            else { }
            _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(UpgradeAppearanceMoney - _GameManager.Money) + " short.");
        }
    }

    public void CarUpgradeButton()
    {
        if (CarLevel >= 6)
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("Ulaşım aracı son seviyededir."); }
            else { _GameManager.DisplayMiniMessage("Vehicle is at the last level."); }
            return;
        }

        if (_GameManager.Money >= UpgradeCarMoney)
        {
            _GameManager.Money -= UpgradeCarMoney;

            if (CarLevel == 0) { PrestigeIncrease = 4; } else if (CarLevel == 1) { PrestigeIncrease = 5; } else if (CarLevel == 2) { PrestigeIncrease = 6; } else if (CarLevel == 3) { PrestigeIncrease = 7; } else if (CarLevel == 4) { PrestigeIncrease = 9; } else if (CarLevel == 5) { PrestigeIncrease = 9; }
            Prestige += PrestigeIncrease;
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("İtibar %" + PrestigeIncrease + " arttı."); }
            else { _GameManager.DisplayMiniMessage("Prestige increased by %" + PrestigeIncrease); }
            CarLevel += 1;
            ShowStatus();
            Save();
            _GameManager.UpdateUI();
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(UpgradeCarMoney - _GameManager.Money) + " eksiğin var."); }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(UpgradeCarMoney - _GameManager.Money) + " short."); }
        }
    }

    void Update()
    {
        if (Repeat) { Setup(); Repeat = false; }
    }
}
