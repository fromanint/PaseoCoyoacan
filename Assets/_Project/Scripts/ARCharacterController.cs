using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCharacterController : MonoBehaviour
{
    public GameObject arCharacter;
   
    public AudioClip audioHistory;
    public AudioClip audioLegend;
  
    public AnimationClip animationHistory;
    public AnimationClip animationLegend;

    public Transform Child;

    public Animation animationClips;
    public AudioSource audioSource;

    public GameObject ScanningUI;
    

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = arCharacter.GetComponent<AudioSource>();
        animationClips = arCharacter.GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartPlaying()
    {
        if (!audioSource.isPlaying)
        // Set arCharacter to Child
        {
            arCharacter.transform.parent = Child;

            // Reset arCharacter (Scale, Rotate, position)
            arCharacter.transform.localPosition = Vector3.zero;
            arCharacter.transform.localRotation = Quaternion.identity;
            arCharacter.transform.localScale = Vector3.one;

            // Check if it's "legend" or "history" depending on the result, add the audio and the animation to the arCharacter component



            if (GlobalVariables.history == "history")
            {
                audioSource.clip = audioHistory;

                animationClips.clip = animationHistory;

            }
            else
            {
                audioSource.clip = audioLegend;
                animationClips.clip = animationLegend;

            }
            animationClips.Play();
            audioSource.Play();
            GlobalVariables.ImageTarget = this.gameObject.name;
            ScanningUI.SetActive(false);
            // wait for the animation and audio to finish playing
            StartCoroutine(WaitForAnimationAndAudio());
            
        }
        else {
            if (GlobalVariables.ImageTarget == this.gameObject.name);
            {
                arCharacter.transform.parent = Child;

                // Reset arCharacter (Scale, Rotate, position)
                arCharacter.transform.localPosition = Vector3.zero;
                arCharacter.transform.localRotation = Quaternion.identity;
                arCharacter.transform.localScale = Vector3.one;
            }
        }

    }


    IEnumerator WaitForAnimationAndAudio()
    {


        // wait until the animation and audio finish playing
        while (audioSource.isPlaying )
        {

            yield return null;
        }

        // set ImageTarget to an empty string and enable ScanningUI
        GlobalVariables.ImageTarget = "";
        ScanningUI.SetActive(true);
        StopPlaying();
    }


    public void StopPlaying()
    {
        arCharacter.transform.parent = null;
        arCharacter.transform.localScale = Vector3.zero;
        if (audioSource.isPlaying)
        {
            ScanningUI.SetActive(true);
        }
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
   
}
