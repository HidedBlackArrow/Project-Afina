using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    //public float timeValue = 0f;

    //public GameBehavior timeManager;
    //public delegate void TimeSendler(float t);
    //public TimeSendler TimeSendlerHandler { get; set; }
    //public static event TimeSendler Drop;

    private float timeValue = 0f;
    public float TimeValue
    {
        get { return timeValue; }
        private set
        {
            timeValue = value;
        }
    }

    public TMPro.TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = timeValue.ToString(/*"F1"*/);
    }

    // Update is called once per frame
    void Update()
    {
        //timeValue += Time.deltaTime;
        TimeValue += Time.deltaTime;

        //DisplayTime(timeValue);
        DisplayTime(TimeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay > 60)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (this.CompareTag("Player") && other.CompareTag("Finish"))
    //    {
    //        TimeCounter tc = new TimeCounter();
    //        tc.SendToSecondClass(TimeValue);

    //        //SendToSecondClass(TimeValue);
    //        //Drop(TimeValue);
    //        //TimeSendlerHandler(TimeValue);
    //        //gameObject.SendMessage("TimeTrevel", TimeValue);
    //    }
    //}

    //public void EnterCondition(bool pass)
    //{
    //    //Console.WriteLine("Мы передали число " + number + " в другое время!"); // просто выводим сообщение
    //    //Debug.Log("Получилось" + number);
        
    //    //SendToSecondClass_2(TimeValue);

    //}

    //public void SendToSecondClass_2(bool pass)
    //{
    //    if (pass)
    //    {
    //        //SendToSecondClass_2(TimeValue);
    //        //HeroMovement hr = new HeroMovement();
    //        GameObject hr = GameObject.Find("Player");
    //        HeroMovement hr = hr.GetComponent<HeroMovement>();
    //        hr.TimeTravel(TimeValue); // вызываем метод TimeTravel() второго класса и передаём ему наше число
    //    }
        
    //}

    ////////////////////////////////////////////////////////////////////////////////////////
    //Передаём время на сохраниение
    /*public void SaveTime(bool pass)
    {
        if (pass)
        {
            float totalTime = PlayerPrefs.GetFloat("TimeTEMP");
            PlayerPrefs.SetFloat("TimeTEMP", totalTime + TimeValue);
            Debug.Log("Получилось");
        }
    }*/


    //{1}
    //public float timeValue = 90f;
    //public float timeStart = 0;
    //public TMPro.TMP_Text textBox;

    // Start is called before the first frame update
    //void Start()
    //{
    //    textBox.text = textBox.ToString(/*"F1"*/);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    timeStart += Time.deltaTime;
    //    textBox.text = timeStart.ToString("F1");
    //}


    //{2}
    //void Update()
    //{
    //    if (timeValue > 0)
    //    {
    //        timeValue -= Time.deltaTime;
    //    }
    //    else 
    //    {
    //        timeValue += 90f;
    //    }

    //    DisplayTime(timeValue);
    //}



    //void DisplayTime(float timeToDisplay)
    //{
    //    if (timeToDisplay < 0)
    //    {
    //        timeToDisplay = 0;
    //    }
    //    //else if (timeToDisplay > 0)
    //    //{
    //    //    timeToDisplay += 1;
    //    //}

    //    float minutes = Mathf.FloorToInt(timeToDisplay / 60);
    //    float seconds = Mathf.FloorToInt(timeToDisplay % 60);

    //    timeText.text = string.Format("{0:00}:{1:00}",minutes, seconds);
    //}


}
