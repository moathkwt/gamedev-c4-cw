using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    Rigidbody rocketRB;
    private AudioSource rocketAudioSource;
    AudioSource rocketAudiosource;

    [SerializeField] AudioClip mainEngine;


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
            rocketRB.AddRelativeForce(Vector3.up * 15);
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
    void Rotate()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward / 2);
        }
        else
            if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward / 2);
        }
        
    }
}


