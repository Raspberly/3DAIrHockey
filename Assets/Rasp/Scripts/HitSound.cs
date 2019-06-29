using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip clip;
    public AudioSource source;

    public void OnCollisionEnter (Collision collision)
    {
        //これはひどい
        //if(collision.gameObject.name == "Ball")
        //{
            source.PlayOneShot(clip);
        //}
    }
}
