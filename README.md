# EyeTK
The Eye Interaction Toolkit is a unity package that provides functionality for enabling gaze based interactions with the Hololens 2. It contains a number of prefabs and scripts to simplify the process of adding eye interactions to Augmented Reality projects. This toolkit uses openXR (instead of MRTK). 

- *XR Origin*: Provides camera and necessary components to enable gaze interactions through openXR
- *Gaze Interaction Enabler*: Component to include on any object to enable gaze interactions
- *Gaze Commuicator*: Prefab to add anywhere in the scene to enable communication with the seperate gaze monitoring application

## Getting Started


### 1. Configure a new Unity Project
- Create a new project using Unity 2020. There are known issues building hololens 2 projects with Unity 2021 and 2022.
- Use the Microsoft Mixed Reality Feature Tool to add the MR OpenXRTool to the new project to enable openXR runtimes.
    - Expand Platform Support -> Add Mixed Reality OpenXR Plugin to project -> change version to 15.1
    - *NOTE [4/16/2024]*: use version 15.1, there are issues with the newer versions
- Adjust the project and build settings as follow [(source)](http://www.lancelarsen.com/xr-step-by-step-2023-hololens-2-setting-up-your-project-in-unity-2022-mrtk-2-8-3-visual-studio-2022/):

    - (Unity Toolbar) File -> Build Settings…
        - Click Add Open Scenes
        - Switch Platform to Universal Windows Platform
        - Switch Architecture -> ARM 64-bit
        - Switch Minimum Platform Version -> 10.0.18362.0 (or newer)
        - Check Copy References
        - Click Switch Platform
    - (Unity Toolbar) Edit -> Project Settings
        - Click XR Plug-in Management
        - Click Universal Windows Platform settings tab
        - Check OpenXR
        - Check Microsoft HoloLens feature group
        - Click the Warning Icon -> Click Fix All
        - Click Windows, Mac, Linux XR Plug-in Management Settings tab
        - Check OpenXR
        - Check Microsoft HoloLens feature group
        - Click the Warning Icon -> Click Fix All
            - If left with “At least one interaction profile must be added.” -> Click on Edit
                - (Project Settings -> OpenXR) Click the “+” under Interaction Profiles
                - Add Eye Gaze Interaction Profile
                - Add Microsoft Hand Interaction Profile
    - (Unity Toolbar) Mixed Reality -> Project -> Apply recommended project settings for HoloLens 2


 ### 2. Adding the EyeTK Unity Package
 Download the repository to your local machine. In a Unity project, use the package manager to add a package from disc and navigate to the package.json file under gaze-interaction-toolkit. 

 ## Using the Unity Package
 - Add the XR Origin prefab to an empty scene. From here, you could build and deploy the project to ensure all settings are configured correctly. 
 - To enable gaze interactions on an object
    1. Add the Gaze Interaction Enabler to any object
    2. Adjust settings
    3. Select the kind of interaction you would like to enable (gaze/dwell, eyeshadows, gaze blink)
    4. Configure interaction setting (see below for available configurations)
    5. Build, deploy, and test!
- To enable gaze interactions on menu items
    1. Add gaze interaction enabler to target UI element (button)
    2. Adjust settings
    3. Select the kind of interaction you would like to enable
    4. Configure interaction settings
    5. Build, deploy, and test!

## Gaze Interaction Modalities
### Gaze Dwell
Selections are completed by staring at a interactable object for a specified number of seconds. Upon completion, the selection behavior will automatically trigger. 
To configure this interaction...
1. Choose Gaze Dwell from the Gaze Type List
2. Specify a time to select (in seconds). The script defaults to 4 seconds, we reccomend using 2 seconds. Additional user testing can be completed to idenitfy a comfortable dwell time
3. Drag a Gaze Timer prefab into the unity hierarchy. Ensure the target interactable object is the parent of the Gaze Timer
4. Add a reference to the Gaze Timer in the inspector of the Gaze Interaction Enabler
5. Add a Hover Enter Event with the Gaze Timer as the target object and GameObject.SetActive as the function. Make sure the check box is clicked!!
6. Add a Hover Exit Event with the Gaze Timer as the target object and RadialProgress.setInactive as the function. 
7. Add a Select event
8. Build, deploy, and test!