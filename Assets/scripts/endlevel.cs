using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class endlevel : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        //when the player gets to the end goal goes to the next level
        if(other.gameObject.name == "Player")
        {
            GameManager.Instance.loadNextScene();
        }
    }
}
