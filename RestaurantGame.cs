using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestaurantGame : MonoBehaviour
{
    GameManager _GameManager;

    public AudioSource ErrorSound;

    int RandomSalary = 5;

    public Image Image1;
    public Image Image2;
    public Image Image3;
    public Image Image4;

    public Image FoodIcon;

    public Sprite Hotdog;
    public Sprite Hamburger;
    public Sprite Pizza;
    public Sprite Chicken;
    public Sprite Empty;

    public bool Image1Status;
    public bool Image2Status;
    public bool Image3Status;
    public bool Image4Status;

    public GameObject ProtectBlur;
    public GameObject BackButton;

    string FoodName = "";

    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;

    public GameObject StartButton;
    public GameObject StopButton;

    public GameObject GamePanel;

    public Text RestaurantMessageText;

    public int Hak = 2;

    void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();          
    }

    public void StartTheGame()
    {
        BackButton.SetActive(false);
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
        Button4.SetActive(true);
        Hak = 2;
        Start();
        if (_GameManager.L) { RestaurantMessageText.text = "<color='#3DB4C9'>Garson: </color>Şefimiz sizden yemek pişirmenizi istiyor."; }
        else { RestaurantMessageText.text = "<color='#3DB4C9'>Waiter: </color>Our chef asks you to cook."; }
        _GameManager.JobCounter = 7;
        GamePanel.SetActive(true);
        StartButton.SetActive(false);
        StopButton.SetActive(false);
        int RandomFood = Random.Range(0, 4);
        switch (RandomFood)
        {
            case 0:
            if (_GameManager.L) { RestaurantMessageText.text = "<color='#3DB4C9'>Garson: </color>Bugün şef <color='#C1AF80'>hamburger</color> pişirmeni istiyor."; }
            else { RestaurantMessageText.text = "<color='#3DB4C9'>Waiter: </color>Today the chef wants you to cook a <color='#C1AF80'>hamburger.</color>"; }
            FoodIcon.sprite = Hamburger;
            StartHamburger();
            break;

            case 1:
            if (_GameManager.L) { RestaurantMessageText.text = "<color='#3DB4C9'>Garson: </color>Bugün şef <color='#C1AF80'>pizza</color> pişirmeni istiyor."; }
            else { RestaurantMessageText.text = "<color='#3DB4C9'>Waiter: </color>Today the chef wants you to cook a <color='#C1AF80'>pizza</color>"; }
            FoodIcon.sprite = Pizza;
            StartPizza();
            break;

            case 2:
            if (_GameManager.L) { RestaurantMessageText.text = "<color='#3DB4C9'>Garson: </color>Bugün şef <color='#C1AF80'>tavuk</color> pişirmeni istiyor."; }
            else { RestaurantMessageText.text = "<color='#3DB4C9'>Waiter: </color>Today the chef wants you to cook a <color='#C1AF80'>chicken</color>"; }
            FoodIcon.sprite = Chicken;
            StartChicken();
            break;
            case 3:
            if (_GameManager.L) { RestaurantMessageText.text = "<color='#3DB4C9'>Garson: </color>Bugün şef <color='#C1AF80'>sosisli sandviç</color> pişirmeni istiyor."; }
            else { RestaurantMessageText.text = "<color='#3DB4C9'>Waiter: </color>Today the chef wants you to cook a <color='#C1AF80'>hot dog</color>"; }
            FoodIcon.sprite = Hotdog;
            StartHotdog();
            break;
        }
    }

    public void clickCheck(GameObject button)
    {
        button.SetActive(false);

        if (Hak == 2){ RandomSalary = Random.Range(100, 500); }
        else { RandomSalary = Random.Range(10, 250); }

        if (Hak < 2)
        {
            if (_GameManager.L) { RestaurantMessageText.text = "<color='#3DB4C9'>Garson: </color>Şef sizden <color='#C1AF80'>" + FoodName + "</color> istiyordu, son bir şans."; }
            else { RestaurantMessageText.text = "<color='#3DB4C9'>Waiter: </color>The chef was asking you for <color='#C1AF80'>" + FoodName + ",</color> one last chance."; }
        }

        if (button == Button1)
        {
            if (Image1Status)
            {
                _GameManager.Money += RandomSalary;
                if (_GameManager.L)
                {
                    RestaurantMessageText.text = "<color='#3DB4C9'>Garson: </color>İşte maaşınız: $" + RandomSalary + "!";
                    _GameManager.DisplayMessage("Tebrikler!\n<color='#D9C89D'>$" + RandomSalary + " kazandın!</color>");
                }
                else
                {
                    RestaurantMessageText.text = "<color='#3DB4C9'>Waiter: </color>Here is your working fee: $" + RandomSalary + "!";
                    _GameManager.DisplayMessage("Congratulations!\n<color='#D9C89D'>You won $" + RandomSalary + "!</color>");
                }
                _GameManager.AlertSound3.Play();
                ProtectBlur.SetActive(true);
            }
            else 
            {
                Hak -= 1;
            }
        }

        if (button == Button2)
        {

            if (Image2Status)
            {
                _GameManager.Money += RandomSalary;
                if (_GameManager.L)
                {
                    RestaurantMessageText.text = "<color='#3DB4C9'>Garson: </color>İşte maaşınız: $" + RandomSalary + "!";
                    _GameManager.DisplayMessage("Tebrikler!\n<color='#D9C89D'>$" + RandomSalary + " kazandın!</color>");
                }
                else
                {
                    RestaurantMessageText.text = "<color='#3DB4C9'>Waiter: </color>Here is your working fee: $" + RandomSalary + "!";
                    _GameManager.DisplayMessage("Congratulations!\n<color='#D9C89D'>You won $" + RandomSalary + "!</color>");
                }
                _GameManager.AlertSound3.Play();
                ProtectBlur.SetActive(true);
            }
            else
            {
                Hak -= 1;
            }
        }

        if (button == Button3)
        {
            if (Image3Status)
            {
                _GameManager.Money += RandomSalary;
                if (_GameManager.L)
                {
                    RestaurantMessageText.text = "<color='#3DB4C9'>Garson: </color>İşte maaşınız: $" + RandomSalary + "!";
                    _GameManager.DisplayMessage("Tebrikler!\n<color='#D9C89D'>$" + RandomSalary + " kazandın!</color>");
                }
                else
                {
                    RestaurantMessageText.text = "<color='#3DB4C9'>Waiter: </color>Here is your working fee: $" + RandomSalary + "!";
                    _GameManager.DisplayMessage("Congratulations!\n<color='#D9C89D'>You won $" + RandomSalary + "!</color>");
                }
                _GameManager.AlertSound3.Play();
                ProtectBlur.SetActive(true);
            }
            else
            {
                Hak -= 1;
            }
        }

        if (button == Button4)
        {
            if (Image4Status)
            {
                if (_GameManager.L)
                {
                    RestaurantMessageText.text = "<color='#3DB4C9'>Garson: </color>İşte maaşınız: $" + RandomSalary + "!";
                    _GameManager.Money += RandomSalary;
                    _GameManager.DisplayMessage("Tebrikler!\n<color='#D9C89D'>$" + RandomSalary + " kazandın!</color>");
                }
                else
                {
                    RestaurantMessageText.text = "<color='#3DB4C9'>Garson: </color>Here is your working fee: $" + RandomSalary + "!";
                    _GameManager.Money += RandomSalary;
                    _GameManager.DisplayMessage("Congratulations!\n<color='#D9C89D'>You won $" + RandomSalary + "!</color>");
                }
                _GameManager.AlertSound3.Play();
                ProtectBlur.SetActive(true);
            }
            else
            {
                Hak -= 1;
            }
        }

        if (Hak <= 0)
        {
            if (_GameManager.L) { RestaurantMessageText.text = "<color='#3DB4C9'>Garson: </color>Şef işinizi beğenmedi. Başka zaman tekrar çalışalım."; }
            else { RestaurantMessageText.text = "<color='#3DB4C9'>Waiter: </color>The chef didn't like your job. Let's work again another time."; }
            
            ProtectBlur.SetActive(true);
            if (PlayerPrefs.GetString("Sound") == "On")
            {
                ErrorSound.Play();
            }
        }

        _GameManager.UpdateUI();
    }

    public void CloseButton()
    {
        ProtectBlur.SetActive(false);
        _GameManager.RestaurantGamePanel.SetActive(false);
        GamePanel.SetActive(false);
        StartButton.SetActive(true);
        StopButton.SetActive(true);
        if (_GameManager.L) { RestaurantMessageText.text = "<color='#3DB4C9'>Garson: </color>Şefimiz sizden yemek pişirmenizi istiyor."; }
        else { RestaurantMessageText.text = "<color='#3DB4C9'>Waiter: </color>Our chef asks you to cook."; }
        
        _GameManager.ShopBlur.SetActive(false);
        _GameManager.BlurExit.SetActive(true);
        _GameManager.Invoke("HideBlurExit", 0.20f);
        _GameManager.ShopDisplayPanel.SetActive(false);
        BackButton.SetActive(true);
        _GameManager.Restaurant = false;
    }
    
    public void SetFalse()
    {
        Image1Status = false;
        Image1.sprite = Empty;

        Image2Status = false;
        Image2.sprite = Empty;

        Image3Status = false;
        Image3.sprite = Empty;

        Image4Status = false;
        Image4.sprite = Empty;
    }

    public void StartHamburger()
    {
        int RandomNumber = Random.Range(0, 4);
        int Rnd = Random.Range(0, 6);
        SetFalse();
        FoodName = "<color='#C1AF80'>hamburger</color>";

        switch (RandomNumber)
        {
            case 0:
            Image1Status = true;
            Image1.sprite = Hamburger;
            if (Rnd == 0)
            {
                Image2.sprite = Hotdog;
                Image3.sprite = Chicken;
                Image4.sprite = Pizza;
            }
            else if (Rnd == 1)
            {
                Image2.sprite = Hotdog;
                Image3.sprite = Pizza;
                Image4.sprite = Chicken;
            }
            else if (Rnd == 2)
            {
                Image2.sprite = Chicken;
                Image3.sprite = Pizza;
                Image4.sprite = Hotdog;
            }
            else if (Rnd == 3)
            {
                Image2.sprite = Chicken;
                Image3.sprite = Hotdog;
                Image4.sprite = Pizza;
            }
            else if (Rnd == 4)
            {
                Image2.sprite = Pizza;
                Image3.sprite = Chicken;
                Image4.sprite = Hotdog;
            }
            else if (Rnd == 5)
            {
                Image2.sprite = Pizza;
                Image3.sprite = Hotdog;
                Image4.sprite = Chicken;
            }
            break;

            case 1:
            Image2Status = true;
            Image2.sprite = Hamburger;
            if (Rnd == 0)
            {
                Image1.sprite = Hotdog;
                Image3.sprite = Chicken;
                Image4.sprite = Pizza;
            }
            else if (Rnd == 1)
            {
                Image1.sprite = Hotdog;
                Image3.sprite = Pizza;
                Image4.sprite = Chicken;
            }
            else if (Rnd == 2)
            {
                Image1.sprite = Chicken;
                Image3.sprite = Pizza;
                Image4.sprite = Hotdog;
            }
            else if (Rnd == 3)
            {
                Image1.sprite = Chicken;
                Image3.sprite = Hotdog;
                Image4.sprite = Pizza;
            }
            else if (Rnd == 4)
            {
                Image1.sprite = Pizza;
                Image3.sprite = Chicken;
                Image4.sprite = Hotdog;
            }
            else if (Rnd == 5)
            {
                Image1.sprite = Pizza;
                Image3.sprite = Hotdog;
                Image4.sprite = Chicken;
            }
            break;

            case 2:
            Image3Status = true;
            Image3.sprite = Hamburger;
            if (Rnd == 0)
            {
                Image2.sprite = Hotdog;
                Image1.sprite = Chicken;
                Image4.sprite = Pizza;
            }
            else if (Rnd == 1)
            {
                Image2.sprite = Hotdog;
                Image1.sprite = Pizza;
                Image4.sprite = Chicken;
            }
            else if (Rnd == 2)
            {
                Image2.sprite = Chicken;
                Image1.sprite = Pizza;
                Image4.sprite = Hotdog;
            }
            else if (Rnd == 3)
            {
                Image2.sprite = Chicken;
                Image1.sprite = Hotdog;
                Image4.sprite = Pizza;
            }
            else if (Rnd == 4)
            {
                Image2.sprite = Pizza;
                Image1.sprite = Chicken;
                Image4.sprite = Hotdog;
            }
            else if (Rnd == 5)
            {
                Image2.sprite = Pizza;
                Image1.sprite = Hotdog;
                Image4.sprite = Chicken;
            }
            break;

            case 3:
            Image4Status = true;
            Image4.sprite = Hamburger;
            if (Rnd == 0)
            {
                Image2.sprite = Hotdog;
                Image3.sprite = Chicken;
                Image1.sprite = Pizza;
            }
            else if (Rnd == 1)
            {
                Image2.sprite = Hotdog;
                Image3.sprite = Pizza;
                Image1.sprite = Chicken;
            }
            else if (Rnd == 2)
            {
                Image2.sprite = Chicken;
                Image3.sprite = Pizza;
                Image1.sprite = Hotdog;
            }
            else if (Rnd == 3)
            {
                Image2.sprite = Chicken;
                Image3.sprite = Hotdog;
                Image1.sprite = Pizza;
            }
            else if (Rnd == 4)
            {
                Image2.sprite = Pizza;
                Image3.sprite = Chicken;
                Image1.sprite = Hotdog;
            }
            else if (Rnd == 5)
            {
                Image2.sprite = Pizza;
                Image3.sprite = Hotdog;
                Image1.sprite = Chicken;
            }
            break;
        }
    }


    public void StartChicken()
    {
        int RandomNumber = Random.Range(0, 4);
        int Rnd = Random.Range(0, 6);
        SetFalse();

        if (_GameManager.L) { FoodName = "<color='#C1AF80'>tavuk</color>"; }
        else { FoodName = "<color='#C1AF80'>chicken</color>"; }

        switch (RandomNumber)
        {
            case 0:
            Image1Status = true;
            Image1.sprite = Chicken;
            if (Rnd == 0)
            {
                Image2.sprite = Hamburger;
                Image3.sprite = Hotdog;
                Image4.sprite = Pizza;
            }
            else if (Rnd == 1)
            {
                Image2.sprite = Hamburger;
                Image3.sprite = Pizza;
                Image4.sprite = Hotdog;
            }
            else if (Rnd == 2)
            {
                Image2.sprite = Hotdog;
                Image3.sprite = Pizza;
                Image4.sprite = Hamburger;
            }
            else if (Rnd == 3)
            {
                Image2.sprite = Hotdog;
                Image3.sprite = Hamburger;
                Image4.sprite = Pizza;
            }
            else if (Rnd == 4)
            {
                Image2.sprite = Pizza;
                Image3.sprite = Hotdog;
                Image4.sprite = Hamburger;
            }
            else if (Rnd == 5)
            {
                Image2.sprite = Pizza;
                Image3.sprite = Hamburger;
                Image4.sprite = Hotdog;
            }
            break;

            case 1:
            Image2Status = true;
            Image2.sprite = Chicken;
            if (Rnd == 0)
            {
                Image1.sprite = Hamburger;
                Image3.sprite = Hotdog;
                Image4.sprite = Pizza;
            }
            else if (Rnd == 1)
            {
                Image1.sprite = Hamburger;
                Image3.sprite = Pizza;
                Image4.sprite = Hotdog;
            }
            else if (Rnd == 2)
            {
                Image1.sprite = Hotdog;
                Image3.sprite = Pizza;
                Image4.sprite = Hamburger;
            }
            else if (Rnd == 3)
            {
                Image1.sprite = Hotdog;
                Image3.sprite = Hamburger;
                Image4.sprite = Pizza;
            }
            else if (Rnd == 4)
            {
                Image1.sprite = Pizza;
                Image3.sprite = Hotdog;
                Image4.sprite = Hamburger;
            }
            else if (Rnd == 5)
            {
                Image1.sprite = Pizza;
                Image3.sprite = Hamburger;
                Image4.sprite = Hotdog;
            }
            break;

            case 2:
            Image3Status = true;
            Image3.sprite = Chicken;
            if (Rnd == 0)
            {
                Image2.sprite = Hamburger;
                Image1.sprite = Hotdog;
                Image4.sprite = Pizza;
            }
            else if (Rnd == 1)
            {
                Image2.sprite = Hamburger;
                Image1.sprite = Pizza;
                Image4.sprite = Hotdog;
            }
            else if (Rnd == 2)
            {
                Image2.sprite = Hotdog;
                Image1.sprite = Pizza;
                Image4.sprite = Hamburger;
            }
            else if (Rnd == 3)
            {
                Image2.sprite = Hotdog;
                Image1.sprite = Hamburger;
                Image4.sprite = Pizza;
            }
            else if (Rnd == 4)
            {
                Image2.sprite = Pizza;
                Image1.sprite = Hotdog;
                Image4.sprite = Hamburger;
            }
            else if (Rnd == 5)
            {
                Image2.sprite = Pizza;
                Image1.sprite = Hamburger;
                Image4.sprite = Hotdog;
            }
            break;

            case 3:
            Image4Status = true;
            Image4.sprite = Chicken;
            if (Rnd == 0)
            {
                Image2.sprite = Hamburger;
                Image3.sprite = Hotdog;
                Image1.sprite = Pizza;
            }
            else if (Rnd == 1)
            {
                Image2.sprite = Hamburger;
                Image3.sprite = Pizza;
                Image1.sprite = Hotdog;
            }
            else if (Rnd == 2)
            {
                Image2.sprite = Hotdog;
                Image3.sprite = Pizza;
                Image1.sprite = Hamburger;
            }
            else if (Rnd == 3)
            {
                Image2.sprite = Hotdog;
                Image3.sprite = Hamburger;
                Image1.sprite = Pizza;
            }
            else if (Rnd == 4)
            {
                Image2.sprite = Pizza;
                Image3.sprite = Hotdog;
                Image1.sprite = Hamburger;
            }
            else if (Rnd == 5)
            {
                Image2.sprite = Pizza;
                Image3.sprite = Hamburger;
                Image1.sprite = Hotdog;
            }
            break;
        }
    }

    public void StartHotdog()
    {
        int RandomNumber = Random.Range(0, 4);
        int Rnd = Random.Range(0, 6);

        SetFalse();

        if (_GameManager.L) { FoodName = "<color='#C1AF80'>sosisli sandviç</color>"; }
        else { FoodName = "<color='#C1AF80'>hot dog</color>"; }

        switch (RandomNumber)
        {
            case 0:
            Image1Status = true;
            Image1.sprite = Hotdog;
            if (Rnd == 0)
            {
                Image2.sprite = Hamburger;
                Image3.sprite = Chicken;
                Image4.sprite = Pizza;
            }
            else if (Rnd == 1)
            {
                Image2.sprite = Hamburger;
                Image3.sprite = Pizza;
                Image4.sprite = Chicken;
            }
            else if (Rnd == 2)
            {
                Image2.sprite = Chicken;
                Image3.sprite = Pizza;
                Image4.sprite = Hamburger;
            }
            else if (Rnd == 3)
            {
                Image2.sprite = Chicken;
                Image3.sprite = Hamburger;
                Image4.sprite = Pizza;
            }
            else if (Rnd == 4)
            {
                Image2.sprite = Pizza;
                Image3.sprite = Chicken;
                Image4.sprite = Hamburger;
            }
            else if (Rnd == 5)
            {
                Image2.sprite = Pizza;
                Image3.sprite = Hamburger;
                Image4.sprite = Chicken;
            }
            break;

            case 1:
            Image2Status = true;
            Image2.sprite = Hotdog;
            if (Rnd == 0)
            {
                Image1.sprite = Hamburger;
                Image3.sprite = Chicken;
                Image4.sprite = Pizza;
            }
            else if (Rnd == 1)
            {
                Image1.sprite = Hamburger;
                Image3.sprite = Pizza;
                Image4.sprite = Chicken;
            }
            else if (Rnd == 2)
            {
                Image1.sprite = Chicken;
                Image3.sprite = Pizza;
                Image4.sprite = Hamburger;
            }
            else if (Rnd == 3)
            {
                Image1.sprite = Chicken;
                Image3.sprite = Hamburger;
                Image4.sprite = Pizza;
            }
            else if (Rnd == 4)
            {
                Image1.sprite = Pizza;
                Image3.sprite = Chicken;
                Image4.sprite = Hamburger;
            }
            else if (Rnd == 5)
            {
                Image1.sprite = Pizza;
                Image3.sprite = Hamburger;
                Image4.sprite = Chicken;
            }
            break;

            case 2:
            Image3Status = true;
            Image3.sprite = Hotdog;
            if (Rnd == 0)
            {
                Image2.sprite = Hamburger;
                Image1.sprite = Chicken;
                Image4.sprite = Pizza;
            }
            else if (Rnd == 1)
            {
                Image2.sprite = Hamburger;
                Image1.sprite = Pizza;
                Image4.sprite = Chicken;
            }
            else if (Rnd == 2)
            {
                Image2.sprite = Chicken;
                Image1.sprite = Pizza;
                Image4.sprite = Hamburger;
            }
            else if (Rnd == 3)
            {
                Image2.sprite = Chicken;
                Image1.sprite = Hamburger;
                Image4.sprite = Pizza;
            }
            else if (Rnd == 4)
            {
                Image2.sprite = Pizza;
                Image1.sprite = Chicken;
                Image4.sprite = Hamburger;
            }
            else if (Rnd == 5)
            {
                Image2.sprite = Pizza;
                Image1.sprite = Hamburger;
                Image4.sprite = Chicken;
            }
            break;

            case 3:
            Image4Status = true;
            Image4.sprite = Hotdog;
            if (Rnd == 0)
            {
                Image2.sprite = Hamburger;
                Image3.sprite = Chicken;
                Image1.sprite = Pizza;
            }
            else if (Rnd == 1)
            {
                Image2.sprite = Hamburger;
                Image3.sprite = Pizza;
                Image1.sprite = Chicken;
            }
            else if (Rnd == 2)
            {
                Image2.sprite = Chicken;
                Image3.sprite = Pizza;
                Image1.sprite = Hamburger;
            }
            else if (Rnd == 3)
            {
                Image2.sprite = Chicken;
                Image3.sprite = Hamburger;
                Image1.sprite = Pizza;
            }
            else if (Rnd == 4)
            {
                Image2.sprite = Pizza;
                Image3.sprite = Chicken;
                Image1.sprite = Hamburger;
            }
            else if (Rnd == 5)
            {
                Image2.sprite = Pizza;
                Image3.sprite = Hamburger;
                Image1.sprite = Chicken;
            }
            break;
        }
    }

    public void StartPizza()
    {
        int RandomNumber = Random.Range(0, 4);
        int Rnd = Random.Range(0, 6);

        SetFalse();

        FoodName = "<color='#C1AF80'>pizza</color>";

        switch (RandomNumber)
        {
            case 0:
            Image1Status = true;
            Image1.sprite = Pizza;
            if (Rnd == 0)
            {
                Image2.sprite = Hamburger;
                Image3.sprite = Hotdog;
                Image4.sprite = Chicken;
            }
            else if (Rnd == 1)
            {
                Image2.sprite = Hamburger;
                Image3.sprite = Chicken;
                Image4.sprite = Hotdog;
            }
            else if (Rnd == 2)
            {
                Image2.sprite = Hotdog;
                Image3.sprite = Chicken;
                Image4.sprite = Hamburger;
            }
            else if (Rnd == 3)
            {
                Image2.sprite = Hotdog;
                Image3.sprite = Hamburger;
                Image4.sprite = Chicken;
            }
            else if (Rnd == 4)
            {
                Image2.sprite = Chicken;
                Image3.sprite = Hotdog;
                Image4.sprite = Hamburger;
            }
            else if (Rnd == 5)
            {
                Image2.sprite = Chicken;
                Image3.sprite = Hamburger;
                Image4.sprite = Hotdog;
            }
            break;

            case 1:
            Image2Status = true;
            Image2.sprite = Pizza;
            if (Rnd == 0)
            {
                Image1.sprite = Hamburger;
                Image3.sprite = Hotdog;
                Image4.sprite = Chicken;
            }
            else if (Rnd == 1)
            {
                Image1.sprite = Hamburger;
                Image3.sprite = Chicken;
                Image4.sprite = Hotdog;
            }
            else if (Rnd == 2)
            {
                Image1.sprite = Hotdog;
                Image3.sprite = Chicken;
                Image4.sprite = Hamburger;
            }
            else if (Rnd == 3)
            {
                Image1.sprite = Hotdog;
                Image3.sprite = Hamburger;
                Image4.sprite = Chicken;
            }
            else if (Rnd == 4)
            {
                Image1.sprite = Chicken;
                Image3.sprite = Hotdog;
                Image4.sprite = Hamburger;
            }
            else if (Rnd == 5)
            {
                Image1.sprite = Chicken;
                Image3.sprite = Hamburger;
                Image4.sprite = Hotdog;
            }
            break;

            case 2:
            Image3Status = true;
            Image3.sprite = Pizza;
            if (Rnd == 0)
            {
                Image2.sprite = Hamburger;
                Image1.sprite = Hotdog;
                Image4.sprite = Chicken;
            }
            else if (Rnd == 1)
            {
                Image2.sprite = Hamburger;
                Image1.sprite = Chicken;
                Image4.sprite = Hotdog;
            }
            else if (Rnd == 2)
            {
                Image2.sprite = Hotdog;
                Image1.sprite = Chicken;
                Image4.sprite = Hamburger;
            }
            else if (Rnd == 3)
            {
                Image2.sprite = Hotdog;
                Image1.sprite = Hamburger;
                Image4.sprite = Chicken;
            }
            else if (Rnd == 4)
            {
                Image2.sprite = Chicken;
                Image1.sprite = Hotdog;
                Image4.sprite = Hamburger;
            }
            else if (Rnd == 5)
            {
                Image2.sprite = Chicken;
                Image1.sprite = Hamburger;
                Image4.sprite = Hotdog;
            }
            break;

            case 3:
            Image4Status = true;
            Image4.sprite = Pizza;
            if (Rnd == 0)
            {
                Image2.sprite = Hamburger;
                Image3.sprite = Hotdog;
                Image1.sprite = Chicken;
            }
            else if (Rnd == 1)
            {
                Image2.sprite = Hamburger;
                Image3.sprite = Chicken;
                Image1.sprite = Hotdog;
            }
            else if (Rnd == 2)
            {
                Image2.sprite = Hotdog;
                Image3.sprite = Chicken;
                Image1.sprite = Hamburger;
            }
            else if (Rnd == 3)
            {
                Image2.sprite = Hotdog;
                Image3.sprite = Hamburger;
                Image1.sprite = Chicken;
            }
            else if (Rnd == 4)
            {
                Image2.sprite = Chicken;
                Image3.sprite = Hotdog;
                Image1.sprite = Hamburger;
            }
            else if (Rnd == 5)
            {
                Image2.sprite = Chicken;
                Image3.sprite = Hamburger;
                Image1.sprite = Hotdog;
            }
            break;
        }
    }
}
