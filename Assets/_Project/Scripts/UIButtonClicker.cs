using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIbuttonClicker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    //----------------------------------------------------------------------------------------------------------------------------
    // *NOTE* Make sure to apply this script to a UI element inside the Canvas and that you have an EventSystem in the project ---
    //----------------------------------------------------------------------------------------------------------------------------


    [Header("DISABLE AND ENABLE THIS BUTTON")]
    [Tooltip("The button will not work if this boolean is turned off.")]
    public bool active = true;


    [Header("NEW COLOR")]
    //If you use the "ChangeColor" function, this is the color the object will be tinted with and the one it will return to in case you need it ---
    public Color newColor;
    Image thisImage;
    Color originalColor;

    //Used only if you call the "ChangeScale" function ---
    Vector2 originalScale;


    [Header("WHAT WILL IT DO WHEN CURSOR ENTERS, EXITS, PRESSES AND RELEASES?")]
    //Drag a script that includes the function you would like to happen when this button is hovered over by the cursor, exits, is clicked and when it¥s released. You can drag as many as you want, just click the + symbol ---

    public UnityEvent enterButton;
    public UnityEvent exitButton;
    public UnityEvent clickDown;
    public UnityEvent clickUp;

    #region AWAKE
    //------------------------------------------------------------------------------------------------------------------------------------------------    

    //Make sure there is an Image component on this object ---
    void Awake()
    {
        if (GetComponent<Image>())
        {
            thisImage = GetComponent<Image>();
        }
    }
    #endregion

    #region EVENTS
    //-----------------------------------------------------------------------------------------------------------------------------------------------
    //---------- EVENTS --------------
    //-----------------------------------------------------------------------------------------------------------------------------------------------

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (active)
        {
            enterButton.Invoke();
        }
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (active)
        {
            exitButton.Invoke();
        }
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (active)
        {
            clickDown.Invoke();
        }
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if (active)
        {
            clickUp.Invoke();
        }
    }

    #endregion

    #region COMMONLY USED FUNCTIONS
    //----------------------------------------------------------------------------------------
    //------------- COMMONLY USED FUNCTIONS --------------------------------------------------
    //----------------------------------------------------------------------------------------

    //Print something to console for testing ---
    public void PrintSomething(string message)
    {
        Debug.Log(message);
    }

    //Load a scene ---
    public void LoadSceneByNumber(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Run an animation ---
    public void RunAnimation(Animation anim)
    {
        anim.Play();
    }

    //Multiply the current scale by "newScale", so if newScale is 1, there will be no change. Any number above 1 will make it grow and any number below will shrink it.
    //Also, the original scale of the object will be stored in the "originalScale" Vector2 variable, so you can go back to it if you need to with the "ReturnToScale" function ---
    public void ChangeScale(float newScale)
    {
        originalScale = transform.localScale;
        transform.localScale = new Vector2(transform.localScale.x * newScale, transform.localScale.y * newScale);
    }

    //Return the object to its original scale in case you used the "ChangeScale" function ---
    public void ReturnToScale()
    {
        if (originalScale != null)
        {
            transform.localScale = originalScale;
        }
    }

    //Change object¥s tint to "newColor" ---
    public void ChangeColor()
    {
        originalColor = thisImage.color;
        thisImage.color = newColor;
    }

    //Return object¥s tint to original color ---
    public void ReturnColor()
    {
        thisImage.color = originalColor;
    }

    //Destroy an object ---
    public void RemoveObject(GameObject targetObject)
    {
        Destroy(targetObject);
    }

    //Open a URL ---
    public void OpenUrl(string url)
    {
        Application.OpenURL(url);
    }

    #endregion
}
