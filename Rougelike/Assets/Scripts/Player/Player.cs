using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    public float speed;
    Vector3 moveVec;
    float hAxis;
    float vAxis;
    GameObject Exp;

    CharacterController cc;

    // Start is called before the first frame update
    void Awake()
    {
        cc = GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        cc.Move(moveVec * speed * Time.deltaTime);

        transform.LookAt(transform.position + moveVec);
    }


    void OnTriggerEnter(Collider other)
    {
        ExpManager.instance.EXP++;
        if (other.tag == "Exp")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print(hit.gameObject.name + hit.gameObject.transform.position);
        if (hit.gameObject.name.Contains("EXP"))
        {
            Debug.LogError("!!!");
        }
        
    }
}
