using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    Rigidbody rocketRB;
    private AudioSource rocketAudioSource;
    AudioSource rocketAudiosource;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] float rotateSpeed = 5f;
    [SerializeField] float thrustSpeed = 5f;



    // Start is called before the first frame update
    void Start()
    {
        rocketRB = GetComponent<Rigidbody>();
        rocketAudioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rocketRB.AddRelativeForce(Vector3.up * thrustSpeed );
            if (!rocketAudioSource.isPlaying)
            {
                rocketAudioSource.PlayOneShot(mainEngine);
            }
        }
        else
        {
            rocketAudioSource.Stop();
        }

        
    

    }
     void OnCollisionEnter(Collision collision)
    {
        print (collision.gameObject.tag);
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("No problem");
                break;
            case "Finish":
                print("You win!");
                break;
            default:
                print("you lose !!!");
                break;
        }


    }
    void Rotate()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotateSpeed);
        }
        else
            if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotateSpeed);
        }
        
    }
}


