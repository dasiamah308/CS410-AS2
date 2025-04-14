using UnityEngine;

public class firetrigger : MonoBehaviour
{

    public ParticleSystem[] particleEffects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (ParticleSystem ps in particleEffects)
            {
                if (ps != null && !ps.isPlaying)
                {
                    ps.Play();
                }
            }

        }
    }
}
