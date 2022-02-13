using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class Lava : MonoBehaviour
{
    public float ShakeDuration = 0.3f;          // Time the Camera Shake effect will last
    public float ShakeAmplitude = 1.2f;         // Cinemachine Noise Profile Parameter
    public float ShakeFrequency = 2.0f;         // Cinemachine Noise Profile Parameter
    public AudioSource lavaSound;
    public ScoreSystem SS;
    public bool IsLava;
    public GameObject TopBound;
    public Animator anim;

    private float ShakeElapsedTime = 0f;

    // Cinemachine Shake
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    void Start()
    {
        TopBound = GameObject.Find("LavaArea");
        VirtualCamera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        SS = GameObject.Find("ScoreSysem").GetComponent<ScoreSystem>();
        anim = GameObject.Find("Player").GetComponent<Animator>();
        // Get Virtual Camera Noise Profile
        if (VirtualCamera != null)
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            ShakeElapsedTime = ShakeDuration;
            anim.SetTrigger("Hurt");
            SS.Hearts = SS.Hearts - 1;
            lavaSound.Play();
            if (IsLava)
            {
                col.transform.position = new Vector3(TopBound.transform.position.x, TopBound.transform.position.y, col.transform.position.z);
            }
        }
    }

    void Update()
    {
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