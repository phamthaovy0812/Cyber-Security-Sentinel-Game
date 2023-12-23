using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBPipeIncreaseScore : MonoBehaviour
{
    private Rigidbody2D _rb;
    public void Start(){
        _rb = GetComponent<Rigidbody2D>();
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            FBScore.instance.UpdateScore();
        }
    }
}
