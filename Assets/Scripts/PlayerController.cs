using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float walkspeed;
    [SerializeField] private float movespeed;
    // [SerializeField] private float jumpHeight;
    [SerializeField] private bool isgrounded;
    [SerializeField] private float groundcheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    public GameObject Texttitle;
    public GameObject Texttitle2;
    public GameObject Texttitle3;
    public GameObject Texttitle4;

    protected Joystick joy;
    private Animator anim;
   


    private Vector3 moveforward;
    private Vector3 velocity;

    private CharacterController controller;

    public int TCoinCount = 0;
    public int GCoinCount = 0;
    public int GemCoinCount = 0;
    public float TimeLeft;
    public GameObject TCoinScore;
    [SerializeField] GameObject GCoinScore;
    public GameObject GemCoinScore;
    [SerializeField] GameObject TimeCountDown;
    
    [SerializeField] Button btn2;
    private bool takingaway;

   

    [SerializeField] GameObject Star1;
    [SerializeField] GameObject Star2;
    [SerializeField] GameObject Star3;
    [SerializeField] GameObject Star4;
    [SerializeField] GameObject Star5;




    //calling functions in the begining of the game
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        joy = FindObjectOfType<Joystick>();
        anim = GetComponentInChildren<Animator>();
        //btn.interactable = false;
        btn2.interactable = false;

        Star1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false);
        Star4.SetActive(false);
        Star5.SetActive(false);

        Texttitle.SetActive(false);
        Texttitle2.SetActive(false);
        Texttitle3.SetActive(false);
        Texttitle4.SetActive(false);
    }

    //calling functions in every frame of the game
    private void Update()
    {
        if (takingaway == false && TimeLeft > 0)
        {
            StartCoroutine(TimeTake());
        }

        
       

        Move();
    }




    //player's all movements
    private void Move()
    {
        isgrounded = Physics.CheckSphere(transform.position, groundcheckDistance, groundMask);

        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float movez = joy.Vertical;
        float movex = joy.Horizontal;
        moveforward = new Vector3(movex, 0, movez).normalized;

        if (moveforward != Vector3.zero)
        {
            Walk();
            transform.forward = moveforward;
            anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
        }

        else if (moveforward == Vector3.zero)
        {
            Idle();
            anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
        }

        /*
                if (isgrounded)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Jump();
                    }

                }*/

        controller.Move(moveforward * movespeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //walk function 
    private void Walk()
    {

        movespeed = walkspeed;
    }



    //idle function
    private void Idle()
    {
        movespeed = 0;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "TimeCoin")
        {
            // Destroy(coin);
            //tenpointcoinsound.Play();
            TCoinCount += 1;
            TimeLeft += 5;
            TCoinScore.GetComponent<Text>().text = TCoinCount + "/30";
            StartCoroutine(ShowTextForSeconds());
            //SetScore();

            if (TCoinCount == 10 || TCoinCount == 20 || TCoinCount == 30)
            {
                StartCoroutine(ShowInfo1());
            }
        }

        if (coll.gameObject.tag == "GemCoin")
        {
            // Destroy(coin);
            //tenpointcoinsound.Play();
            GemCoinCount += 1;
            GemCoinScore.GetComponent<Text>().text = GemCoinCount + "/2";
            StartCoroutine(ShowText2ForSeconds());
            if (GemCoinCount == 1 || GemCoinCount == 2)
            {
                StartCoroutine(ShowInfo1());
            }
            //SetScore();
        }

        if (coll.gameObject.tag == "GameCoin")
        {
            // Destroy(coin);
            //tenpointcoinsound.Play();
            StartCoroutine(ShowText3ForSeconds());
            GCoinCount += 1;
            
           GCoinScore.GetComponent<Text>().text = GCoinCount + "/5";
            //SetScore();

            if(GCoinCount == 1)
            {
                Star1.SetActive(true);
            }

            if (GCoinCount == 2)
            {
                Star2.SetActive(true);
            }

            if (GCoinCount == 3)
            {
                Star3.SetActive(true);
            }

            if (GCoinCount == 4)
            {
                Star4.SetActive(true);
            }

            if (GCoinCount == 5)
            {
                Star5.SetActive(true);
            }
        }
    }

    IEnumerator TimeTake()
    {
        takingaway = true;
        yield return new WaitForSeconds(1);
        TimeLeft -= 1;
        TimeCountDown.GetComponent<Text>().text = "00:" + TimeLeft;
        takingaway = false;
    }

    IEnumerator ShowTextForSeconds()
    {
        Texttitle.SetActive(true);
        yield return new WaitForSeconds(1);
        Texttitle.SetActive(false);


    }

    IEnumerator ShowText2ForSeconds()
    {
        Texttitle2.SetActive(true);
        yield return new WaitForSeconds(1);
        Texttitle2.SetActive(false);


    }

    IEnumerator ShowText3ForSeconds()
    {
        Texttitle3.SetActive(true);
        yield return new WaitForSeconds(1);
        Texttitle3.SetActive(false);


    }

    IEnumerator ShowInfo1()
    {
        Texttitle4.SetActive(true);
        yield return new WaitForSeconds(3);
        Texttitle4.SetActive(false);


    }




}