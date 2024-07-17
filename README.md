# EyeTK
The Eye Interaction Toolkit is a unity package that provides functionality for enabling gaze based interactions with the Hololens 2. It contains a number of prefabs and scripts to simplify the process of adding eye interactions to Augmented Reality projects. This toolkit uses openXR (instead of MRTK). 

- *Complete XR Origin Set Up*: Provides camera and necessary components to enable gaze interactions through openXR
- *Gaze Interaction Manager*: Main script that handles global settings, heatmap settings and generation, and more
- *Gaze Timer*: General prefab to add to objects or UI to enable gaze interactions
- *Interactable Canvas*: Prefab example canvas that includes all functionality for moving UI, and turning off and on UI or heatmap(s)

## Getting Started


### 1. Install dependencies
1. Create a new project using Unity 2020.3+. There are known issues building HoloLens 2 projects with Unity 2021 and 2022.
1. Install Unity XR Interaction Toolkit: https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@2.2/manual/installation.html
1. Once imported, select it under Package Manager, then under Samples, import Starter Assets
1. If you will be using the hand tracking and gesture recognition, install Unity XR Hands package: https://docs.unity3d.com/Packages/com.unity.xr.hands@1.1/manual/project-setup/edit-your-project-manifest.html
    - In the manifest, use version 1.1.0 at minimum
1. Use the Microsoft Mixed Reality Feature Tool to add the MR OpenXRTool to the new project to enable openXR runtimes: https://www.microsoft.com/en-au/download/details.aspx?id=102778&msockid=320a09b4d58b6c842c3a1bb6d4e76d9d
    - Expand Platform Support -> Add Mixed Reality OpenXR Plugin to project -> change version to 1.5.1
    - *NOTE [4/16/2024]*: use version 1.5.1, there are issues with the newer versions

### 2. Configure Project Settings and Build Settings [(source)](http://www.lancelarsen.com/xr-step-by-step-2023-hololens-2-setting-up-your-project-in-unity-2022-mrtk-2-8-3-visual-studio-2022/):

#### 2.1 Build Settings
1. On Unity Toolbar, click **File -> Build Settings**
1. Click Add Open Scenes
1. Switch Platform to Universal Windows Platform
1. Target Device -> HoloLens
1. Apply settings for intended target:

    | Build Settings           | HoloLens 2                        | HoloLens Emulator                               |
    |--------------------------|-----------------------------------|-------------------------------------------------|
    | Architecture             | ARM64                             | x64                                             |
    | Minimum Platform Version | 10.0.18362.0 (or newer)           | 10.0.10586.0 (known issues with other versions) |
    | Build and Run on         | USB Device (if connected via USB) | Local Machine                                   |
    | Copy References          | Check on                          | Check off                                       |
    | Development Build        | Check off                         | Check on                                        |

#### 2.2 Project Settings
1. On Unity Toolbar, click **Edit -> Project Settings**
##### 2.2.1 Universal Windows Platform (HoloLens 2 HMD) Configuration

1. Click XR Plug-in Management
1. Click Universal Windows Platform settings tab
1. Check OpenXR
1. Wait for it to load, then check Microsoft HoloLens feature group
1. Click the Warning Icon `⚠️` next to Open XR to open Project Validation
1. Click Fix All
1. If left with “At least one interaction profile must be added.” 
    1. Click on Edit - (Project Settings -> OpenXR).
    1. Click the “+” under Interaction Profiles
    1. Add Eye Gaze Interaction Profile
    1. Add Microsoft Hand Interaction Profile
1. Click Project Validation under XR Plug-in Management, and then click Fix All if there are any remaining issues
1. On Unity Toolbar, click Mixed Reality -> Project -> Apply recommended project settings for HoloLens 2

##### 2.2.2 PC, Mac, Linux, Standalone (HoloLens 2 Emulator) Tab Configuration
1. Click XR Plug-in Management
1. Click PC, Mac, Linux, Standalone tab XR Plug-in Management Settings tab
1. Check OpenXR
1. If there is an icon `❗` next to OpenXR, click it
    1. Click Fix All. Unity will need to restart. 
    1. Go back to XR Plug-in Management tab when Unity reopens.
1. If left with “At least one interaction profile must be added.” 
    1. Click on Edit - (Project Settings -> OpenXR).
    1. Click the “+” under Interaction Profiles
    1. Add Microsoft Hand Interaction Profile
1. Click Project Validation under XR Plug-in Management, and then click Fix All if there are any remaining issues
1. On Unity Toolbar, click Mixed Reality -> Project -> Apply recommended project settings for HoloLens 2


 ### 3. Adding the EyeTK Unity Package
 1. Download or clone the repository to your local machine. 
 1. In your Unity project, select Assets -> Import Package -> Custom Package... and then select EyeTK.unitypackage.
 1. Click Import

 ## Using eye interactions
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

 ## Need help?
 - Refer to the Demo Scene in the package for how things should be configured
