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

    CharacterController cc;
    //--------------------------------------- 움직임
    void Awake()
    {
        cc = GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update()
    {   //게임상태가 '게임 중' 상태일 때만 조작할 수 있게 한다.
        if(GameManager.instance.gState !=GameManager.GameState.Run)
        {
            return;
        }
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        cc.Move(moveVec * speed * Time.deltaTime);

        transform.LookAt(transform.position + moveVec);
    }
    //---------------------------------------EXP와 부딪힘
    void OnTriggerEnter(Collider other)     
    {
        if (other.tag == "Exp")
        {
            LevelManager.instance.EXP = LevelManager.instance.EXP + 1;
            Destroy(other.gameObject);
        }

    }
    //---------------------------------------


    // private void OnControllerColliderHit(ControllerColliderHit hit)
    //  {
    //print(hit.gameObject.name + hit.gameObject.transform.position);
    //if (hit.gameObject.name.Contains("EXP"))
    // {
    //    Debug.LogError("!!!");
    //  }

    // }
}
