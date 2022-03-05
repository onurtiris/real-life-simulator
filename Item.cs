using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    GameManager _GameManager;

    public int AddToFood, AddToHealth, AddToMoney, AddToDay, AddToSalary, AddToHappiness, RentalDays, RentalDaysRemaining, ID, ItemSchoolPoint;
    public bool Purchased, OneTimePurchase, SchoolItem;
    public string ItemDescription, ItemDescriptionEN, RequirementString, RequirementStringEN, ConvertNegative;
    public Text ItemDescriptionText, ItemCostText;
    public Image ItemIcon;

    public List<Item> Requirements;

    private void OnEnable()
    {
        GameManager.OnSendUpdateUI += UpdateItem;
        GameManager.OnSendSetupEvent += SetupItem;
    }

    private void OnDisable()
    {
        GameManager.OnSendUpdateUI -= UpdateItem;
        GameManager.OnSendSetupEvent -= SetupItem;
    }

    void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (_GameManager.L)
        {
            if (AddToFood > 0 && AddToHealth > 0) { ItemDescriptionText.text = ItemDescription + "\n<color='#D2BE8D'><size='29'>+" + AddToFood + " Yemek +" + AddToHealth + " Sağlık</size></color>"; }
            else if (AddToFood > 0) { ItemDescriptionText.text = ItemDescription + "\n<color='#D2BE8D'><size='29'>+" + AddToFood + " Yemek</size></color>"; }
            else if (AddToHealth > 0) { ItemDescriptionText.text = ItemDescription + "\n<color='#D2BE8D'><size='29'>+" + AddToHealth + " Sağlık</size></color>"; }
            else if (AddToHappiness > 0) { ItemDescriptionText.text = ItemDescription + "\n<color='#D2BE8D'><size='29'>+" + AddToHappiness + " Mutluluk</size></color>"; }
            else { ItemDescriptionText.text = ItemDescription; }
        }
        else
        {
            if (AddToFood > 0 && AddToHealth > 0) { ItemDescriptionText.text = ItemDescriptionEN + "\n<color='#D2BE8D'><size='29'>+" + AddToFood + " Food +" + AddToHealth + " Health</size></color>"; }
            else if (AddToFood > 0) { ItemDescriptionText.text = ItemDescriptionEN + "\n<color='#D2BE8D'><size='29'>+" + AddToFood + " Food</size></color>"; }
            else if (AddToHealth > 0) { ItemDescriptionText.text = ItemDescriptionEN + "\n<color='#D2BE8D'><size='29'>+" + AddToHealth + " Health</size></color>"; }
            else if (AddToHappiness > 0) { ItemDescriptionText.text = ItemDescriptionEN + "\n<color='#D2BE8D'><size='29'>+" + AddToHappiness + " Happiness</size></color>"; }
            else { ItemDescriptionText.text = ItemDescriptionEN; }
        }
        
        ConvertNegative = AddToMoney.ToString();
        if (ItemSchoolPoint >= 1)
        {
            if (_GameManager.L) { ItemCostText.text = "$" + ConvertNegative.Substring(1) + "<color='#C5B384'> + " + ItemSchoolPoint + " OP</color>"; }
            else { ItemCostText.text = "$" + ConvertNegative.Substring(1) + "<color='#C5B384'> + " + ItemSchoolPoint + " SP</color>"; }   
        }
        else
        {
            ItemCostText.text = "$" + ConvertNegative.Substring(1);
        }
        
        CheckProcessItem();
    }

    void SetupItem()
    {
        Purchased = false;
    }

    void UpdateItem()
    {
        if (RentalDays > 0 && Purchased)
        {
            RentalDaysRemaining -= 1;

            if (RentalDaysRemaining == 0)
            {
                Purchased = false;
            }
        }
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
        for (int i = 0; i < ((_GameManager.BoolItems).Length); i++)
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
                _GameManager.AllGameItems[i].ItemIcon.enabled = true;
                if (_GameManager.L) { _GameManager.AllGameItems[i].ItemCostText.text = "<color='#D9C89D'>       Satın Alındı</color>"; }
                else { _GameManager.AllGameItems[i].ItemCostText.text = "<color='#D9C89D'>        Purchased</color>"; }
                PlayerPrefs.SetInt("boolitem" + (i + 1), 1);
            }
            else
            {
                _GameManager.AllGameItems[i].ItemIcon.enabled = false;
            }
        }
        
        _GameManager.SaveData();
    }

    public void ProcessItem()
    {
        if (OneTimePurchase && Purchased)
        {
            if (_GameManager.L) { _GameManager.DisplayMessage("Zaten <color='#D9C79F'>" + ItemDescription + "</color> sahipsin."); }
            else { _GameManager.DisplayMessage("You already have a <color='#D9C79F'>" + ItemDescriptionEN + ".</color>"); }
            return;
        }

        if (!CheckRequirements())
        {
            if (_GameManager.L) { _GameManager.DisplayMessage("Bunun için <color='#D9C89D'>" + RequirementString + "</color> gereklidir."); }
            else { _GameManager.DisplayMessage("<color='#D9C89D'>" + RequirementStringEN + "</color> is needed for this."); }
            return;
        }

        if (SchoolItem)
        {

            if (_GameManager.SchoolPoint  < ItemSchoolPoint)
            {
                if (_GameManager.SchoolPoint == 0)
                {
                    if (_GameManager.L) { _GameManager.DisplayMessage("Bunun için <color='#D9C89D'>" + Mathf.Abs((_GameManager.SchoolPoint - ItemSchoolPoint)) + " okul puanı</color> gereklidir."); }
                    else { _GameManager.DisplayMessage("<color='#D9C89D'>" + Mathf.Abs((_GameManager.SchoolPoint - ItemSchoolPoint)) + " school points</color> are required for this."); }
                }
                else
                {
                    if (_GameManager.L) { _GameManager.DisplayMessage("Bunun için <color='#D9C89D'>" + Mathf.Abs((_GameManager.SchoolPoint - ItemSchoolPoint)) + " okul puanı</color> daha gereklidir."); }
                    else { _GameManager.DisplayMessage("<color='#D9C89D'>" + Mathf.Abs((_GameManager.SchoolPoint - ItemSchoolPoint)) + " more school points</color> are required for this."); }
                }
                return;
            }

            if (_GameManager.SchoolPoint >= ItemSchoolPoint && _GameManager.Money >= Mathf.Abs(AddToMoney))
            {
                _GameManager.SchoolPoint -= ItemSchoolPoint;
                if (_GameManager.L) { _GameManager.SchoolShopInformationText.text = _GameManager.SchoolPoint + " okul puanınına (OP) sahipsiniz"; }
                else { _GameManager.SchoolShopInformationText.text = "You have " + _GameManager.SchoolPoint + " school points (SP)"; }
            }
            else
            {
                if (_GameManager.L) { _GameManager.DisplayMessage("Yeterince paran yok."); }
                else { _GameManager.DisplayMessage("You don't have enough money."); }
                return;
            }
        }

        if (_GameManager.BuyItem(AddToMoney))
        {
            _GameManager.AddToDay(AddToDay);
            _GameManager.AddToHealth(AddToHealth);
            _GameManager.AddToFood(AddToFood);
            _GameManager.AddToHappiness(AddToHappiness);
            Purchased = true;
            if (RentalDays > 0)
            {
                RentalDaysRemaining = RentalDays;
            }
            if (AddToSalary >= 1)
            {
                _GameManager.FinalSalary += AddToSalary;
                if (_GameManager.L) { _GameManager.CloseDisplayMessage("default", "<color='#0EB6D3'>" + ItemDescription + "</color> sahip olduğun için her ay maaşına $" + AddToSalary + " eklenecektir.", "Maaşın son durumu: $" + _GameManager.FinalSalary); }
                else { _GameManager.CloseDisplayMessage("default", "Because you have a <color='#0EB6D3'>" + ItemDescriptionEN + ",</color> $" + AddToSalary + " added to your salary every month.", "Current status of the salary: $" + _GameManager.FinalSalary); }
            }

            for (int i = 0; i < ((_GameManager.BoolItems).Length); i++)
            {
                if (ID == i)
                {
                    _GameManager.BoolItems[i] = 1;
                    PlayerPrefs.SetInt("boolitem" + (i + 1), 1);
                }
            }

            if (_GameManager.L) { _GameManager.DisplayMiniMessage(ItemDescription + " alındı."); }
            else { _GameManager.DisplayMiniMessage("You got a " + ItemDescriptionEN); }
            
            _GameManager.UpdateUI();
            _GameManager.SaveData();
        }

        CheckProcessItem();
    }
}
