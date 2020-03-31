using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PlayerController : MonoBehaviour
{
    public Vector2 speed;
    public float touchMoveSpeed;
    public bool spotLightEnabled;
    public int health;
    private float startTime;
    private float journeyLength;
    public GameObject mainCamera;
    public GameObject mapCamera;
    public GameObject mapOffButton;
    public GameObject animationController;
    public GameObject deadSprite;
    public int totalMoney;
    public GameObject youDied;
    public GameObject youWon;
    public GameObject youRanOutOfLives;
    public float panSpeed;
    public bool touchControlsEnabled;
    private bool isInvincible;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 touchDeltaPosition;
    private Animator animator;
    private bool controlsEnabled;
    private int lives;
    public int escaped;
    public int onFire;
    public float win_delay;
    public virtual void Start()
    {
        this.touchDeltaPosition = this.transform.position;
        int initialLoad = PlayerPrefs.GetInt("initialLoad");
        if (initialLoad == 0)
        {
            //Flag the first time the player loads the game.
            PlayerPrefs.SetInt("initialLoad", 1);
        }
        this.lives = PlayerPrefs.GetInt("lives");
        this.animator = this.animationController.GetComponent<Animator>();
        this.rb = this.GetComponent<Rigidbody2D>();
        this.totalMoney = 0;
        this.startTime = Time.time;
        this.showMap();
    }

    public virtual void Update()
    {
        if (this.controlsEnabled && !this.isInvincible)
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");
            
            if (this.touchControlsEnabled)
            {
                //do nothing
            }
            else
            {
                //end touch controlls -------------------------------
                //keyboard controlls-------------------------------------
                if (inputX > 0)
                {
                    this.animator.SetInteger("Direction", 0);
                }
                else
                {
                    if (inputX < 0)
                    {
                        this.animator.SetInteger("Direction", 1);
                    }
                }
                this.movement = new Vector2(this.speed.x * inputX, this.speed.y * inputY);
            }
        }
    }

    public virtual void TakeDamage(int amount)
    {
        if (!this.isInvincible)
        {
            if ((this.health - amount) < 0)
            {
                this.YouLose();
            }
            else
            {
                this.health = this.health - amount;
            }
        }
    }

    public virtual void GainMoney(int amount, GameObject coin)
    {
        this.totalMoney = this.totalMoney + 1;
        coin.SetActive(false);
        Debug.Log("your total gold collected is = " + this.totalMoney);
    }

    public virtual void YouWin()
    {
        Debug.Log("YOU WON!");
        this.isInvincible = true;
        int currentMoney = PlayerPrefs.GetInt("gold");
        PlayerPrefs.SetInt("gold", this.totalMoney + currentMoney);
        PlayerPrefs.SetInt("lastLevelLoaded", 0);
        PlayerPrefs.Save();
        int lastLevelLoaded = PlayerPrefs.GetInt("lastLevelLoaded");
        Debug.Log("lastLevelLoaded was = " + lastLevelLoaded);
        this.youWon.SetActive(true);
        this.controlsEnabled = false;
    }

    public virtual void YouLose()
    {
        this.deadSprite.SetActive(true);
        this.animationController.SetActive(false);
        this.controlsEnabled = false;
        this.isInvincible = true;
        this.lives = this.lives - 1;
        Debug.Log("Lives = " + this.lives);
        if (this.lives <= 0)
        {
            //the player is out of lives and needs to wait 24 hours or watch an ad!
            this.youRanOutOfLives.SetActive(true);
            PlayerPrefs.SetInt("lives", this.lives);
            PlayerPrefs.SetString("lastLifeLostDate", System.DateTime.Now.ToString());
        }
        else
        {
            //show 'you died' menu so user can reset the level
            this.youDied.SetActive(true);
            PlayerPrefs.SetInt("lives", this.lives);
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "thornWall")
        {
            this.TakeDamage(200);
        }
        else
        {
            if (coll.gameObject.tag == "gold")
            {
                this.GainMoney(1, coll.gameObject);
            }
            else
            {
                if (coll.gameObject.tag == "nest")
                {
                    this.YouWin();
                }
                else
                {
                    if (coll.gameObject.tag == "emptyNest")
                    {
                        //you shouldn't lose, you just should have to find the real one?
                        this.YouLose();
                    }
                }
            }
        }
    }

    public virtual void FixedUpdate()
    {
        this.win_delay = this.win_delay - Time.deltaTime;
        if (this.controlsEnabled && !this.isInvincible)
        {
            //touch controls  -------------------------------------
                if (this.touchControlsEnabled)
                {
                    if (Input.touchCount == 0)
                    // if (Input.GetMouseButtonDown(0))
                    {
                        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        this.GetComponent<Rigidbody2D>().angularVelocity = 0; 
                        Debug.Log("Pressed primary button.");
                        this.startTime = Time.time;
                        touchDeltaPosition = mainCamera.GetComponent<Camera>().ScreenToWorldPoint(Input.GetTouch(0).position);
                        // touchDeltaPosition = mainCamera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
                        float touchInputX = (touchDeltaPosition.x );
                        float touchInputY = (touchDeltaPosition.y );
                        Vector2 playerPos = this.transform.position;
                        var mouseDir = touchDeltaPosition - playerPos;
                        Debug.Log(mouseDir);
                        mouseDir = mouseDir.normalized;
                        Debug.Log(mouseDir + " Normalized");
                        if (touchInputX > 0)
                        {
                            this.animator.SetInteger("Direction", 0);
                        }
                        else
                        {
                            if (touchInputX < 0)
                            {
                                this.animator.SetInteger("Direction", 1);
                            }
                        }
                        this.GetComponent<Rigidbody2D>().AddForce(mouseDir*300, ForceMode2D.Force);
                        
                    }
                }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        
            if (this.onFire >= 1)
            {
                this.TakeDamage(1);
                //Debug.Log("You are on fire");
            }
            if (this.onFire <= 0)
            {
                //Debug.Log("Safe!");
            }
            if (this.escaped <= 0 && this.win_delay <= 0)
            {
                this.YouWin();
            }
        }
    }

    public virtual void showMap()
    {
        // turn off controlsEnabled
        this.controlsEnabled = false;
        // swap cameras
        this.mapCamera.SetActive(true);
        this.mainCamera.SetActive(false);
        // show the hide map button
        this.mapOffButton.SetActive(true);
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public virtual void hideMap()
    {
        Debug.Log("Click");
        this.GetComponent<Rigidbody2D>().gravityScale = 2;
        //swap map buttons
        this.mapOffButton.SetActive(false);
        //swap cameras
        this.mainCamera.SetActive(true);
        this.mapCamera.SetActive(false);
        //turn on controlls
        this.controlsEnabled = true;
    }

    public PlayerController()
    {
        this.speed = new Vector2(50, 50);
        this.health = 100;
        this.panSpeed = 3f;
        this.controlsEnabled = true;
        this.escaped = 0;
        this.win_delay = 1f;
    }

}