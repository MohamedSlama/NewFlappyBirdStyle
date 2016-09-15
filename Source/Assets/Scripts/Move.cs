using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour {

    Rigidbody2D rg;
    Animator anim;
    
    bool dead =false;

    public string sceneName;
    public float JumpSpeedY;
    public float forwardSpeed;
    public float TimeOfLevel;
    public float coinnyDiamond;
    float Temp,coinTemp;

    Transform firePos;
    public GameObject Bullet;

    


    AudioSource jump,coin,bullet,diamond;

    AudioSource[] Audios;

	// Use this for initialization
	void Start () {

        
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
        firePos = transform.FindChild("FirePos");

        Audios = GetComponents<AudioSource>();
        coin = Audios[0];
        jump = Audios[1];
        bullet = Audios[2];
        diamond = Audios[3];


        Temp = TimeOfLevel;
        coinTemp = coinnyDiamond;
	}

	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !dead)
        {
            if (getClick() && !paused)
            {
                    Fire();
            }
            if(!getClick() && !paused)
                Jump();
            if(!Save)
                anim.SetInteger("state", 1);
        }
        else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && dead)
        {
            SceneManager.LoadScene(sceneName);
        }
            
	}

    
    void FixedUpdate()
    {
        if (dead)
        {
            anim.SetInteger("state", 2);
            return;
        }

        rg.AddForce(Vector2.right * forwardSpeed);

        coinTemp -= Time.deltaTime;
        if (Temp <= 0)
        {
            Temp =TimeOfLevel;
            forwardSpeed += .2f;
        }

        if (Save)
        {
            Temp -= Time.deltaTime;
        }
        if (coinTemp <= 0)
        {
            coinTemp = coinnyDiamond;
            Save = false;
            anim.SetInteger("state", 1);
        }
    }

    bool Save;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (Save)
            dead = false;
        else
            dead = true;
    }

    public void Jump()
    {
        rg.AddForce(new Vector2(rg.velocity.x, JumpSpeedY));
        jump.Play();
    }

    public void Fire()
    {
        Instantiate(Bullet, firePos.position, Quaternion.identity);
        bullet.Play();
    }

    bool click;
    public static bool paused;

    public void setClick(bool click)
    {
        this.click = click;
    }
    private bool getClick()
    {
        return this.click;
    }


    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "coin")
        {
            Destroy(collider.gameObject);
            Score.AddPoint();
            coin.Play();
        }
        else if (collider.gameObject.tag == "Coinny")
        {
            Destroy(collider.gameObject);
            Save = true;
            diamond.Play();
            anim.SetInteger("state", 3);
        }
    }
}
