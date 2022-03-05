using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jobs : MonoBehaviour
{
    GameManager _GameManager;

    public int AddToMoney, Chance, JobLevel;
    public bool Purchased, OneTimePurchase;
    public string ItemDescription, ItemDescriptionEN, RequirementString, RequirementStringEN, ItemLevel;
    public Text ItemDescriptionText, ItemCostText, ItemSalaryText, ItemLevelText;
    public Text IncreaseText;
    public Text MonthlySalaryText;
    public GameObject IncreasePanel;
    public List<Item> Requirements;
    public Text UpgradeText;

    public Button UpButton;
    public Button ExtraJobButton;

    public Image JobBackground;
    public Sprite OwnedJobBackground;

    string IncreaseType;
    int Cost;
    int Salary;

    void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ItemLevelText.text = ItemLevel;

        if (_GameManager.L)
        {
            ItemDescriptionText.text = ItemDescription;
            ItemCostText.text = "$" + ((int)AddToMoney / 7).ToString() + "\n<size='28'><color='#93E1BE'>Ek İş Yap</color></size>";
            MonthlySalaryText.text = "Aylık maaş $" + this.Requirements[0].AddToSalary.ToString();
        }
        else
        {
            ItemDescriptionText.text = ItemDescriptionEN;
            ItemCostText.text = "$" + ((int)AddToMoney / 7).ToString() + "\n<size='28'><color='#93E1BE'>Do Extra Work</color></size>";
            MonthlySalaryText.text = "Monthly salary $" + AddToMoney.ToString();
            MonthlySalaryText.text = "Monthly salary $" + this.Requirements[0].AddToSalary.ToString();
        }
        
        ItemSalaryText.text = "%" + Chance.ToString();
        ListingJobLevel();

        if (PlayerPrefs.GetInt(this.name + "Chance") > 10){ LoadData(); }

        SaveData();
        CheckProcessItem();
        UpdateOwnedJob();
    }

    void Update()
    {
        LoadData();
    }

    void SetupItem()
    {
        Purchased = false;
    }

    public void UpdateOwnedJob()
    {
        if (CheckRequirements())
        {
            JobBackground.sprite = OwnedJobBackground;
        }
    }

    public void ListingJobLevel()
    {
        UpdateOwnedJob();

        if (_GameManager.L)
        {
            if (Chance >= 99) { ItemLevelText.text = "Profesyonel"; }
            else if (Chance >= 95) { ItemLevelText.text = "Uzman"; }
            else if (Chance >= 90) { ItemLevelText.text = "Çok İyi"; }
            else if (Chance >= 85) { ItemLevelText.text = "İyi"; }
            else if (Chance >= 80) { ItemLevelText.text = "Orta"; }
            else if (Chance >= 75) { ItemLevelText.text = "Vasat"; }
            else if (Chance >= 70) { ItemLevelText.text = "Acemi"; }
            else { ItemLevelText.text = "Yeni"; }
        }
        else
        {
            if (Chance >= 99) { ItemLevelText.text = "Professional"; }
            else if (Chance >= 95) { ItemLevelText.text = "Expert"; }
            else if (Chance >= 90) { ItemLevelText.text = "Very Good"; }
            else if (Chance >= 85) { ItemLevelText.text = "Good"; }
            else if (Chance >= 80) { ItemLevelText.text = "Intermediate"; }
            else if (Chance >= 75) { ItemLevelText.text = "Mediocre "; }
            else if (Chance >= 70) { ItemLevelText.text = "Beginner"; }
            else { ItemLevelText.text = "New"; }
        }
    }

    public void ListingCacheJobLevel()
    {
        if (Chance >= 85) { _GameManager.CacheJobLevel += 2; }
        else if (Chance >= 75) { _GameManager.CacheJobLevel += 1; }
    }

    public bool CheckRequirements()
    {
        bool PassedRequirements = true;
        RequirementString = "";
        string Comma = "";
        foreach (Item CurrentItem in Requirements)
        {
            if (!CurrentItem.Purchased)
            {
                PassedRequirements = false;
                RequirementString += Comma + "" + CurrentItem.ItemDescription + "";
                Comma = ", ";
            }
        }
        return PassedRequirements;
    }

    public void CheckProcessItem()
    {
        LoadData();

        for (int i = 0; i < ((_GameManager.BoolItems).Length) - 1; i++)
        {
            if (_GameManager.BoolItems[i] == 1)
            {
                _GameManager.AllGameItems[i].Purchased = true;
                if (_GameManager.L) { _GameManager.AllGameItems[i].ItemCostText.text = "<color='#D9C89D'>       Satın Alındı</color>"; }
                else { _GameManager.AllGameItems[i].ItemCostText.text = "<color='#D9C89D'>        Purchased</color>"; }
            }
            if (_GameManager.AllGameItems[i].OneTimePurchase && _GameManager.AllGameItems[i].Purchased)
            {
                _GameManager.AllGameItems[i].Purchased = true;
                if (_GameManager.L) { _GameManager.AllGameItems[i].ItemCostText.text = "<color='#D9C89D'>       Satın Alındı</color>"; }
                else { _GameManager.AllGameItems[i].ItemCostText.text = "<color='#D9C89D'>        Purchased</color>"; }
                PlayerPrefs.SetInt("boolitem" + (i + 1), 1);
            }
        }
        
        _GameManager.SaveData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt(this.name + "Chance", Chance);
        PlayerPrefs.SetInt(this.name + "Salary", AddToMoney);
    }

    public void LoadData()
    {
        Chance = PlayerPrefs.GetInt(this.name + "Chance");
        AddToMoney = PlayerPrefs.GetInt(this.name + "Salary");
        if (_GameManager.L)
        {
            ItemSalaryText.text = "Ek iş şansı %" + Chance.ToString();
            ItemCostText.text = "$" + ((int)AddToMoney / 7).ToString() + "\n<size='28'><color='#93E1BE'>Ek İş Yap</color></size>";
            MonthlySalaryText.text = "Aylık maaş $" + this.Requirements[0].AddToSalary.ToString();
            UpgradeText.text = "Geliştir";
        }
        else
        {
            ItemSalaryText.text = "Work chance %" + Chance.ToString();
            ItemCostText.text = "$" + ((int)AddToMoney / 7).ToString() + "\n<size='28'><color='#93E1BE'>Do Extra Work</color></size>";
            MonthlySalaryText.text = "Monthly $" + this.Requirements[0].AddToSalary.ToString();
            UpgradeText.text = "Upgrade";
        }
        
        UpButton.interactable = true;
        ExtraJobButton.interactable = true;

        if (!CheckRequirements())
        {
            if (_GameManager.L)
            {
                ItemSalaryText.text = "Ek iş şansı %0";
                ItemCostText.text = RequirementString + "\n<size='28'><color='#93E1BE'>Gereklidir</color></size>";
                MonthlySalaryText.text = "Aylık maaş $0";
                UpgradeText.text = "Geliştirilemez";
            }
            else
            {
                ItemSalaryText.text = "Work chance %0";
                ItemCostText.text = RequirementStringEN + "\n<size='28'><color='#93E1BE'>Required</color></size>";
                MonthlySalaryText.text = "Monthly $0";
                UpgradeText.text = "Can't be upgraded";
            }
            
            UpButton.interactable = false;
            ExtraJobButton.interactable = false;
        }
        ListingJobLevel();
    }

    public void UpgradeButton()
    {
        if (!CheckRequirements())
        {
            if (_GameManager.L) { _GameManager.DisplayMessage(ItemDescription + " işini geliştirebilmek için <color='#D9C89D'>" + RequirementString + "</color> gereklidir."); }
            else { _GameManager.DisplayMessage("A <color='#D9C89D'>" + RequirementStringEN + "</color> is required to develop the " + ItemDescriptionEN + " job."); }
            return;
        }
        else
        {
            if (_GameManager.L) { _GameManager.DisplayMessage("Üzgünüz, bu özellik yapım aşamasındadır."); }
            else { _GameManager.DisplayMessage("Sorry, this feature is under construction."); }
        }
    }

    public void UpdateIncreaseChanceText()
    {
        IncreasePanel.SetActive(true);
        IncreaseType = "Chance";

        if (Chance >= 95) { Cost = 20000; }
        else if (Chance >= 90) { Cost = 17500; }
        else if (Chance >= 85) { Cost = 15000; }
        else if (Chance >= 80) { Cost = 12500; }
        else if (Chance >= 75) { Cost = 10000; }
        else if (Chance >= 70) { Cost = 9000; }
        else if (Chance >= 65) { Cost = 8000; }
        else if (Chance >= 60) { Cost = 7000; }
        else if (Chance >= 55) { Cost = 6000; }
        else if (Chance >= 50) { Cost = 5000; }
        else if (Chance >= 45) { Cost = 4000; }
        else if (Chance >= 40) { Cost = 3000; }
        else if (Chance >= 35) { Cost = 2000; }
        else { Cost = 1000; }

        if (_GameManager.L) { IncreaseText.text = "<color='#968B72'>$" + Cost + "</color>\nkarşılığında işin şansı <color='#968B72'>%1</color>\nartırılacaktır"; }
        else { IncreaseText.text = "For <color='#968B72'>$" + Cost + ",</color>\nthe chances of the job will be\nincreased by <color='#968B72'>%1.</color>"; }  
    }

    public void UpdateIncreaseSalaryText()
    {
        IncreasePanel.SetActive(true);
        IncreaseType = "Salary";

        if (AddToMoney >= 60000) { Salary = 700; Cost = 200000; }
        else if (AddToMoney >= 50000) { Salary = 650; Cost = 100000; }
        else if (AddToMoney >= 30000) { Salary = 600; Cost = 70000; }
        else if (AddToMoney >= 20000) { Salary = 550; Cost = 40000; }
        else if (AddToMoney >= 15000) { Salary = 500; Cost = 25000; }
        else if (AddToMoney >= 10000) { Salary = 450; Cost = 20000; }
        else if (AddToMoney >= 5000) { Salary = 400; Cost = 14000; }
        else if (AddToMoney >= 4000) {Salary = 350; Cost = 12000; }
        else if (AddToMoney >= 3600) { Salary = 300; Cost = 10000; }
        else if (AddToMoney >= 3000) { Salary = 250; Cost = 8000; }
        else if (AddToMoney >= 2500) { Salary = 200; Cost = 6000; }
        else if (AddToMoney >= 2000) { Salary = 150; Cost = 4000; }
        else if (AddToMoney >= 1500) { Salary = 100; Cost = 2000; }
        else { Salary = 15; Cost = 300; }

        if (_GameManager.L) { IncreaseText.text = "<color='#968B72'>$" + Cost + "</color>\nkarşılığında işin ücreti <color='#968B72'>$" + Salary + "</color>\nartırılacaktır"; }
        else { IncreaseText.text = "For <color='#968B72'>$" + Cost + ",</color>\nthe job's salary will be\nincreased by <color='#968B72'>$" + Salary + ".</color>"; }
    }

    public void IncreaseChances()
    {
        if (_GameManager.L)
        {
            if (Chance >= 100)
            {
                _GameManager.DisplayMiniMessage("Yüzde artırımı maksimum seviyededir.");
            }
            else
            {
                if (Chance >= 95)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("Yüzde artırımı için $20000 gereklidir."); return; }
                }
                else if (Chance >= 90)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("Yüzde artırımı için $17500 gereklidir."); return; }
                }
                else if (Chance >= 85)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("Yüzde artırımı için $15000 gereklidir."); return; }
                }
                else if (Chance >= 80)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("Yüzde artırımı için $12500 gereklidir."); return; }
                }
                else if (Chance >= 75)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("Yüzde artırımı için $10000 gereklidir."); return; }
                }
                else if (Chance >= 70)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("Yüzde artırımı için $9000 gereklidir."); return; }
                }
                else if (Chance >= 65)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("Yüzde artırımı için $8000 gereklidir."); return; }
                }
                else if (Chance >= 60)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("Yüzde artırımı için $7000 gereklidir."); return; }
                }
                else if (Chance >= 55)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("Yüzde artırımı için $6000 gereklidir."); return; }
                }
                else if (Chance >= 50)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("Yüzde artırımı için $5000 gereklidir."); return; }
                }
                else if (Chance >= 45)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("Yüzde artırımı için $4000 gereklidir."); return; }
                }
                else if (Chance >= 40)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("Yüzde artırımı için $3000 gereklidir."); return; }
                }
                else if (Chance >= 35)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("Yüzde artırımı için $2000 gereklidir."); return; }
                }
                else
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("Yüzde artırımı için $1000 gereklidir."); return; }
                }
            }
        }
        else
        {
            if (Chance >= 100)
            {
                _GameManager.DisplayMiniMessage("Percentage increment is at maximum.");
            }
            else
            {
                if (Chance >= 95)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$20000 is required for percent increase."); return; }
                }
                else if (Chance >= 90)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$17500 is required for percent increase."); return; }
                }
                else if (Chance >= 85)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$15000 is required for percent increase."); return; }
                }
                else if (Chance >= 80)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$12500 is required for percent increase."); return; }
                }
                else if (Chance >= 75)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$10000 is required for percent increase."); return; }
                }
                else if (Chance >= 70)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$9000 is required for percent increase."); return; }
                }
                else if (Chance >= 65)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$8000 is required for percent increase."); return; }
                }
                else if (Chance >= 60)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$7000 is required for percent increase."); return; }
                }
                else if (Chance >= 55)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$6000 is required for percent increase."); return; }
                }
                else if (Chance >= 50)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$5000 is required for percent increase."); return; }
                }
                else if (Chance >= 45)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$4000 is required for percent increase."); return; }
                }
                else if (Chance >= 40)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$3000 is required for percent increase."); return; }
                }
                else if (Chance >= 35)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$2000 is required for percent increase."); return; }
                }
                else
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$1000 is required for percent increase."); return; }
                }
            }

            Chance += 1;
            ItemSalaryText.text = "%" + Chance.ToString();
            SaveData();
            LoadData();
            _GameManager.UpdateUI();
        }        
    }

    public void IncreaseButton()
    {
        if (IncreaseType == "Chance")
        {
            IncreaseChances();
        }
        else if(IncreaseType == "Salary")
        {
            IncreaseSalary();
        }
    }

    public void IncreaseSalary()
    {
        if (_GameManager.L)
        {
            if (AddToMoney >= 10000)
            {
                _GameManager.DisplayMiniMessage("İşin ücreti en fazla $10000 olabilir");
            }
            else
            {
                if (AddToMoney >= 1500)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("İş ücreti artırımı için $" + Cost + " gereklidir."); return; }
                }
                else if (AddToMoney >= 1200)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("İş ücreti artırımı için $" + Cost + " gereklidir."); return; }
                }
                else if (AddToMoney >= 1000)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("İş ücreti artırımı için $" + Cost + " gereklidir."); return; }
                }
                else if (AddToMoney >= 750)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("İş ücreti artırımı için $" + Cost + " gereklidir."); return; }
                }
                else if (AddToMoney >= 500)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("İş ücreti artırımı için $" + Cost + " gereklidir."); return; }
                }
                else if (AddToMoney >= 400)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("İş ücreti artırımı için $" + Cost + " gereklidir."); return; }
                }
                else if (AddToMoney >= 350)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("İş ücreti artırımı için $" + Cost + " gereklidir."); return; }
                }
                else if (AddToMoney >= 300)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("İş ücreti artırımı için $" + Cost + " gereklidir."); return; }
                }
                else if (AddToMoney >= 250)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("İş ücreti artırımı için $" + Cost + " gereklidir."); return; }
                }
                else if (AddToMoney >= 200)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("İş ücreti artırımı için $" + Cost + " gereklidir."); return; }
                }
                else if (AddToMoney >= 150)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("İş ücreti artırımı için $" + Cost + " gereklidir."); return; }
                }
                else if (AddToMoney >= 100)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("İş ücreti artırımı için $" + Cost + " gereklidir."); return; }
                }
                else if (AddToMoney >= 50)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("İş ücreti artırımı için $" + Cost + " gereklidir."); return; }
                }
                else
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("İş ücreti artırımı için $" + Cost + " gereklidir."); return; }
                }

                AddToMoney += Salary;
                ItemCostText.text = "$" + ((int)AddToMoney / 7).ToString() + "\n<size='28'><color='#93E1BE'>Ek İş Yap</color></size>";
                MonthlySalaryText.text = "Aylık maaş $" + this.Requirements[0].AddToSalary.ToString();
            }
        }
        else
        {
            if (AddToMoney >= 10000)
            {
                _GameManager.DisplayMiniMessage("The fee for the work can be up to $10000");
            }
            else
            {
                if (AddToMoney >= 1500)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$" + Cost + " is required for work fee increase."); return; }
                }
                else if (AddToMoney >= 1200)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$" + Cost + " is required for work fee increase."); return; }
                }
                else if (AddToMoney >= 1000)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$" + Cost + " is required for work fee increase."); return; }
                }
                else if (AddToMoney >= 750)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$" + Cost + " is required for work fee increase."); return; }
                }
                else if (AddToMoney >= 500)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("İ$" + Cost + " is required for work fee increase."); return; }
                }
                else if (AddToMoney >= 400)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$" + Cost + " is required for work fee increase."); return; }
                }
                else if (AddToMoney >= 350)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$" + Cost + " is required for work fee increase."); return; }
                }
                else if (AddToMoney >= 300)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$" + Cost + " is required for work fee increase."); return; }
                }
                else if (AddToMoney >= 250)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$" + Cost + " is required for work fee increase."); return; }
                }
                else if (AddToMoney >= 200)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$" + Cost + " is required for work fee increase."); return; }
                }
                else if (AddToMoney >= 150)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$" + Cost + " is required for work fee increase."); return; }
                }
                else if (AddToMoney >= 100)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$" + Cost + " is required for work fee increase."); return; }
                }
                else if (AddToMoney >= 50)
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$" + Cost + " is required for work fee increase."); return; }
                }
                else
                {
                    if (_GameManager.Money >= Cost) { _GameManager.Money -= Cost; }
                    else { _GameManager.DisplayMiniMessage("$" + Cost + " is required for work fee increase."); return; }
                }

                AddToMoney += Salary;
                ItemCostText.text = "$" + ((int)AddToMoney / 7).ToString() + "\n<size='28'><color='#93E1BE'>Do Extra Work</color></size>";
                MonthlySalaryText.text = "Monthly salary $" + this.Requirements[0].AddToSalary.ToString();
            }
            SaveData();
            LoadData();
            _GameManager.UpdateUI();
        }
    }

    public void ProcessItem()
    {
        if (_GameManager.JobCounter > 0)
        {
            if (_GameManager.L) { _GameManager.DisplayMessage("Bir iş yapabilmek için <color='#F77F64'>" + _GameManager.JobCounter + "</color> gün daha beklemelisiniz."); }
            else { _GameManager.DisplayMessage("You can do this work after <color='#F77F64'>" + _GameManager.JobCounter + "</color> days."); }
        }
        else
        {
            if (_GameManager.Happiness >= 40)
            {
                if (OneTimePurchase && Purchased)
                {
                    if (_GameManager.L) { _GameManager.DisplayMessage("Zaten <color='#D9C79F'>" + ItemDescription + "</color> işine sahipsin."); }
                    else { _GameManager.DisplayMessage("You already have the <color='#D9C79F'>" + ItemDescriptionEN + "</color> job."); }
                    return;
                }

                if (!CheckRequirements())
                {
                    if (_GameManager.L) { _GameManager.DisplayMessage(ItemDescription + " işi için <color='#D9C89D'>" + RequirementString + "</color> gereklidir."); }
                    else { _GameManager.DisplayMessage("A <color='#D9C89D'>" + RequirementStringEN + "</color> is required for the " + ItemDescriptionEN + " work."); }
                    return;
                }

                int RandomChance = Random.Range(1, 101);
                if (Chance > RandomChance)
                {
                    _GameManager.CacheJobLevel = JobLevel;
                    _GameManager.CacheJobMoney = (int)AddToMoney / 7;
                    if (_GameManager.L) { _GameManager.CacheJobName = "" + ItemLevelText.text + " " + ItemDescription; }
                    else { _GameManager.CacheJobName = "" + ItemLevelText.text + " " + ItemDescriptionEN; }

                    ListingCacheJobLevel();
                    _GameManager.JobGamePanelBackground.sprite = _GameManager.WithCharacter;
                    _GameManager.JobCharacter.SetActive(true);
                    if (_GameManager.CacheJobLevel == 3 || _GameManager.CacheJobLevel == 6 || _GameManager.CacheJobLevel == 9 || _GameManager.CacheJobLevel == 12 || _GameManager.CacheJobLevel == 15 || _GameManager.CacheJobLevel == 18)
                    {
                        if (_GameManager.L) { _GameManager.CacheJobGameText.text = "<color='#3DB4C9'>Sekreter: </color><color='#C1AF80'>20 saniyede</color> " + _GameManager.CacheJobName + " işini tamamlarsan <color='#C1AF80'>$" + _GameManager.CacheJobMoney + "</color> kazanacaksın."; }
                        else { _GameManager.CacheJobGameText.text = "<color='#3DB4C9'>Secretary: </color>If you complete the " + _GameManager.CacheJobName + " job in <color='#C1AF80'>20 seconds,</color> you will earn <color='#C1AF80'>$" + _GameManager.CacheJobMoney + ".</color>"; }
                    }
                    else if (_GameManager.CacheJobLevel == 2 || _GameManager.CacheJobLevel == 5 || _GameManager.CacheJobLevel == 8 || _GameManager.CacheJobLevel == 11 || _GameManager.CacheJobLevel == 14 || _GameManager.CacheJobLevel == 17)
                    {
                        if (_GameManager.L) { _GameManager.CacheJobGameText.text = "<color='#3DB4C9'>Sekreter: </color><color='#C1AF80'>25 saniyede</color> " + _GameManager.CacheJobName + " işini tamamlarsan <color='#C1AF80'>$" + _GameManager.CacheJobMoney + "</color> kazanacaksın."; }
                        else { _GameManager.CacheJobGameText.text = "<color='#3DB4C9'>Secretary: </color>If you complete the " + _GameManager.CacheJobName + " job in <color='#C1AF80'>25 seconds,</color> you will earn <color='#C1AF80'>$" + _GameManager.CacheJobMoney + ".</color>"; }
                    }
                    else if (_GameManager.CacheJobLevel == 1 || _GameManager.CacheJobLevel == 4 || _GameManager.CacheJobLevel == 7 || _GameManager.CacheJobLevel == 10 || _GameManager.CacheJobLevel == 13 || _GameManager.CacheJobLevel == 16)
                    {
                        if (_GameManager.L) { _GameManager.CacheJobGameText.text = "<color='#3DB4C9'>Sekreter: </color><color='#C1AF80'>30 saniyede</color> " + _GameManager.CacheJobName + " işini tamamlarsan <color='#C1AF80'>$" + _GameManager.CacheJobMoney + "</color> kazanacaksın."; }
                        else { _GameManager.CacheJobGameText.text = "<color='#3DB4C9'>Secretary: </color>If you complete the " + _GameManager.CacheJobName + " job in <color='#C1AF80'>30 seconds,</color> you will earn <color='#C1AF80'>$" + _GameManager.CacheJobMoney + ".</color>"; }
                    }
                    else
                    {
                        if (_GameManager.L) { _GameManager.CacheJobGameText.text = "<color='#3DB4C9'>Sekreter: </color><color='#C1AF80'>20 saniyede</color> " + _GameManager.CacheJobName + " işini tamamlarsan <color='#C1AF80'>$" + _GameManager.CacheJobMoney + "</color> kazanacaksın."; }
                        else { _GameManager.CacheJobGameText.text = "<color='#3DB4C9'>Secretary: </color>If you complete the " + _GameManager.CacheJobName + " job in <color='#C1AF80'>20 seconds,</color> you will earn <color='#C1AF80'>$" + _GameManager.CacheJobMoney + ".</color>"; }
                    }

                    _GameManager.JobGamePanel.SetActive(true);
                    Purchased = true;
                }
                else
                {
                    _GameManager.Day += 1;
                    Purchased = true;
                    _GameManager.JobCounter = 7;
                    if (_GameManager.L) { _GameManager.CloseDisplayMessage("secretary", "\n<color='#3DB4C9'>Sekreter: </color>İş başvurunuz kabul edilmedi.", "Kabul edilme şansı: %" + Chance); }
                    else { _GameManager.CloseDisplayMessage("secretary", "\n<color='#3DB4C9'>Secretary: </color>Your job application was not accepted.", "Chances of being accepted: %" + Chance); }
                }

                _GameManager.UpdateUI();
                _GameManager.SaveData();
                CheckProcessItem();
            }

            else
            {
                if (_GameManager.L) { _GameManager.CloseDisplayMessage("default", "<color='#0EB6D3'>" + ItemDescription + "</color> işini yapabilmek için mutluluk seviyesi yetersiz.", "Minimum Mutluluk: %40"); }
                else { _GameManager.CloseDisplayMessage("default", "Insufficient level of happiness to do the <color='#0EB6D3'>" + ItemDescriptionEN + "</color> work.", "Minimum Happiness: %40"); }  
            }
        }
    }
}
