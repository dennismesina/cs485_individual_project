using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyboardControls : MonoBehaviour {
    public Text countText;
    public Text youLose;
    private int count;
    float rotatespeed = 100;
    private float currentspeed;
    public float maxspeed, attackRate;
    public CharacterController controller;
    public Animator anim;
    private Vector3 position, zombieposition;
    private GameObject zombie;
    private float startingAttackRate = 1.25f;
    Health health;
    public bool playerattack, pressed;

    // Use this for initialization
    void Start () {
        attackRate = startingAttackRate;
        bool pressed = false;
        youLose.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(-Vector3.up * rotatespeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * rotatespeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space) && !pressed)
        {
            pressed = true;
            playerattack = true;
            anim.SetBool("Attack", true);
        }
        else
        {
            playerattack = false;
            anim.SetBool("Attack", false);
            attackRate -= Time.deltaTime;
            if(attackRate < 0)
            {
                pressed = false;
                attackRate = startingAttackRate;
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            currentspeed = maxspeed;
            position = transform.forward * currentspeed;
            anim.SetFloat("Speed", maxspeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentspeed = maxspeed;
            position = -transform.forward * currentspeed;
            anim.SetFloat("Speed", -2);
        }
        else
        {
            currentspeed = 0f;
            anim.SetFloat("Speed", currentspeed);
        }
        SetCountText();
    }
    void SetCountText()
    {
        Health myHealth = gameObject.GetComponent<Health>();
        count = myHealth.total;
        countText.text = "Health: " + count.ToString();
        if(count <= 0)
        {
            youLose.text = "GAME OVER, You lose";
        }
    }
}
