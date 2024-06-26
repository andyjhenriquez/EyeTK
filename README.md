# EyeTK
The Eye Interaction Toolkit is a unity package that provides functionality for enabling gaze based interactions with the Hololens 2. It contains a number of prefabs and scripts to simplify the process of adding eye interactions to Augmented Reality projects. This toolkit uses openXR (instead of MRTK). 

- *Complete XR Origin Set Up*: Provides camera and necessary components to enable gaze interactions through openXR
- *Gaze Interaction Manager*: Main script that handles global settings, heatmap settings and generation, and more
- *Gaze Timer*: General prefab to add to objects or UI to enable gaze interactions
- *Interactable Canvas*: Prefab example canvas that includes all functionality for moving UI, and turning off and on UI or heatmap(s)

## Getting Started


### 1. Configure a new Unity Project
- Create a new project using Unity 2020. There are known issues building hololens 2 projects with Unity 2021 and 2022.
- Install XR Interaction Toolkit Unity package, and XR Hands (if you will be using the hand tracking and gesture recognition)
- Use the Microsoft Mixed Reality Feature Tool to add the MR OpenXRTool to the new project to enable openXR runtimes.
    - Expand Platform Support -> Add Mixed Reality OpenXR Plugin to project -> change version to 15.1
    - *NOTE [4/16/2024]*: use version 15.1, there are issues with the newer versions
- Adjust the project and build settings as follow [(source)](http://www.lancelarsen.com/xr-step-by-step-2023-hololens-2-setting-up-your-project-in-unity-2022-mrtk-2-8-3-visual-studio-2022/):

    - (Unity Toolbar) File -> Build Settings For HoloLens 2
        - Click Add Open Scenes
        - Switch Platform to Universal Windows Platform
        - Target Device -> HoloLens
        - Switch Architecture -> ARM 64-bit
        - Switch Minimum Platform Version -> 10.0.18362.0 (or newer)
        - Build and Run on -> USB Device (if connected via USB)
        - Check Copy References
        - Click Switch Platform
  - (Unity Toolbar) File -> Build Settings For HoloLens 2 EMULATOR
    - Click Add Open Scenes
    - Switch Platform to Universal Windows Platform
    - Target Device -> HoloLens
    - Switch Architecture -> x64
    - Switch Minimum Platform Version -> 10.0.10586.0 (known issues with other versions)
    - Build and Run on -> Local Machine
     - Check Devlopment Build
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
 Download the repository to your local machine. In a Unity project, select Assets -> Import Package -> Custom Package... and then select EyeTK.unitypackage.

 ## Using eye interactions
 - Create an "Editor" folder (if there is not one already) and place the ConditionalHidePropertyDrawers.cs inside there
 - Add the Complete XR Origin Set Up and GazeInteractionManager prefabs to an empty scene. From here, you could build and deploy the project to ensure all settings are configured correctly.
 - To enable gaze interactions on an object and UI
    1. Add the XR Simple Interactable component
    2. Add the Gaze Timer prefab as a child
    3. Configure the XR Simple Interactable component by navigating to the section labelled Interactable Events:
           - Add Gaze Timer to First/Last Hover with GameObject.SetActive set to true
           - Add Gaze Timer (UI Interaction) to Last Hover Exited with UIInteraction.setInactive
    5. Select available functionality
    6. Configure global settings in GazeInteractionManager prefab
    7. Build, deploy, and test!

 ## Using heatmaps
 - All heatmap settings and configurations are within the GazeInteractionManager prefab
 - Enable Heatmap and configure settings accordingly
 - Mesh Based heatmap type automatically generates a heatmap for all gameobjects with a MeshRenderer component attatched, User Based creates a spherical heatmap around the user's gaze origin
