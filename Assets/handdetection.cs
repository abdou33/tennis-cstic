// using UnityEngine;
// using UnityEngine.UI;
// using HandTrackingModule;

// public class HandTracking : MonoBehaviour
// {
//     public RawImage displayImage;
//     private WebCamTexture webcamTexture;
//     private HandTrackingModule handTrackingModule;

//     void Start()
//     {
//         InitializeWebcam();
//         InitializeHandTracking();
//     }

//     void InitializeWebcam()
//     {
//         WebCamDevice[] devices = WebCamTexture.devices;

//         if (devices.Length > 0)
//         {
//             webcamTexture = new WebCamTexture(devices[0].name);
//             webcamTexture.Play();

//             displayImage.texture = webcamTexture;
//         }
//         else
//         {
//             Debug.LogError("No webcam devices found.");
//         }
//     }

//     void InitializeHandTracking()
//     {
//         handTrackingModule = new HandTrackingModule();
//         handTrackingModule.Initialize();
//     }

//     void Update()
//     {
//         if (webcamTexture != null && webcamTexture.isPlaying)
//         {
//             // Flip the webcam texture horizontally
//             displayImage.uvRect = new Rect(1, 0, -1, 1);

//             // Process the frame to detect hands
//             Texture2D frameTexture = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.RGBA32, false);
//             frameTexture.SetPixels32(webcamTexture.GetPixels32());
//             frameTexture.Apply();

//             handTrackingModule.ProcessImage(frameTexture);

//             // Access hand landmarks or other hand tracking information as needed
//             // For example: handTrackingModule.GetHandLandmarks()

//             // Update your game logic based on hand tracking results
//         }
//     }

//     void OnDisable()
//     {
//         StopWebcam();
//         handTrackingModule.Dispose();
//     }

//     void StopWebcam()
//     {
//         if (webcamTexture != null && webcamTexture.isPlaying)
//         {
//             webcamTexture.Stop();
//         }
//     }
// }
