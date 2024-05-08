using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class GazeInteractionEnabler : MonoBehaviour
{
    public GameObject gazeTimer;
    public UnityEvent select = new UnityEvent();
    public UnityEvent hoverEnter = new UnityEvent();
    public UnityEvent hoverExit = new UnityEvent();

    public enum gazeInteractionType
    {
        gazeDwell,
        gazeBlink,
        eyeShadows
    }
    public gazeInteractionType gazeTypeList;
    public float timeToSelect = 4.0f;
    void Start()
    {
        // Instantiate a collider
        BoxCollider collider = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        // Instantiate XRSimpleInteractable Component to gameObject
        XRSimpleInteractable XRi = gameObject.AddComponent<XRSimpleInteractable>();

        // Gaze Interaction Specific Settings/Functionality
        if (gazeTypeList == gazeInteractionType.gazeDwell)
        {
            if (gazeTimer == null)
            {
                Debug.Log("error: no gaze timer found");
            }
            else
            {
                gazeTimer.SetActive(false);
                RadialProgress gazeProgTimer = gazeTimer.GetComponent<RadialProgress>();
                gazeProgTimer.timeComplete = timeToSelect;
                XRi.firstHoverEntered.AddListener(firstHoverEntered);
                XRi.lastHoverExited.AddListener(lastHoverExited);
                XRi.selectEntered.AddListener(selectEntered);
            }
        }

        // XR Simple Interactable Settings
        XRi.allowGazeInteraction = true;
        XRi.allowGazeSelect = true;
        XRi.overrideGazeTimeToSelect = true;
        XRi.allowGazeAssistance = true;
        XRi.gazeTimeToSelect = timeToSelect;
    }

    // change this function to change what happens on hover enter
    public void firstHoverEntered(HoverEnterEventArgs args)
    {
        Debug.Log("hover enter success");
        hoverEnter.Invoke();
    }

    // change this function to change what happens on hover exit
    public void lastHoverExited(HoverExitEventArgs args)
    {
        Debug.Log("hover exit success");
        hoverExit.Invoke();
    }

    // change this function to change what happens on object select
    public void selectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("select success");
        select.Invoke();
    }
}
