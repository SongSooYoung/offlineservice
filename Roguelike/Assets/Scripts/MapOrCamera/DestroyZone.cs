using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //ºÎµúÈù »ó´ë¸¦ ÆÄ±«ÇÏ°Ú´Ù
        Destroy(other.gameObject);
    }
}
