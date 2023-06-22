using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroMovement : MonoBehaviour
{
    /*[SerializeField] KeyCode keyOne;
    [SerializeField] KeyCode keyTwo;
    [SerializeField] Vector3 moveDirection;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(keyOne))
        {
            GetComponent<Rigidbody>().velocity += moveDirection;
        }
        if (Input.GetKey(keyTwo))
        {
            GetComponent<Rigidbody>().velocity -= moveDirection;
        }
        //animator.SetFloat("Speed", GetComponent<Rigidbody>().magnitude);

        //if (Input.GetKey(KeyCode.R))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }*/


    //public TMPro.TMP_Text timeText;

    [Header("Time counter")] // оглавление
    private float timeValue = 0f;
    public float TimeValue
    {
        get { return timeValue; }
        private set
        {
            timeValue = value;
        }
    }




    //public TMPro.TMP_Text timeText;

    [Header("Movement")] // оглавление
    public float moveSpeed;
    public Transform orientations;
    float horizontalInput;
    //float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;
    private Animator animator;

    //Важно было
    //private bool isPass = false;
    //public bool IsPass
    //{
    //    get { return isPass; }
    //    set { isPass = value; }
    //}

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeValue += Time.deltaTime;
        MyInput();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        //verticalInput = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        //moveDirection = orientations.forward * verticalInput + orientations.right * horizontalInput;
        moveDirection = orientations.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 1f, ForceMode.Force);
        animator.SetFloat("Speed", moveDirection.magnitude);
    }

    //Передаём время на сохраниение
    public void SendToSecondClass_1()
    {
        float totalTime = PlayerPrefs.GetFloat("TimeTEMP");
        PlayerPrefs.SetFloat("TimeTEMP", totalTime + TimeValue);
        Debug.Log("Получилось" + TimeValue);

        /*IsPass = true;
        //TimeCounter tc = new TimeCounter();

        //GameObject tc = GameObject.Find("TimeVal").GetComponent<TimeCounter>();
        //TimeCounter tc = tc.GetComponent<TimeCounter>();
        //PlayerBehavior playerBehavior = player.GetComponent<PlayerBehavior>();
        //tc.SaveTime(IsPass); // вызываем метод TimeTravel() второго класса и передаём ему наше число*/
    }

    //public void TimeTravel(float number)
    //{
    //    //Console.WriteLine("Мы передали число " + number + " в другое время!"); // просто выводим сообщение
    //    if (number > 0)
    //    {
    //        Debug.Log("Получилось");
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    }
    //    else
    //    {
    //        Debug.Log("Не получилось");
    //    }
    //    //Debug.Log("Получилось" + number);
    //    //TimeCounter tc = new TimeCounter();
    //    //tc.EnterCondition(IsPass);
    //    //LBSend(number);
    //    //AllIsGood(number);
    //}

    //public void AllIsGood(float number)
    //{
    //    if (number > 0)
    //    {
    //        Debug.Log("Получилось");
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    }
    //    else
    //    {
    //        Debug.Log("Не получилось");
    //    }
    //}


    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            SendToSecondClass_1();
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
