using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int total;
    public Animator anim;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    if(total <= 0)
        {
            anim.SetBool("Dead", true);
        }
	}

    public void DecreaseHealth(int attack)
    {
        total = total - attack;
    }

    public void IncreaseHealth(int regen)
    {
        total = total + regen;
    }
}
