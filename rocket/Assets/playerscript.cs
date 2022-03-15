using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerscript : MonoBehaviour
{
    Rigidbody rocketRB;
    private AudioSource rocketAudioSource;
    AudioSource rocketAudiosource;
    int loadingTime = 1;
    bool isControlEnabled = true;

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
        if (isControlEnabled)
        {
            Thrust();
            Rotate();

        }
        
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
                
                break;
            case "Finish":
                Invoke("LoadNextScene", loadingTime);
                isControlEnabled = false;

                
                break;
            default:
                Invoke("LoadFirstLevel", loadingTime);
                isControlEnabled = false;
               
                break;
        }


    }
        void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }




    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
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


