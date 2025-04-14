using UnityEngine;
using Cinemachine;

public class zoom_effect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Transform player;
    private GameObject[] enemies;
    private Camera Cam;
    private CinemachineImpulseSource impulseSource;
    public UnityEngine.UI.Image screenTint;

    private const float MIN_ANG_VEL_DEG = 10.0f;
    private const float MAX_ANG_VEL_DEG = 1000.0f;
    private float _alpha = 0.0f;
    private const float INV_PERIOD_SECONDS = 1.0f;

    public float limit = 3f;
    
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        player = GameObject.FindWithTag("Player").transform;
        Cam = Camera.main;
        impulseSource = player.GetComponent<CinemachineImpulseSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        
        _alpha += Time.fixedDeltaTime * INV_PERIOD_SECONDS;
        if (_alpha > 1.0f) {
        _alpha -= 1.0f;
         }
        float interpAngVelDeg = (1.0f - _alpha) * MIN_ANG_VEL_DEG + _alpha * MAX_ANG_VEL_DEG;
        bool Jitter = false;

        foreach (GameObject enemy in enemies){

            Vector3 toEnemy = enemy.transform.position - player.position;
            Vector3 playerFacing = player.rotation * Vector3.forward;

            float distance = toEnemy.magnitude;
            float dot = Vector3.Dot(playerFacing, toEnemy);
            //Debug.Log($"Enemy Distance: {distance}, Dot: {dot}");
            if (dot > 0.0f && distance < limit){ //first half checks a "cone" in front of the player (kind of like fov), second half checks player location 
                Jitter = true;
                //Debug.Log($"Enemy is within the limit: Distance = {distance}, Dot = {dot}");
                break;
            }
        }
        if (Jitter){ //if the camera should be shaking 
            //Debug.Log("Jitter is active!");


            //Cam.fieldOfView = interpAngVelDeg + Random.Range(-20f, 20f); 
            //Cam.fieldOfView = Mathf.Clamp(interpAngVelDeg + Random.Range(-3f, 3f), normalFOV, 100f);
            
            //float jitterAmount = Random.Range(-10.0f, 10.0f) * (interpAngVelDeg / 100f); 
            //Cam.fieldOfView = normalFOV + jitterAmount;

            //float shakeStrength = interpAngVelDeg / 500f; // Scale the shake dynamically
            //Vector3 shakeOffset = Random.insideUnitSphere * shakeStrength;

            //Cam.transform.localPosition = shakeOffset;

            float pulse = Mathf.Sin(_alpha * Mathf.PI); 

        
            Color c = screenTint.color;
            c.a = pulse / 2; 
            screenTint.color = c;

            float shakeStrength = interpAngVelDeg / 3750f; // scale the shake 
            if (impulseSource != null)
            {
                Vector3 shakeOffset = Random.insideUnitSphere * shakeStrength;

                
                shakeOffset.y = 0f; //make sure camera does not go down

                impulseSource.GenerateImpulse(shakeOffset); 
            }
            else
            {
                Debug.LogWarning("impulseSource is null, unable to generate impulse!");
            }
            //Debug.Log($"Camera Position: {Cam.transform.localPosition}");
        }
        else{
            
            Cam.transform.localPosition = Vector3.zero;

            Color c = screenTint.color;
            c.a = 0f;
            screenTint.color = c;

            //if (Cam.fieldOfView > normalFOV)
            //{
            //    Cam.fieldOfView -= zoomSpeed * Time.fixedDeltaTime;
            //}
            //else if (Cam.fieldOfView < normalFOV)
            //{
            //    Cam.fieldOfView += zoomSpeed * Time.fixedDeltaTime;
            //}
        }
    }
}
