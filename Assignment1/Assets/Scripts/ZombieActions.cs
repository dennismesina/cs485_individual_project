using UnityEngine;
using System.Collections;

public class ZombieActions : MonoBehaviour
{
    public float speed, maxspeed, idlespeed, attackRate;
    private Vector3 moveDirection;
    public Animator anim;
    public bool Aggro, Dead;
    public Vector3 playerposition;
    private float deadBodyTime = 3;
    public float startingAttackRate = 0.3f;
    private GameObject player;
    Health health;
    KeyboardControls controls;
    // Use this for initialization
    void Start()
    {
        Aggro = false;
        attackRate = startingAttackRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Dead)
        {
            speed = 0;
            Aggro = false;
            deadBodyTime -= Time.deltaTime;
            if (deadBodyTime < 0)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerposition = player.transform.position;
            health = player.GetComponent<Health>();
            controls = player.GetComponent<KeyboardControls>();
            Health myHealth = gameObject.GetComponent<Health>();
            if (Vector3.Distance(transform.position, playerposition) < 4)
            {
                if(controls.playerattack == true)
                {
                    myHealth.DecreaseHealth(1);
                    if (myHealth.total <= 0)
                    {
                        Dead = true;
                    }
                }
            }
            
            if (Vector3.Distance(transform.position, playerposition) < 10)
            {
                Aggro = true;
            }
            else
            {
                Aggro = false;
            }
            if (Aggro)
            {
                if (Vector3.Distance(transform.position, playerposition) > 3)
                {
                    anim.SetBool("Attack", false);
                    anim.SetBool("Aggro", true);
                    speed = maxspeed;
                    Quaternion newRotation = Quaternion.LookRotation(playerposition - transform.position);

                    newRotation.x = 0f;
                    newRotation.z = 0f;

                    transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
                    transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
                }
                else
                {
                    Quaternion newRotation = Quaternion.LookRotation(transform.position - playerposition);
                    newRotation.x = 0f;
                    newRotation.z = 0f;
                    player.transform.rotation = Quaternion.Slerp(player.transform.rotation, newRotation, Time.deltaTime * 10);
                    anim.SetBool("Attack", true);
                    controls.anim.SetBool("TakingDamage", true);
                    attackRate -= Time.deltaTime;
                    if (attackRate < 0)
                    {
                        health.DecreaseHealth(1);
                        attackRate = startingAttackRate;
                    }
                }
            }
            else
            {
                speed = idlespeed;
                controls.anim.SetBool("TakingDamage", false);
                anim.SetBool("Aggro", false);
                anim.SetBool("Attack", false);
                transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
            }
        }
    }
}