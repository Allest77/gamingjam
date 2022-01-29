using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundWhenJump : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //Play the jump sound when player hits Jump.
        if (Input.GetButtonDown("Jump") /* && Bool for player's ability to jump is true */)
        {
            FindObjectOfType<AudioManager>().Play("Jump");
        }
    }
}
