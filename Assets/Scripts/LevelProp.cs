using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProp : MonoBehaviour
{
    public bool soundActive = false;
    private float timeToActivate = 1f;

    public void ChangeSoundActive()
    {
        soundActive = !soundActive;
    }

    public void ChangeSoundActive(bool active)
    {
        soundActive = active;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (soundActive && !GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<ParticleSystem>().Play();
        }
    }

    private void Update()
    {
        if (soundActive == false)
        {
            timeToActivate -= Time.deltaTime;
            if (timeToActivate <= 0)
            {
                ChangeSoundActive(true);
            }
        }
    }
}
