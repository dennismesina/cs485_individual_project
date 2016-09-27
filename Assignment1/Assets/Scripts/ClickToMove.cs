using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

    public float max;
    public float currentspeed;
    public CharacterController controller;
    private Vector3 position;

    public Animator anim;

    // Use this for initialization
    void Start() {
        position = transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(0))
        {
            locatePosition();
        }

        moveToPosition();
    }

    void locatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 1000))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }
    }

    void moveToPosition()
    {
        if (Vector3.Distance(transform.position, position) > 1)
        {
            currentspeed = max;
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position);

            newRotation.x = 0f;
            newRotation.z = 0f;

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
            controller.SimpleMove(transform.forward * currentspeed);
            anim.SetFloat("Speed", currentspeed);
            
        }
        else
        {
            currentspeed = 0f;
            anim.SetFloat("Speed", currentspeed);
        }
    }
}
