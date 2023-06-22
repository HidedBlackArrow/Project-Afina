using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardScript : MonoBehaviour
{
    private float totalTime;
    public float TotalTime
    {
        get { return totalTime; }
        set { totalTime = value; }
    }

    private string nameFinal;
    public string NameFinal
    {
        get { return nameFinal; }
        set { nameFinal = value; }
    }

    public TMPro.TMP_Text TimeTextBox; 
    public TMPro.TMP_Text NameTextBox;

    // Cравнение времени
    //private float timeElement = 0f;
    //public float TimeElement
    //{
    //    get { return timeElement; }
    //    set { timeElement = value; }
    //}

    //public List<float> TimeList = new List<float>();



    /*void TimeTrevel(float t)
    {
        //TimeCounter timeCounter = new TimeCounter();
        //timeCounter.TimeSendlerHandler = ListAdder();
        //timeCounter.OnTriggerEnter();
        Debug.Log(TimeList);
        TimeList.Add(t);
        Debug.Log(TimeList);
    }*/

    //public void 

    //public void TimeTravel(float number)
    //{
    //    //Console.WriteLine("Мы передали число " + number + " в другое время!"); // просто выводим сообщение
    //    Debug.Log("Получилось" + number);
    //}

    // Start is called before the first frame update
    public void Start()
    {
        TimeBattle();
    }

    public void UpdateBoard()
    {
        NameTextBox.text = PlayerPrefs.GetString("PlayerTag1") + "\n" + PlayerPrefs.GetString("PlayerTag2") +
                "\n" + PlayerPrefs.GetString("PlayerTag3") + "\n" + PlayerPrefs.GetString("PlayerTag4") +
                "\n" + PlayerPrefs.GetString("PlayerTag5") + "\n" + NameFinal.ToString();

        TimeTextBox.text = PlayerPrefs.GetFloat("PlayerTime1") + "\n" + PlayerPrefs.GetFloat("PlayerTime2") +
            "\n" + PlayerPrefs.GetFloat("PlayerTime3") + "\n" + PlayerPrefs.GetFloat("PlayerTime4") +
            "\n" + PlayerPrefs.GetFloat("PlayerTime5") + "\n" + TotalTime.ToString();
    }

    public void TimeBattle()  //Проверка времени   //float
    {
        TotalTime = PlayerPrefs.GetFloat("TimeTEMP");

        float PlayerTime5 = PlayerPrefs.GetFloat("PlayerTime5");
        string PlayerTag5 = PlayerPrefs.GetString("PlayerTag5");

        float PlayerTime4 = PlayerPrefs.GetFloat("PlayerTime4");
        string PlayerTag4 = PlayerPrefs.GetString("PlayerTag4");

        float PlayerTime3 = PlayerPrefs.GetFloat("PlayerTime3");
        string PlayerTag3 = PlayerPrefs.GetString("PlayerTag3");

        float PlayerTime2 = PlayerPrefs.GetFloat("PlayerTime2");
        string PlayerTag2 = PlayerPrefs.GetString("PlayerTag2");

        float PlayerTime1 = PlayerPrefs.GetFloat("PlayerTime1");
        string PlayerTag1 = PlayerPrefs.GetString("PlayerTag1");


        if (TotalTime < PlayerPrefs.GetFloat("PlayerTime1")) //>=
        {
            PlayerPrefs.SetFloat("PlayerTime5", PlayerTime4);
            PlayerPrefs.SetString("PlayerTag5", PlayerTag4);

            PlayerPrefs.SetFloat("PlayerTime4", PlayerTime3);
            PlayerPrefs.SetString("PlayerTag4", PlayerTag3);

            PlayerPrefs.SetFloat("PlayerTime3", PlayerTime2);
            PlayerPrefs.SetString("PlayerTag3", PlayerTag2);

            PlayerPrefs.SetFloat("PlayerTime2", PlayerTime1);
            PlayerPrefs.SetString("PlayerTag2", PlayerTag1);

            PlayerPrefs.SetFloat("PlayerTime1", TotalTime);
            PlayerPrefs.SetString("PlayerTag1", NameFinal);

        }

        else if (TotalTime < PlayerPrefs.GetFloat("PlayerTime2")) //>=
        {
            PlayerPrefs.SetFloat("PlayerTime5", PlayerTime4);
            PlayerPrefs.SetString("PlayerTag5", PlayerTag4);

            PlayerPrefs.SetFloat("PlayerTime4", PlayerTime3);
            PlayerPrefs.SetString("PlayerTag4", PlayerTag3);

            PlayerPrefs.SetFloat("PlayerTime3", PlayerTime2);
            PlayerPrefs.SetString("PlayerTag3", PlayerTag2);

            PlayerPrefs.SetFloat("PlayerTime2", TotalTime);
            PlayerPrefs.SetString("PlayerTag2", NameFinal);
        }

        else if (TotalTime < PlayerPrefs.GetFloat("PlayerTime3")) //>=
        {
            PlayerPrefs.SetFloat("PlayerTime5", PlayerTime4);
            PlayerPrefs.SetString("PlayerTag5", PlayerTag4);

            PlayerPrefs.SetFloat("PlayerTime4", PlayerTime3);
            PlayerPrefs.SetString("PlayerTag4", PlayerTag3);

            PlayerPrefs.SetFloat("PlayerTime3", TotalTime);
            PlayerPrefs.SetString("PlayerTag3", NameFinal);
        }

        else if (TotalTime < PlayerPrefs.GetFloat("PlayerTime4")) //>=
        {
            PlayerPrefs.SetFloat("PlayerTime5", PlayerTime4);
            PlayerPrefs.SetString("PlayerTag5", PlayerTag4);

            PlayerPrefs.SetFloat("PlayerTime4", TotalTime);
            PlayerPrefs.SetString("PlayerTag4", NameFinal);
        }

        else if (TotalTime < PlayerPrefs.GetFloat("PlayerTime5")) //>=
        {
            PlayerPrefs.SetFloat("PlayerTime5", TotalTime);
            PlayerPrefs.SetString("PlayerTag5", NameFinal);
        }

        //        if (TotalTime > PlayerPrefs.SetFloat("PlayerTime1"))
        //PlayerPrefs.SetFloat("TimeTEMP", totalTime + TimeValue);
        Debug.Log("Получился лидерборд");

        //return TotalTime;
    }

    public void NameGetter() // string
    {
        NameFinal = PlayerPrefs.GetString("PlayerTagTMP");
        //PlayerPrefs.SetFloat("TimeTEMP", totalTime + TimeValue);
        //Debug.Log("Получился лидерборд");
        //return NameFinal;
    }

    public void StartLeaderBoard()  //Очистка
    {
        PlayerPrefs.SetFloat("PlayerTime1", 50000);
        PlayerPrefs.SetFloat("PlayerTime2", 50000);
        PlayerPrefs.SetFloat("PlayerTime3", 50000);
        PlayerPrefs.SetFloat("PlayerTime4", 50000);
        PlayerPrefs.SetFloat("PlayerTime5", 50000);
        PlayerPrefs.SetFloat("TimeTEMP", 50000);

        PlayerPrefs.SetString("PlayerTag1", "Unknown");
        PlayerPrefs.SetString("PlayerTag2", "Unknown");
        PlayerPrefs.SetString("PlayerTag3", "Unknown");
        PlayerPrefs.SetString("PlayerTag4", "Unknown");
        PlayerPrefs.SetString("PlayerTag5", "Unknown");
        PlayerPrefs.SetString("PlayerTagTMP", "Unknown");
    }

    //void string DisplayTime(float timeToDisplay)
    //{
    //    if (timeToDisplay > 60)
    //    {
    //        timeToDisplay += 1;
    //    }

    //    float minutes = Mathf.FloorToInt(timeToDisplay / 60);
    //    float seconds = Mathf.FloorToInt(timeToDisplay % 60);

    //    timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    //}

    // Update is called once per frame
    void Update()
    {
        NameGetter();
        
        UpdateBoard();
        //timeValue += 1;
    }

    //void ListAdder(float t)
    //{
    //    TimeList.Add(t);
    //}
}
