using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCharacterController : MonoBehaviour
{
    public GameObject arCharacter;
    public AudioClip audioLegend;
    public AudioClip audioHistory;
    public AnimationClip animationLegend;
    public AnimationClip animationHistory;

    public Transform Child;

    Animation animation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartPlaying()
    {
        // Set arCharacter to Child
        arCharacter.transform.parent = Child;

        // Reset arCharacter (Scale, Rotate, position)
        arCharacter.transform.localPosition = Vector3.zero;
        arCharacter.transform.localRotation = Quaternion.identity;
        arCharacter.transform.localScale = Vector3.one;

        // Check if it's "legend" or "history" depending on the result, add the audio and the animation to the arCharacter component
        AudioSource audioSource = arCharacter.GetComponent<AudioSource>();
         animation = arCharacter.AddComponent<Animation>();

        if (GlobalVariables.history == "history")
        {
            audioSource.clip = audioHistory;
           // animation.AddClip(animationHistory, "HistoryAnimation");
         //   animation.Play("HistoryAnimation");
        }
        else
        {
            audioSource.clip = audioLegend;
           //  animation.AddClip(animationLegend, "LegendAnimation");
          //  animation.Play("LegendAnimation");
        }

        audioSource.Play();
    }
}
