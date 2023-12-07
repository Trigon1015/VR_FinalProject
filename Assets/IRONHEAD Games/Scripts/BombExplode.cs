using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void IsShot()
    {
       
        
        //var shatterAnimation = shatteredObject.GetComponent<Animation>().Play();

        //Vibrate Controller
        VibrationManager.instance.VibrateController(1f, 1, 1f, OVRInput.Controller.RTouch);

        //Add score
        ScoreManager.instance.AddScore(ScorePoints.BOMB_SCOREPOINT * -1);
        Destroy(gameObject);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            IsShot();
        }
    }
}
