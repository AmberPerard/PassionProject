using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionFood : MonoBehaviour
{
    private AudioSource crunchSound;

    Animator anim;
    int eatHash = Animator.StringToHash("IsEatingFood");

    void Start()
    {

        crunchSound = GetComponent<AudioSource>();
        anim = gameObject.GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("There is collision");

        if (other.gameObject.tag == "Food")
        {


            anim.SetTrigger(eatHash);

            crunchSound.Play();

            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
