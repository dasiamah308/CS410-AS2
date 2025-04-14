using UnityEngine;

public class soundtrigger : MonoBehaviour
{
    private AudioSource soundFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player entered the trigger zone!");
            if (!soundFX.isPlaying)
            {
                soundFX.Play();
            }
        }
    }
}
