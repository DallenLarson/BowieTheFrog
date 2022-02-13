using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class Collectable : MonoBehaviour
{

    public float ShakeDuration = 0.3f;          // Time the Camera Shake effect will last
    public float ShakeAmplitude = 1.2f;         // Cinemachine Noise Profile Parameter
    public float ShakeFrequency = 2.0f;         // Cinemachine Noise Profile Parameter
    public ParticleSystem collectPart;
    public AudioSource eatSound;
    public ScoreSystem SS;
    public Renderer rend;

    private float ShakeElapsedTime = 0f;

    // Cinemachine Shake
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    // Use this for initialization
    void Start()
    {
        eatSound = GameObject.Find("Player").GetComponent<AudioSource>();
        SS = GameObject.Find("ScoreSysem").GetComponent<ScoreSystem>();
        VirtualCamera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        // Get Virtual Camera Noise Profile
        if (VirtualCamera != null)
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            SS.Score = SS.Score + 10;
            ShakeElapsedTime = ShakeDuration;
            eatSound.Play();
            collectPart.Play();
            rend.enabled = false;
            //Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0); //rotates 50 degrees per second around z axis

        if (ShakeElapsedTime > 0)
        {
            // Set Cinemachine Camera Noise parameters
            virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
            virtualCameraNoise.m_FrequencyGain = ShakeFrequency;

            // Update Shake Timer
            ShakeElapsedTime -= Time.deltaTime;
            StartCoroutine(Exam());
        }
    }
    IEnumerator Exam()
    {
        yield return new WaitForSeconds(0.15f);
        // If Camera Shake effect is over, reset variables
        virtualCameraNoise.m_AmplitudeGain = 0f;
        ShakeElapsedTime = 0f;
    }
}