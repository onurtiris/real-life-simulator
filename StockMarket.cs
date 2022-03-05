using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockMarket : MonoBehaviour
{
    GameManager _GameManager;
    
    public GameObject StockMarketPanel;

    public float Second;
    public Text TimeText;

    public Sprite UpArrow;
    public Sprite DownArrow;
    public Sprite Equal;

    public int Stock1Price;
    int TempStock1Price;
    public Text Stock1PriceText;
    public float Stock1Status;
    public Text Stock1StatusText;
    public Image Stock1StatusIcon;
    public Text Stock1InfoText;
    int Stock1Amount;

    public int Stock2Price;
    int TempStock2Price;
    public Text Stock2PriceText;
    public float Stock2Status;
    public Text Stock2StatusText;
    public Image Stock2StatusIcon;
    public Text Stock2InfoText;
    int Stock2Amount;

    public int Stock3Price;
    int TempStock3Price;
    public Text Stock3PriceText;
    public float Stock3Status;
    public Text Stock3StatusText;
    public Image Stock3StatusIcon;
    public Text Stock3InfoText;
    int Stock3Amount;

    public int Stock4Price;
    int TempStock4Price;
    public Text Stock4PriceText;
    public float Stock4Status;
    public Text Stock4StatusText;
    public Image Stock4StatusIcon;
    public Text Stock4InfoText;
    int Stock4Amount;

    public int Stock5Price;
    int TempStock5Price;
    public Text Stock5PriceText;
    public float Stock5Status;
    public Text Stock5StatusText;
    public Image Stock5StatusIcon;
    public Text Stock5InfoText;
    int Stock5Amount;

    public int Stock6Price;
    int TempStock6Price;
    public Text Stock6PriceText;
    public float Stock6Status;
    public Text Stock6StatusText;
    public Image Stock6StatusIcon;
    public Text Stock6InfoText;
    int Stock6Amount;

    int Today;
    int DayDifference;
    int BuyPrice;
    int SellPrice;
    int StockAmount;
    int AssignRandom;
    int Piece;

    void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Second = 10;
        SetupGame();
    }

    public void SetupGame()
    {
        if (PlayerPrefs.HasKey("Stock1"))
        {
            UpdateStockMarket();
            GetStockInfo();
        }
        else
        {
            TempStock1Price = 490;
            Stock1Price = 500;
            Stock1Amount = 0;

            TempStock2Price = 180;
            Stock2Price = 175;
            Stock2Amount = 0;

            TempStock3Price = 50;
            Stock3Price = 53;
            Stock3Amount = 0;

            TempStock4Price = 350;
            Stock4Price = 357;
            Stock4Amount = 0;

            TempStock5Price = 800;
            Stock5Price = 791;
            Stock5Amount = 0;

            TempStock6Price = 200;
            Stock6Price = 240;
            Stock6Amount = 0;

            PriceCheck();
            StatusCheck();
            SaveData();
            GetStockInfo();
        }
    }

    public void UpdateStockMarket()
    {
        LoadData();
        ConvertTemp();
        AssignPrice();
        EqualToZero();
        PriceCheck();
        StatusCheck();
        SaveData();
    }

    public void BuyStock(int StockID)
    {
        if (StockID == 1) { BuyPrice = Stock1Price; StockAmount = Stock1Amount; }
        else if (StockID == 2) { BuyPrice = Stock2Price; StockAmount = Stock2Amount; }
        else if (StockID == 3) { BuyPrice = Stock3Price; StockAmount = Stock3Amount; }
        else if (StockID == 4) { BuyPrice = Stock4Price; StockAmount = Stock4Amount; }
        else if (StockID == 5) { BuyPrice = Stock5Price; StockAmount = Stock5Amount; }
        else if (StockID == 6) { BuyPrice = Stock6Price; StockAmount = Stock6Amount; }

        if (_GameManager.L) { if (StockAmount >= 999) { _GameManager.DisplayMiniMessage("En fazla 999 tane alınabilir."); return; } }
        else { if (StockAmount >= 999) { _GameManager.DisplayMiniMessage("A maximum of 999 can be purchased."); return; } }

        if (_GameManager.L)
        {
            if (_GameManager.Money >= BuyPrice) { _GameManager.Money -= BuyPrice; }
            else { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(BuyPrice - _GameManager.Money) + " eksiğin var."); return; }
        }
        else
        {
            if (_GameManager.Money >= BuyPrice) { _GameManager.Money -= BuyPrice; }
            else { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(BuyPrice - _GameManager.Money) + " short."); return; }
        }

        if (StockID == 1) { Stock1Amount += 1; }
        else if (StockID == 2) { Stock2Amount += 1; }
        else if(StockID == 3) { Stock3Amount += 1; }
        else if(StockID == 4) { Stock4Amount += 1; }
        else if(StockID == 5) { Stock5Amount += 1; }
        else if(StockID == 6) { Stock6Amount += 1; }

        GetStockInfo();
        _GameManager.UpdateUI();
        SaveData();
    }

    public void MaxBuy(int StockID)
    {
        if (StockID == 1) { BuyPrice = Stock1Price; StockAmount = Stock1Amount; }
        else if (StockID == 2) { BuyPrice = Stock2Price; StockAmount = Stock2Amount; }
        else if (StockID == 3) { BuyPrice = Stock3Price; StockAmount = Stock3Amount; }
        else if (StockID == 4) { BuyPrice = Stock4Price; StockAmount = Stock4Amount; }
        else if (StockID == 5) { BuyPrice = Stock5Price; StockAmount = Stock5Amount; }
        else if (StockID == 6) { BuyPrice = Stock6Price; StockAmount = Stock6Amount; }

        if (_GameManager.L)
        {
            if (_GameManager.Money <= BuyPrice) { _GameManager.DisplayMiniMessage("$" + Mathf.Abs(BuyPrice - _GameManager.Money) + " eksiğin var."); return; }
            else
            {
                Piece = _GameManager.Money / BuyPrice;
                if ((Piece + StockAmount) >= 999) { Piece = 999 - StockAmount; }
                _GameManager.Money -= BuyPrice * Piece;
            }
        }
        else
        {
            if (_GameManager.Money <= BuyPrice) { _GameManager.DisplayMiniMessage("You're $" + Mathf.Abs(BuyPrice - _GameManager.Money) + " short."); return; }
            else
            {
                Piece = _GameManager.Money / BuyPrice;
                if ((Piece + StockAmount) >= 999) { Piece = 999 - StockAmount; }
                _GameManager.Money -= BuyPrice * Piece;
            }
        }

        if (StockID == 1) { Stock1Amount += Piece; }
        else if (StockID == 2) { Stock2Amount += Piece; }
        else if (StockID == 3) { Stock3Amount += Piece; }
        else if (StockID == 4) { Stock4Amount += Piece; }
        else if (StockID == 5) { Stock5Amount += Piece; }
        else if (StockID == 6) { Stock6Amount += Piece; }

        GetStockInfo();
        _GameManager.UpdateUI();
        SaveData();
    }

    public void SellStock(int StockID)
    {
        if (StockID == 1) { SellPrice = Stock1Price; StockAmount = Stock1Amount; }
        else if (StockID == 2) { SellPrice = Stock2Price; StockAmount = Stock2Amount; }
        else if (StockID == 3) { SellPrice = Stock3Price; StockAmount = Stock3Amount; }
        else if (StockID == 4) { SellPrice = Stock4Price; StockAmount = Stock4Amount; }
        else if (StockID == 5) { SellPrice = Stock5Price; StockAmount = Stock5Amount; }
        else if (StockID == 6) { SellPrice = Stock6Price; StockAmount = Stock6Amount; }

        if (_GameManager.L)
        {
            if (StockAmount >= 1) { _GameManager.Money += SellPrice; StockAmount -= 1; }
            else { _GameManager.DisplayMiniMessage("Yetersiz miktar."); return; }
        }
        else
        {
            if (StockAmount >= 1) { _GameManager.Money += SellPrice; StockAmount -= 1; }
            else { _GameManager.DisplayMiniMessage("Insufficient amount."); return; }
        }
        
        if (StockID == 1) { Stock1Amount -= 1; }
        else if(StockID == 2) { Stock2Amount -= 1; }
        else if (StockID == 3) { Stock3Amount -= 1; }
        else if (StockID == 4) { Stock4Amount -= 1; }
        else if (StockID == 5) { Stock5Amount -= 1; }
        else if (StockID == 6) { Stock6Amount -= 1; }

        GetStockInfo();
        _GameManager.UpdateUI();
        SaveData();
    }

    public void MaxSell(int StockID)
    {
        if (StockID == 1) { SellPrice = Stock1Price; StockAmount = Stock1Amount; }
        else if (StockID == 2) { SellPrice = Stock2Price; StockAmount = Stock2Amount; }
        else if (StockID == 3) { SellPrice = Stock3Price; StockAmount = Stock3Amount; }
        else if (StockID == 4) { SellPrice = Stock4Price; StockAmount = Stock4Amount; }
        else if (StockID == 5) { SellPrice = Stock5Price; StockAmount = Stock5Amount; }
        else if (StockID == 6) { SellPrice = Stock6Price; StockAmount = Stock6Amount; }

        if (_GameManager.L)
        {
            if (StockAmount >= 1) { _GameManager.Money += SellPrice; StockAmount -= 1; }
            else { _GameManager.DisplayMiniMessage("Yetersiz miktar."); return; }
        }
        else
        {
            if (StockAmount >= 1) { _GameManager.Money += SellPrice; StockAmount -= 1; }
            else { _GameManager.DisplayMiniMessage("Insufficient amount."); return; }
        }

        _GameManager.Money += StockAmount * SellPrice;

        if (StockID == 1) { Stock1Amount = 0; }
        else if (StockID == 2) { Stock2Amount = 0; }
        else if (StockID == 3) { Stock3Amount = 0; }
        else if (StockID == 4) { Stock4Amount = 0; }
        else if (StockID == 5) { Stock5Amount = 0; }
        else if (StockID == 6) { Stock6Amount = 0; }

        GetStockInfo();
        _GameManager.UpdateUI();
        SaveData();
    }

    public void GetStockInfo()
    {
        Stock1InfoText.text = "<color='#EF8F1A'>" + Stock1Amount + " BIP</color>\n<size='25'>$" + (Stock1Amount * Stock1Price) + "</size>";
        Stock2InfoText.text = "<color='#42BA5A'>" + Stock2Amount + " GOC</color>\n<size='25'>$" + (Stock2Amount * Stock2Price) + "</size>";
        Stock3InfoText.text = "<color='#955D87'>" + Stock3Amount + " SUP</color>\n<size='25'>$" + (Stock3Amount * Stock3Price) + "</size>";
        Stock4InfoText.text = "<color='#4D7391'>" + Stock4Amount + " LEM</color>\n<size='25'>$" + (Stock4Amount * Stock4Price) + "</size>";
        Stock5InfoText.text = "<color='#EB1B54'>" + Stock5Amount + " ROP</color>\n<size='25'>$" + (Stock5Amount * Stock5Price) + "</size>";
        Stock6InfoText.text = "<color='#F56507'>" + Stock6Amount + " MAR</color>\n<size='25'>$" + (Stock6Amount * Stock6Price) + "</size>";
    }

    public void AssignPrice()
    {
        AssignRandom = Random.Range(1, 136);

        if (Stock1Price >= 800) { Stock1Price += Random.Range(-20, 15); }
        else if (Stock1Price <= 200) { Stock1Price += Random.Range(-2, 4); }
        else if (Stock1Price <= 100) { Stock1Price += Random.Range(-1, 2); }
        else { Stock1Price += Random.Range(-10, 11); }
        if (AssignRandom >= 1 && AssignRandom <= 2) { Stock1Price += Random.Range(-90, 91); }

        if (Stock2Price >= 250) { Stock2Price += Random.Range(-8, 6); }
        else if (Stock2Price <= 130) { Stock2Price += Random.Range(-1, 2); }
        else if (Stock2Price <= 100) { Stock2Price += Random.Range(-2, 6); }
        else { Stock2Price += Random.Range(-2, 3); }
        if (AssignRandom >= 3 && AssignRandom <= 4) { Stock2Price += Random.Range(-54, 56); }

        if (Stock3Price >= 100) { Stock3Price += Random.Range(-10, 11); }
        else if (Stock3Price <= 30) { Stock3Price += Random.Range(-1, 3); }
        else if (Stock3Price <= 10) { Stock3Price += Random.Range(-2, 5); }
        else { Stock3Price += Random.Range(-4, 5); }
        if (AssignRandom >= 5 && AssignRandom <= 6) { Stock3Price += Random.Range(-30, 31); }

        if (Stock4Price >= 500) { Stock4Price += Random.Range(-10, 11); }
        else if (Stock4Price <= 300) { Stock4Price += Random.Range(-8, 5); }
        else if (Stock4Price <= 200) { Stock4Price += Random.Range(-5, 6); }
        else { Stock4Price += Random.Range(-4, 5); }
        if (AssignRandom >= 7 && AssignRandom <= 8) { Stock4Price += Random.Range(-70, 71); }

        if (Stock5Price >= 999) { Stock5Price += Random.Range(-20, 10); }
        else if (Stock5Price <= 600) { Stock5Price += Random.Range(-19, 14); }
        else if (Stock5Price <= 400) { Stock5Price += Random.Range(-13, 20); }
        else { Stock5Price += Random.Range(-15, 16); }
        if (AssignRandom >= 9 && AssignRandom <= 10) { Stock5Price += Random.Range(-100, 101); }

        if (Stock6Price >= 300) { Stock6Price += Random.Range(-6, 4); }
        else if (Stock6Price <= 200) { Stock6Price += Random.Range(-1, 2); }
        else if (Stock6Price <= 100) { Stock6Price += Random.Range(-1, 3); }
        else { Stock6Price += Random.Range(-5, 6); }
        if (AssignRandom >= 11 && AssignRandom <= 12) { Stock6Price += Random.Range(-60, 61); }
    }

    public void PriceCheck()
    {
        Stock1PriceText.text = "$" + Stock1Price;
        Stock2PriceText.text = "$" + Stock2Price;
        Stock3PriceText.text = "$" + Stock3Price;
        Stock4PriceText.text = "$" + Stock4Price;
        Stock5PriceText.text = "$" + Stock5Price;
        Stock6PriceText.text = "$" + Stock6Price;
    }

    public void StatusCheck()
    {
        if (Stock1Price > TempStock1Price) { Stock1StatusIcon.sprite = UpArrow; }
        else if (Stock1Price == TempStock1Price) { Stock1StatusIcon.sprite = Equal; }
        else { Stock1StatusIcon.sprite = DownArrow; }
        Stock1Status = 100 - ((100 * (float)Stock1Price) / (float)TempStock1Price);
        if(Stock1Status < 0) { Stock1StatusText.text = "<color='#35C9A5'>+" + Mathf.Abs(Stock1Status).ToString("0.00") + "%</color>"; }
        else if (Stock1Status == 0) { Stock1StatusText.text = "<color='#F7931A'>0,00%</color>"; }
        else { Stock1StatusText.text = "<color='#F77F64'>-" + Stock1Status.ToString("0.00") + "%</color>"; }

        if (Stock2Price > TempStock2Price) { Stock2StatusIcon.sprite = UpArrow; }
        else if (Stock2Price == TempStock2Price) { Stock2StatusIcon.sprite = Equal; }
        else { Stock2StatusIcon.sprite = DownArrow; }
        Stock2Status = 100 - ((100 * (float)Stock2Price) / (float)TempStock2Price);
        if (Stock2Status < 0) { Stock2StatusText.text = "<color='#35C9A5'>+" + Mathf.Abs(Stock2Status).ToString("0.00") + "%</color>"; }
        else if (Stock2Status == 0) { Stock2StatusText.text = "<color='#F7931A'>0,00%</color>"; }
        else { Stock2StatusText.text = "<color='#F77F64'>-" + Stock2Status.ToString("0.00") + "%</color>"; }

        if (Stock3Price > TempStock3Price) { Stock3StatusIcon.sprite = UpArrow; }
        else if (Stock3Price == TempStock3Price) { Stock3StatusIcon.sprite = Equal; }
        else { Stock3StatusIcon.sprite = DownArrow; }
        Stock3Status = 100 - ((100 * (float)Stock3Price) / (float)TempStock3Price);
        if (Stock3Status < 0) { Stock3StatusText.text = "<color='#35C9A5'>+" + Mathf.Abs(Stock3Status).ToString("0.00") + "%</color>"; }
        else if (Stock3Status == 0) { Stock3StatusText.text = "<color='#F7931A'>0,00%</color>"; }
        else { Stock3StatusText.text = "<color='#F77F64'>-" + Stock3Status.ToString("0.00") + "%</color>"; }

        if (Stock4Price > TempStock4Price) { Stock4StatusIcon.sprite = UpArrow; }
        else if (Stock4Price == TempStock4Price) { Stock4StatusIcon.sprite = Equal; }
        else { Stock4StatusIcon.sprite = DownArrow; }
        Stock4Status = 100 - ((100 * (float)Stock4Price) / (float)TempStock4Price);
        if (Stock4Status < 0) { Stock4StatusText.text = "<color='#35C9A5'>+" + Mathf.Abs(Stock4Status).ToString("0.00") + "%</color>"; }
        else if (Stock4Status == 0) { Stock4StatusText.text = "<color='#F7931A'>0,00%</color>"; }
        else { Stock4StatusText.text = "<color='#F77F64'>-" + Stock4Status.ToString("0.00") + "%</color>"; }

        if (Stock5Price > TempStock5Price) { Stock5StatusIcon.sprite = UpArrow; }
        else if (Stock5Price == TempStock5Price) { Stock5StatusIcon.sprite = Equal; }
        else { Stock5StatusIcon.sprite = DownArrow; }
        Stock5Status = 100 - ((100 * (float)Stock5Price) / (float)TempStock5Price);
        if (Stock5Status < 0) { Stock5StatusText.text = "<color='#35C9A5'>+" + Mathf.Abs(Stock5Status).ToString("0.00") + "%</color>"; }
        else if (Stock5Status == 0) { Stock5StatusText.text = "<color='#F7931A'>0,00%</color>"; }
        else { Stock5StatusText.text = "<color='#F77F64'>-" + Stock5Status.ToString("0.00") + "%</color>"; }

        if (Stock6Price > TempStock6Price) { Stock6StatusIcon.sprite = UpArrow; }
        else if (Stock6Price == TempStock6Price) { Stock6StatusIcon.sprite = Equal; }
        else { Stock6StatusIcon.sprite = DownArrow; }
        Stock6Status = 100 - ((100 * (float)Stock6Price) / (float)TempStock6Price);
        if (Stock6Status < 0) { Stock6StatusText.text = "<color='#35C9A5'>+" + Mathf.Abs(Stock6Status).ToString("0.00") + "%</color>"; }
        else if (Stock6Status == 0) { Stock6StatusText.text = "<color='#F7931A'>0,00%</color>"; }
        else { Stock6StatusText.text = "<color='#F77F64'>-" + Stock6Status.ToString("0.00") + "%</color>"; }
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Stock1", Stock1Price);
        PlayerPrefs.SetInt("Stock1Temp", TempStock1Price);
        PlayerPrefs.SetInt("Stock1Amount", Stock1Amount);

        PlayerPrefs.SetInt("Stock2", Stock2Price);
        PlayerPrefs.SetInt("Stock2Temp", TempStock2Price);
        PlayerPrefs.SetInt("Stock2Amount", Stock2Amount);

        PlayerPrefs.SetInt("Stock3", Stock3Price);
        PlayerPrefs.SetInt("Stock3Temp", TempStock3Price);
        PlayerPrefs.SetInt("Stock3Amount", Stock3Amount);

        PlayerPrefs.SetInt("Stock4", Stock4Price);
        PlayerPrefs.SetInt("Stock4Temp", TempStock4Price);
        PlayerPrefs.SetInt("Stock4Amount", Stock4Amount);

        PlayerPrefs.SetInt("Stock5", Stock5Price);
        PlayerPrefs.SetInt("Stock5Temp", TempStock5Price);
        PlayerPrefs.SetInt("Stock5Amount", Stock5Amount);

        PlayerPrefs.SetInt("Stock6", Stock6Price);
        PlayerPrefs.SetInt("Stock6Temp", TempStock6Price);
        PlayerPrefs.SetInt("Stock6Amount", Stock6Amount);
    }

    public void LoadData()
    {
        Stock1Price = PlayerPrefs.GetInt("Stock1");
        TempStock1Price = PlayerPrefs.GetInt("Stock1Temp");
        Stock1Amount = PlayerPrefs.GetInt("Stock1Amount");

        Stock2Price = PlayerPrefs.GetInt("Stock2");
        TempStock2Price = PlayerPrefs.GetInt("Stock2Temp");
        Stock2Amount = PlayerPrefs.GetInt("Stock2Amount");

        Stock3Price = PlayerPrefs.GetInt("Stock3");
        TempStock3Price = PlayerPrefs.GetInt("Stock3Temp");
        Stock3Amount = PlayerPrefs.GetInt("Stock3Amount");

        Stock4Price = PlayerPrefs.GetInt("Stock4");
        TempStock4Price = PlayerPrefs.GetInt("Stock4Temp");
        Stock4Amount = PlayerPrefs.GetInt("Stock4Amount");

        Stock5Price = PlayerPrefs.GetInt("Stock5");
        TempStock5Price = PlayerPrefs.GetInt("Stock5Temp");
        Stock5Amount = PlayerPrefs.GetInt("Stock5Amount");

        Stock6Price = PlayerPrefs.GetInt("Stock6");
        TempStock6Price = PlayerPrefs.GetInt("Stock6Temp");
        Stock6Amount = PlayerPrefs.GetInt("Stock6Amount");
    }

    public void EqualToZero()
    {
        if (Stock1Price <= 0) { Stock1Price = 1; }
        if (Stock2Price <= 0) { Stock2Price = 1; }
        if (Stock3Price <= 0) { Stock3Price = 1; }
        if (Stock4Price <= 0) { Stock4Price = 1; }
        if (Stock5Price <= 0) { Stock5Price = 1; }
        if (Stock6Price <= 0) { Stock6Price = 1; }
    }

    public void ConvertTemp()
    {
        TempStock1Price = Stock1Price;
        TempStock2Price = Stock2Price;
        TempStock3Price = Stock3Price;
        TempStock4Price = Stock4Price;
        TempStock5Price = Stock5Price;
        TempStock6Price = Stock6Price;
    }


    void Update()
    {
        GetStockInfo();
        Second -= Time.deltaTime;
        if (Second <= 1)
        {
            Second = 10;
            SetupGame();
            return;
        }
        else
        {
            TimeText.text = "" + (int)Second;
        }

        if (Today != _GameManager.Day)
        {
            Second = 10;
            DayDifference = _GameManager.Day - Today;
            if (DayDifference >= 4)
            {
                UpdateStockMarket();
                UpdateStockMarket();
                UpdateStockMarket();
            }
            else
            {
                UpdateStockMarket();
            }
            
            Today = _GameManager.Day;
        }
    }
}
