using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colletable : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            score.instance.changescore(1);
            Destroy(gameObject);
        }
    }
}
