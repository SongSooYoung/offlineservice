using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BackGround : MonoBehaviour
{
    GameObject background;
    Material mat;
    Vector3 dir;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.Find("BackGround");
        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
        mat = renderer.material;
        dir.x = 90;
    }

    // Update is called once per frame
    void Update()
    {
        mat.mainTextureOffset += Vector2.up * speed * Time.deltaTime;
        dir.y += 0.4f;
        background.transform.eulerAngles = dir;
    }
}
