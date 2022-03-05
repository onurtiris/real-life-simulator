using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobGame : MonoBehaviour
{
    GameManager _GameManager;

    public float Second;
    public Text TimeText;
    public Text PointText;
    public Text InformationText;
    public int Point = 0;
    int RandomFood;

    public Image ClickImage1;
    public Image ClickImage2;
    public Image ClickImage3;
    public Image ClickImage4;
    public Image ClickImage5;
    public Image ClickImage6;
    public Image ClickImage7;
    public Image ClickImage8;

    public GameObject StartButton;
    public GameObject StopButton;

    public Text JobMessageText;
    public int JobMoney;
    public string JobName;

    public Image JobGamePanelBackground;

    public Sprite WithCharacter;
    public Sprite Flat;

    public GameObject MiniGamePanel;
    public GameObject JobGamePanel;

    public int DifficultyLevel;

    int RandomMix;
    string TrueImage = "";

    public GameObject CharacterMask;
    public GameObject InformationPanel;

    public Sprite[] ComputerSprite;
    public Sprite[] OfficeSprite;
    public Sprite[] SportSprite;
    public Sprite[] LawSprite;
    public Sprite[] ArtistSprite;
    public Sprite[] DoctorSprite;

    public void ReShuffle(Sprite[] array)
    {
        for (int t = 0; t < array.Length; t++)
        {
            Sprite tmp = array[t];
            int r = Random.Range(t, array.Length);
            array[t] = array[r];
            array[r] = tmp;
        }
    }

    void Start()
    {
        this.enabled = true;
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartButton.SetActive(true);
        StopButton.SetActive(true);
    }

    public void StartTheGame()
    {
        this.enabled = true;

        InformationPanel.SetActive(false);
        CharacterMask.SetActive(false);
        Start();
        Point = 0;

        _GameManager.JobCounter = 7;
        _GameManager.UpdateUI();

        DifficultyLevel = _GameManager.CacheJobLevel;
        JobMoney = _GameManager.CacheJobMoney;
        JobName = _GameManager.CacheJobName;

        MiniGamePanel.SetActive(true);

        _GameManager.Blur.SetActive(true);
        JobGamePanelBackground.sprite = Flat;

        if (DifficultyLevel == 3 || DifficultyLevel == 6 || DifficultyLevel == 9 || DifficultyLevel == 12 || DifficultyLevel == 15 || DifficultyLevel == 18) { Second = 20; }
        else if (DifficultyLevel == 2 || DifficultyLevel == 5 || DifficultyLevel == 8 || DifficultyLevel == 11 || DifficultyLevel == 14 || DifficultyLevel == 17) { Second = 25; }
        else if (DifficultyLevel == 1 || DifficultyLevel == 4 || DifficultyLevel == 7 || DifficultyLevel == 10 || DifficultyLevel == 13 || DifficultyLevel == 16) { Second = 30; }
        else { Second = 10; }

        Setup();
    }

    public void Setup()
    {
        if (_GameManager.CacheJobLevel == 1 || _GameManager.CacheJobLevel == 2 || _GameManager.CacheJobLevel == 3)
        {
            ReShuffle(ComputerSprite);

            ClickImage1.sprite = ComputerSprite[0]; ClickImage2.sprite = ComputerSprite[1]; ClickImage3.sprite = ComputerSprite[2]; ClickImage4.sprite = ComputerSprite[3];
            ClickImage5.sprite = ComputerSprite[4]; ClickImage6.sprite = ComputerSprite[5]; ClickImage7.sprite = ComputerSprite[6]; ClickImage8.sprite = ComputerSprite[7];

            MixComputer();
        }
        else if (_GameManager.CacheJobLevel == 4 || _GameManager.CacheJobLevel == 5 || _GameManager.CacheJobLevel == 6)
        {
            ReShuffle(OfficeSprite);

            ClickImage1.sprite = OfficeSprite[0]; ClickImage2.sprite = OfficeSprite[1]; ClickImage3.sprite = OfficeSprite[2]; ClickImage4.sprite = OfficeSprite[3];
            ClickImage5.sprite = OfficeSprite[4]; ClickImage6.sprite = OfficeSprite[5]; ClickImage7.sprite = OfficeSprite[6]; ClickImage8.sprite = OfficeSprite[7];

            MixOffice();
        }
        else if (_GameManager.CacheJobLevel == 7 || _GameManager.CacheJobLevel == 8 || _GameManager.CacheJobLevel == 9)
        {
            ReShuffle(ArtistSprite);

            ClickImage1.sprite = ArtistSprite[0]; ClickImage2.sprite = ArtistSprite[1]; ClickImage3.sprite = ArtistSprite[2]; ClickImage4.sprite = ArtistSprite[3];
            ClickImage5.sprite = ArtistSprite[4]; ClickImage6.sprite = ArtistSprite[5]; ClickImage7.sprite = ArtistSprite[6]; ClickImage8.sprite = ArtistSprite[7];

            MixArtist();
        }
        else if (_GameManager.CacheJobLevel == 10 || _GameManager.CacheJobLevel == 11 || _GameManager.CacheJobLevel == 12)
        {
            ReShuffle(DoctorSprite);

            ClickImage1.sprite = DoctorSprite[0]; ClickImage2.sprite = DoctorSprite[1]; ClickImage3.sprite = DoctorSprite[2]; ClickImage4.sprite = DoctorSprite[3];
            ClickImage5.sprite = DoctorSprite[4]; ClickImage6.sprite = DoctorSprite[5]; ClickImage7.sprite = DoctorSprite[6]; ClickImage8.sprite = DoctorSprite[7];

            MixDoctor();
        }
        else if (_GameManager.CacheJobLevel == 13 || _GameManager.CacheJobLevel == 14 || _GameManager.CacheJobLevel == 15)
        {
            ReShuffle(LawSprite);

            ClickImage1.sprite = LawSprite[0]; ClickImage2.sprite = LawSprite[1]; ClickImage3.sprite = LawSprite[2]; ClickImage4.sprite = LawSprite[3];
            ClickImage5.sprite = LawSprite[4]; ClickImage6.sprite = LawSprite[5]; ClickImage7.sprite = LawSprite[6]; ClickImage8.sprite = LawSprite[7];

            MixLaw();
        }
        else if (_GameManager.CacheJobLevel == 16 || _GameManager.CacheJobLevel == 17 || _GameManager.CacheJobLevel == 18)
        {
            ReShuffle(SportSprite);

            ClickImage1.sprite = SportSprite[0]; ClickImage2.sprite = SportSprite[1]; ClickImage3.sprite = SportSprite[2]; ClickImage4.sprite = SportSprite[3];
            ClickImage5.sprite = SportSprite[4]; ClickImage6.sprite = SportSprite[5]; ClickImage7.sprite = SportSprite[6]; ClickImage8.sprite = SportSprite[7];

            MixSport();
        }
    }

    public void MixComputer()
    {
        RandomMix = Random.Range(0, 7);
        if (_GameManager.L)
        {
            switch (RandomMix)
            {
                case 0:
                TrueImage = "Printer";
                InformationText.text = "<color='#C1AF80'>Yazıcı</color> resmine dokunmalısın";
                break;
                case 1:
                TrueImage = "Mouse";
                InformationText.text = "<color='#C1AF80'>Fare</color> resmine dokunmalısın";
                break;
                case 2:
                TrueImage = "Laptop";
                InformationText.text = "<color='#C1AF80'>Laptop</color> resmine dokunmalısın";
                break;
                case 3:
                TrueImage = "Tablet";
                InformationText.text = "<color='#C1AF80'>Tablet</color> resmine dokunmalısın";
                break;
                case 4:
                TrueImage = "Keyboard";
                InformationText.text = "<color='#C1AF80'>Klavye</color> resmine dokunmalısın";
                break;
                case 5:
                TrueImage = "Headphones";
                InformationText.text = "<color='#C1AF80'>Kulaklık</color> resmine dokunmalısın";
                break;
                case 6:
                TrueImage = "Modem";
                InformationText.text = "<color='#C1AF80'>Modem</color> resmine dokunmalısın";
                break;
                case 7:
                TrueImage = "USB";
                InformationText.text = "<color='#C1AF80'>USB</color> resmine dokunmalısın";
                break;
            }
        }
        else
        {
            switch (RandomMix)
            {
                case 0:
                TrueImage = "Printer";
                InformationText.text = "You should touch the <color='#C1AF80'>Printer</color> picture";
                break;
                case 1:
                TrueImage = "Mouse";
                InformationText.text = "You should touch the <color='#C1AF80'>Mouse</color> picture";
                break;
                case 2:
                TrueImage = "Laptop";
                InformationText.text = "You should touch the <color='#C1AF80'>Laptop</color> picture";
                break;
                case 3:
                TrueImage = "Tablet";
                InformationText.text = "You should touch the <color='#C1AF80'>Tablet</color> picture";
                break;
                case 4:
                TrueImage = "Keyboard";
                InformationText.text = "You should touch the <color='#C1AF80'>Keyboard</color> picture";
                break;
                case 5:
                TrueImage = "Headphones";
                InformationText.text = "You should touch the <color='#C1AF80'>Headphones</color> picture";
                break;
                case 6:
                TrueImage = "Modem";
                InformationText.text = "You should touch the <color='#C1AF80'>Modem</color> picture";
                break;
                case 7:
                TrueImage = "USB";
                InformationText.text = "You should touch the <color='#C1AF80'>USB</color> picture";
                break;
            }
        }
    }

    public void MixOffice()
    {
        RandomMix = Random.Range(0, 7);
        if (_GameManager.L)
        {
            switch (RandomMix)
            {
                case 0:
                TrueImage = "Archives";
                InformationText.text = "<color='#C1AF80'>Dosya</color> resmine dokunmalısın";
                break;
                case 1:
                TrueImage = "Briefcase";
                InformationText.text = "<color='#C1AF80'>Çanta</color> resmine dokunmalısın";
                break;
                case 2:
                TrueImage = "Calculator";
                InformationText.text = "<color='#C1AF80'>Hesap makinesi</color> resmine dokunmalısın";
                break;
                case 3:
                TrueImage = "Calendar";
                InformationText.text = "<color='#C1AF80'>Takvim</color> resmine dokunmalısın";
                break;
                case 4:
                TrueImage = "Pen";
                InformationText.text = "<color='#C1AF80'>Kalem</color> resmine dokunmalısın";
                break;
                case 5:
                TrueImage = "PencilSharp";
                InformationText.text = "<color='#C1AF80'>Kalemtraş</color> resmine dokunmalısın";
                break;
                case 6:
                TrueImage = "Postcard";
                InformationText.text = "<color='#C1AF80'>Evrak</color> resmine dokunmalısın";
                break;
                case 7:
                TrueImage = "Scissor";
                InformationText.text = "<color='#C1AF80'>Makas</color> resmine dokunmalısın";
                break;
            }
        }
        else
        {
            switch (RandomMix)
            {
                case 0:
                TrueImage = "Archives";
                InformationText.text = "You should touch the <color='#C1AF80'>Archives</color> picture";
                break;
                case 1:
                TrueImage = "Briefcase";
                InformationText.text = "You should touch the <color='#C1AF80'>Briefcase</color> picture";
                break;
                case 2:
                TrueImage = "Calculator";
                InformationText.text = "You should touch the <color='#C1AF80'>Calculator</color> picture";
                break;
                case 3:
                TrueImage = "Calendar";
                InformationText.text = "You should touch the <color='#C1AF80'>Calendar</color> picture";
                break;
                case 4:
                TrueImage = "Pen";
                InformationText.text = "You should touch the <color='#C1AF80'>Pen</color> picture";
                break;
                case 5:
                TrueImage = "PencilSharp";
                InformationText.text = "You should touch the <color='#C1AF80'>Sharpener</color> picture";
                break;
                case 6:
                TrueImage = "Postcard";
                InformationText.text = "You should touch the <color='#C1AF80'>Document</color> picture";
                break;
                case 7:
                TrueImage = "Scissor";
                InformationText.text = "You should touch the <color='#C1AF80'>Scissor</color> picture";
                break;
            }
        }
    }

    public void MixArtist()
    {
        RandomMix = Random.Range(0, 7);
        if (_GameManager.L)
        {
            switch (RandomMix)
            {
                case 0:
                TrueImage = "Camera";
                InformationText.text = "<color='#C1AF80'>Kamera</color> resmine dokunmalısın";
                break;
                case 1:
                TrueImage = "Colors";
                InformationText.text = "<color='#C1AF80'>Renkli kalem</color> resmine dokunmalısın";
                break;
                case 2:
                TrueImage = "Easel";
                InformationText.text = "<color='#C1AF80'>Şövale</color> resmine dokunmalısın";
                break;
                case 3:
                TrueImage = "Guitar";
                InformationText.text = "<color='#C1AF80'>Gitar</color> resmine dokunmalısın";
                break;
                case 4:
                TrueImage = "Microphone";
                InformationText.text = "<color='#C1AF80'>Mikrofon</color> resmine dokunmalısın";
                break;
                case 5:
                TrueImage = "Palette";
                InformationText.text = "<color='#C1AF80'>Resim paleti</color> resmine dokunmalısın";
                break;
                case 6:
                TrueImage = "Ruler";
                InformationText.text = "<color='#C1AF80'>Cetvel</color> resmine dokunmalısın";
                break;
                case 7:
                TrueImage = "Vase";
                InformationText.text = "<color='#C1AF80'>Vazo</color> resmine dokunmalısın";
                break;
            }
        }
        else
        {
            switch (RandomMix)
            {
                case 0:
                TrueImage = "Camera";
                InformationText.text = "You should touch the <color='#C1AF80'>Camera</color> picture";
                break;
                case 1:
                TrueImage = "Colors";
                InformationText.text = "You should touch the <color='#C1AF80'>Colored Pencils</color> picture";
                break;
                case 2:
                TrueImage = "Easel";
                InformationText.text = "You should touch the <color='#C1AF80'>Easel</color> picture";
                break;
                case 3:
                TrueImage = "Guitar";
                InformationText.text = "You should touch the <color='#C1AF80'>Guitar</color> picture";
                break;
                case 4:
                TrueImage = "Microphone";
                InformationText.text = "You should touch the <color='#C1AF80'>Microphone</color> picture";
                break;
                case 5:
                TrueImage = "Palette";
                InformationText.text = "You should touch the <color='#C1AF80'>Palette</color> picture";
                break;
                case 6:
                TrueImage = "Ruler";
                InformationText.text = "You should touch the <color='#C1AF80'>Ruler</color> picture";
                break;
                case 7:
                TrueImage = "Vase";
                InformationText.text = "You should touch the <color='#C1AF80'>Vase</color> picture";
                break;
            }
        }
    }

    public void MixDoctor()
    {
        RandomMix = Random.Range(0, 7);
        if (_GameManager.L)
        {
            switch (RandomMix)
            {
                case 0:
                TrueImage = "Ambulance";
                InformationText.text = "<color='#C1AF80'>Ambulans</color> resmine dokunmalısın";
                break;
                case 1:
                TrueImage = "BabyFeeder";
                InformationText.text = "<color='#C1AF80'>Emzik</color> resmine dokunmalısın";
                break;
                case 2:
                TrueImage = "Bandage";
                InformationText.text = "<color='#C1AF80'>Yara bandı</color> resmine dokunmalısın";
                break;
                case 3:
                TrueImage = "Hospital";
                InformationText.text = "<color='#C1AF80'>Hastane</color> resmine dokunmalısın";
                break;
                case 4:
                TrueImage = "Medicine";
                InformationText.text = "<color='#C1AF80'>İlaç</color> resmine dokunmalısın";
                break;
                case 5:
                TrueImage = "Stethoscope";
                InformationText.text = "<color='#C1AF80'>Stetoskop</color> resmine dokunmalısın";
                break;
                case 6:
                TrueImage = "Syringe";
                InformationText.text = "<color='#C1AF80'>Şırınga</color> resmine dokunmalısın";
                break;
                case 7:
                TrueImage = "Thermometer";
                InformationText.text = "<color='#C1AF80'>Ateş ölçer</color> resmine dokunmalısın";
                break;
            }
        }
        else
        {
            switch (RandomMix)
            {
                case 0:
                TrueImage = "Ambulance";
                InformationText.text = "You should touch the <color='#C1AF80'>Ambulance</color> picture";
                break;
                case 1:
                TrueImage = "BabyFeeder";
                InformationText.text = "You should touch the <color='#C1AF80'>Baby Feeder</color> picture";
                break;
                case 2:
                TrueImage = "Bandage";
                InformationText.text = "You should touch the <color='#C1AF80'>Bandage</color> picture";
                break;
                case 3:
                TrueImage = "Hospital";
                InformationText.text = "You should touch the <color='#C1AF80'>Hospital</color> picture";
                break;
                case 4:
                TrueImage = "Medicine";
                InformationText.text = "You should touch the <color='#C1AF80'>Medicine</color> picture";
                break;
                case 5:
                TrueImage = "Stethoscope";
                InformationText.text = "You should touch the <color='#C1AF80'>Stethoscope</color> picture";
                break;
                case 6:
                TrueImage = "Syringe";
                InformationText.text = "You should touch the <color='#C1AF80'>Syringe</color> picture";
                break;
                case 7:
                TrueImage = "Thermometer";
                InformationText.text = "You should touch the <color='#C1AF80'>Thermometer</color> picture";
                break;
            }
        }
    }

    public void MixLaw()
    {
        RandomMix = Random.Range(0, 7);
        if (_GameManager.L)
        {
            switch (RandomMix)
            {
                case 0:
                TrueImage = "Agreement";
                InformationText.text = "<color='#C1AF80'>Sözleşme</color> resmine dokunmalısın";
                break;
                case 1:
                TrueImage = "Binder";
                InformationText.text = "<color='#C1AF80'>Dosya</color> resmine dokunmalısın";
                break;
                case 2:
                TrueImage = "Book";
                InformationText.text = "<color='#C1AF80'>Kitap</color> resmine dokunmalısın";
                break;
                case 3:
                TrueImage = "Briefcase";
                InformationText.text = "<color='#C1AF80'>Çanta</color> resmine dokunmalısın";
                break;
                case 4:
                TrueImage = "Certificate";
                InformationText.text = "<color='#C1AF80'>Sertifika</color> resmine dokunmalısın";
                break;
                case 5:
                TrueImage = "Gavel";
                InformationText.text = "<color='#C1AF80'>Gavel</color> resmine dokunmalısın";
                break;
                case 6:
                TrueImage = "Letter";
                InformationText.text = "<color='#C1AF80'>Mektup</color> resmine dokunmalısın";
                break;
                case 7:
                TrueImage = "Typewriter";
                InformationText.text = "<color='#C1AF80'>Daktilo</color> resmine dokunmalısın";
                break;
            }
        }
        else
        {
            switch (RandomMix)
            {
                case 0:
                TrueImage = "Agreement";
                InformationText.text = "You should touch the <color='#C1AF80'>Agreement</color> picture";
                break;
                case 1:
                TrueImage = "Binder";
                InformationText.text = "You should touch the <color='#C1AF80'>Archives</color> picture";
                break;
                case 2:
                TrueImage = "Book";
                InformationText.text = "You should touch the <color='#C1AF80'>Book</color> picture";
                break;
                case 3:
                TrueImage = "Briefcase";
                InformationText.text = "You should touch the <color='#C1AF80'>Briefcase</color> picture";
                break;
                case 4:
                TrueImage = "Certificate";
                InformationText.text = "You should touch the <color='#C1AF80'>Certificate</color> picture";
                break;
                case 5:
                TrueImage = "Gavel";
                InformationText.text = "You should touch the <color='#C1AF80'>Gavel</color> picture";
                break;
                case 6:
                TrueImage = "Letter";
                InformationText.text = "You should touch the <color='#C1AF80'>Letter</color> picture";
                break;
                case 7:
                TrueImage = "Typewriter";
                InformationText.text = "You should touch the <color='#C1AF80'>Typewriter</color> picture";
                break;
            }
        }
    }

    public void MixSport()
    {
        RandomMix = Random.Range(0, 7);
        if (_GameManager.L)
        {
            switch (RandomMix)
            {
                case 0:
                TrueImage = "Basketball";
                InformationText.text = "<color='#C1AF80'>Basketbol topu</color> resmine dokunmalısın";
                break;
                case 1:
                TrueImage = "Billiard";
                InformationText.text = "<color='#C1AF80'>Bilardo topu</color> resmine dokunmalısın";
                break;
                case 2:
                TrueImage = "BoxingGlove";
                InformationText.text = "<color='#C1AF80'>Boks eldiveni</color> resmine dokunmalısın";
                break;
                case 3:
                TrueImage = "Cup";
                InformationText.text = "<color='#C1AF80'>Kupa</color> resmine dokunmalısın";
                break;
                case 4:
                TrueImage = "Golf";
                InformationText.text = "<color='#C1AF80'>Golf topu</color> resmine dokunmalısın";
                break;
                case 5:
                TrueImage = "PingPong";
                InformationText.text = "<color='#C1AF80'>Masa tenisi raketi</color> resmine dokunmalısın";
                break;
                case 6:
                TrueImage = "Soccer";
                InformationText.text = "<color='#C1AF80'>Futbol topu</color> resmine dokunmalısın";
                break;
                case 7:
                TrueImage = "TennisRacket";
                InformationText.text = "<color='#C1AF80'>Tenis raketi</color> resmine dokunmalısın";
                break;
            }
        }
        else
        {
            switch (RandomMix)
            {
                case 0:
                TrueImage = "Basketball";
                InformationText.text = "You should touch the <color='#C1AF80'>Basketball Ball</color> picture";
                break;
                case 1:
                TrueImage = "Billiard";
                InformationText.text = "You should touch the <color='#C1AF80'>Billiard Ball</color> picture";
                break;
                case 2:
                TrueImage = "BoxingGlove";
                InformationText.text = "You should touch the <color='#C1AF80'>Boxing Glove</color> picture";
                break;
                case 3:
                TrueImage = "Cup";
                InformationText.text = "You should touch the <color='#C1AF80'>Cup</color> picture";
                break;
                case 4:
                TrueImage = "Golf";
                InformationText.text = "You should touch the <color='#C1AF80'>Golf Ball</color> picture";
                break;
                case 5:
                TrueImage = "PingPong";
                InformationText.text = "You should touch the <color='#C1AF80'>Pin Pong Racket</color> picture";
                break;
                case 6:
                TrueImage = "Soccer";
                InformationText.text = "You should touch the <color='#C1AF80'>Soccer Ball</color> picture";
                break;
                case 7:
                TrueImage = "TennisRacket";
                InformationText.text = "You should touch the <color='#C1AF80'>Tennis Racket</color> picture";
                break;
            }
        }
    }


    public void CheckButton(Image ClickImage)
    {
        if (ClickImage.sprite.name == TrueImage) { Point += 1; _GameManager.TapSound.Play(); }
        else { Point -= 2; _GameManager.Tap2Sound.Play(); }
        
        Setup();
    }

    public void CloseButton()
    {
        Start();
        _GameManager.Blur.SetActive(false);
        MiniGamePanel.SetActive(false);

        InformationPanel.SetActive(true);
        StartButton.SetActive(true);
        StopButton.SetActive(true);

        JobGamePanel.SetActive(false);
        
        this.enabled = false;
    }

    void Update()
    {

        PointText.text = Point + "/10";
        Second -= Time.deltaTime;
        
        if (Second <= 5)
        {
            if (_GameManager.L) { TimeText.text = "<color='#F77F64'>" + (int)Second + "sn</color>"; }
            else { TimeText.text = "<color='#F77F64'>" + (int)Second + "sec</color>"; }
        }
        else
        {
            if (_GameManager.L) { TimeText.text = (int)Second + "sn"; }
            else { TimeText.text = (int)Second + "sec"; }
        }

        if (Point >= 10)
        {
            this.enabled = false;
            MiniGamePanel.SetActive(false);
            StartButton.SetActive(false);
            StopButton.SetActive(false);
            JobGamePanelBackground.sprite = WithCharacter;
            InformationPanel.SetActive(true);
            CharacterMask.SetActive(true);

            _GameManager.Blur.SetActive(false);
            _GameManager.BlurExit.SetActive(true);
            _GameManager.Invoke("HideBlurExit", 0.20f);

            if (_GameManager.Food >= 35)
            {
                RandomFood = Random.Range(5, 35);
                if (_GameManager.L) { JobMessageText.text = "<color='#3DB4C9'>Sekreter: </color>" + JobName + " işi için $" + JobMoney + " hesabınıza yatırıldı.\n\n<color='#D9C89D'>Para: $" + _GameManager.Money + " > $" + (_GameManager.Money + JobMoney) + "\nYemek: %" + _GameManager.Food + " > %" + (_GameManager.Food - RandomFood) + "</color>"; }
                else { JobMessageText.text = "<color='#3DB4C9'>Secretary: </color>You were paid $" + JobMoney + " for " + JobName + " work.\n\n<color='#D9C89D'>Money: $" + _GameManager.Money + " > $" + (_GameManager.Money + JobMoney) + "\nFood: %" + _GameManager.Food + " > %" + (_GameManager.Food - RandomFood) + "</color>"; }
                
                _GameManager.Food -= RandomFood;
                _GameManager.AlertSound.Play();
            }
            else
            {
                RandomFood = Random.Range(1, 25);
                if (_GameManager.L) { JobMessageText.text = "<color='#3DB4C9'>Sekreter: </color>" + JobName + " işi için $" + JobMoney + " hesabınıza yatırıldı.\n\n<color='#D9C89D'>Para: $" + _GameManager.Money + " > $" + (_GameManager.Money + JobMoney) + "\nYemek: %" + _GameManager.Food + " > %" + (_GameManager.Food - RandomFood) + "</color>"; }
                else { JobMessageText.text = "<color='#3DB4C9'>Secretary: </color>You were paid $" + JobMoney + " for " + JobName + " work.\n\n<color='#D9C89D'>Money: $" + _GameManager.Money + " > $" + (_GameManager.Money + JobMoney) + "\nFood: %" + _GameManager.Food + " > %" + (_GameManager.Food - RandomFood) + "</color>"; }
                
                _GameManager.Food -= RandomFood;
                _GameManager.AlertSound.Play();
            }

            _GameManager.Money += JobMoney;
            _GameManager.UpdateUI();
            this.enabled = false;
        }

        if (Second <= 0)
        {

            this.enabled = false;
            MiniGamePanel.SetActive(false);
            StartButton.SetActive(false);
            StopButton.SetActive(false);
            JobGamePanelBackground.sprite = WithCharacter;
            InformationPanel.SetActive(true);
            CharacterMask.SetActive(true);

            _GameManager.Blur.SetActive(false);
            _GameManager.BlurExit.SetActive(true);
            _GameManager.Invoke("HideBlurExit", 0.20f);

            if (Point >= 10)
            {
                if (_GameManager.Food >= 35)
                {
                    RandomFood = Random.Range(5, 35);
                    if (_GameManager.L) { JobMessageText.text = "<color='#3DB4C9'>Sekreter: </color>" + JobName + " işi için $" + JobMoney + " hesabınıza yatırıldı.\n\n<color='#D9C89D'>Para: $" + _GameManager.Money + " > $" + (_GameManager.Money + JobMoney) + "\nYemek: %" + _GameManager.Food + " > %" + (_GameManager.Food - RandomFood) + "</color>"; }
                    else { JobMessageText.text = "<color='#3DB4C9'>Secretary: </color>" + JobName + " işi için $" + JobMoney + " hesabınıza yatırıldı.\n\n<color='#D9C89D'>Para: $" + _GameManager.Money + " > $" + (_GameManager.Money + JobMoney) + "\nYemek: %" + _GameManager.Food + " > %" + (_GameManager.Food - RandomFood) + "</color>"; }
                    
                    _GameManager.Food -= RandomFood;
                    _GameManager.AlertSound.Play();
                }
                else
                {
                    RandomFood = Random.Range(1, 25);
                    if (_GameManager.L) { JobMessageText.text = "<color='#3DB4C9'>Sekreter: </color>" + JobName + " işi için $" + JobMoney + " hesabınıza yatırıldı.\n\n<color='#D9C89D'>Para: $" + _GameManager.Money + " > $" + (_GameManager.Money + JobMoney) + "\nYemek: %" + _GameManager.Food + " > %" + (_GameManager.Food - RandomFood) + "</color>"; }
                    else { JobMessageText.text = "<color='#3DB4C9'>Secretary: </color>You were paid $" + JobMoney + " for " + JobName + " work.\n\n<color='#D9C89D'>Money: $" + _GameManager.Money + " > $" + (_GameManager.Money + JobMoney) + "\nFood: %" + _GameManager.Food + " > %" + (_GameManager.Food - RandomFood) + "</color>"; }
                    
                    _GameManager.Food -= RandomFood;
                    _GameManager.AlertSound.Play();
                }

                _GameManager.Money += JobMoney;
                _GameManager.UpdateUI();
            }
            else
            {
                if (_GameManager.Food >= 35)
                {
                    RandomFood = Random.Range(5, 35);
                    if (_GameManager.L) { JobMessageText.text = "<color='#3DB4C9'>Sekreter: </color>İşi tamamlayamadın, <color='#C1AF80'>" + Mathf.Abs((10 - Point)) + " tane</color> daha bilmen gerekiyordu.\n\n<color='#D9C89D'>Mutluluk %" + _GameManager.Happiness + " > %" + (_GameManager.Happiness - 10) + "\nYemek: %" + _GameManager.Food + " > %" + (_GameManager.Food - RandomFood) + "</color>"; _GameManager.Food -= RandomFood; }
                    else { JobMessageText.text = "<color='#3DB4C9'>Secretary: </color>You couldn't get the work done, you should have known <color='#C1AF80'>" + Mathf.Abs((10 - Point)) + " more.</color>\n\n<color='#D9C89D'>Happiness %" + _GameManager.Happiness + " > %" + (_GameManager.Happiness - 10) + "\nFood: %" + _GameManager.Food + " > %" + (_GameManager.Food - RandomFood) + "</color>"; _GameManager.Food -= RandomFood; }
                    
                    _GameManager.AlertSound.Play();
                }
                else
                {
                    RandomFood = Random.Range(1, 25);
                    if (_GameManager.L) { JobMessageText.text = "<color='#3DB4C9'>Sekreter: </color>İşi tamamlayamadın, <color='#C1AF80'>" + Mathf.Abs((10 - Point)) + " tane</color> daha bilmen gerekiyordu.\n\n<color='#D9C89D'>Mutluluk %" + _GameManager.Happiness + " > %" + (_GameManager.Happiness - 10) + "\nYemek: %" + _GameManager.Food + " > %" + (_GameManager.Food - RandomFood) + "</color>"; }
                    else { JobMessageText.text = "<color='#3DB4C9'>Secretary: </color>You couldn't get the work done, you should have known <color='#C1AF80'>" + Mathf.Abs((10 - Point)) + " more.</color>\n\n<color='#D9C89D'>Happiness %" + _GameManager.Happiness + " > %" + (_GameManager.Happiness - 10) + "\nFood: %" + _GameManager.Food + " > %" + (_GameManager.Food - RandomFood) + "</color>"; }
                    
                    _GameManager.Food -= RandomFood;
                    _GameManager.AlertSound.Play();
                }
            }
            
            this.enabled = false;
        }
    }
}
