VR Application Report 

StudentID: A00328055 

Student Name: Alex Browne 

Module: VR Application 

 

Introduction: 

For my VR Application Development project i decided to make an Formula 1 style pit stop interaction game  using the XR interaction toolkit. The main goal of the project was to make a scene that incorporated all techniques that had been covered throughout the module while also sticking to the theme of simulation. I believed the formula 1 pit stop game gave me the opportunity to incorporate physical interaction with a time based objective provided by the gui. The main objective of the game was for the player to remove and install all four tyres on the car before the timer ran out, the player would also have to hit a button to stop the timer also indicated by the car rotating. The main objective of the project was to incorporate all the techniques that had been learned and put them into practice. 
<img width="1186" height="549" alt="Screenshot 2026-11-24 185802" src="https://github.com/user-attachments/assets/09507dda-ee1f-471f-b109-12633d50ede6" />
 

 

Game Design and Objectives: 

The game starts within the formula 1 garage. It contains the car and equipment required in order to complete the objectives. The player has full mobility to move around and interact with objects required to stop the timer and complete the pit stop. 

The player is given 60 seconds to complete three main tasks: 

    Take off current old tyre thats already attached. 

    Replace it with new one and tighten with wheel gun 

    Press release button to complete tasks 

When the player completes the tasks the timer will stop a victory sound will play and the car will start rotating in celebration. If the timer reaches zero and the player has been unable to complete all the tasks the tyres will stop being able to be changed and the player will receive no victory animation or sound. 

Technical Implementation: 

VR Set up and Locomotion 

The project set up taken from the XR interaction toolkit. The XR origin manages the position and rotation of the players headset and controllers. The locomotion set up allows the player to move around freely in VR and approach objects and the controller indicators allows the player to then physically interact with them. 
<img width="1427" height="579" alt="Screenshot 2026-11-24 193049" src="https://github.com/user-attachments/assets/48dbd44a-f691-4257-8322-6e708943347a" />
  

Grabbable Objects 

The tyres and wheel gun designed as objects you can pick up are done using the XR grab interactable components. They require a rigidbody and collider components in order to support the physical interactions. This allows the player to move and hold the equipment with their controllers. Problems can occur with this especially if you are using assets that may have not been intended to be used in VR and this one issue I came across however they can be fixed by finding the correct collider shape and adjustments with the anchor.  
<img width="1152" height="733" alt="Screenshot 2026-11-24 193820" src="https://github.com/user-attachments/assets/9d6bbc12-e927-442a-ad1b-abe7736c2fe5" />
 

XR Socket Interactor 

To allow the player to install the tyres on the car I used a XR socket interactor which I located at the wheel hub. The socket detects compatible interactable objects entering its detection area. An attach transform determines the position and rotation of the tyre when it is installed, this had to be adjusted in order for the wheel assets to fit properly on the car. The socket's Select Entered and Select Exited events communicate with the pitstopmanager script. These events allow the game to track whether the replacement tyre has been installed or removed. This mechanic was particularly useful because it allowed me to simulate tyre installation without requiring complicated mechanical physics. 
<img width="1439" height="507" alt="Screenshot 2026-11-25 181622" src="https://github.com/user-attachments/assets/baa168f2-c481-4e5a-a4a0-62afd2063f40" />
 

 

 

Wheel Gun Interaction 

The wheel gun mechanic the was implemented was done so using two scripts called wheelgunmarker and wheelguntrigger. The marker script identifies the wheel gun, while the trigger script is attached to a detection zone positioned near the centre of the wheel. When the wheel gun enters the trigger zone the OnTriggerEnter method checks whether the object contains the marker component. If so it uses the TightenWheel method in the game manager to tighten the wheel. The game manager checks that the tyre has already been installed before allowing the tightening action to succeed. This prevents the player from completing the tasks in the incorrect order. 
<img width="484" height="472" alt="Screenshot 2026-11-25 182502" src="https://github.com/user-attachments/assets/d1517f9c-e407-4b93-95dd-f56f60ec71df" />
<img width="1439" height="301" alt="Screenshot 2026-11-25 182602" src="https://github.com/user-attachments/assets/6bea74d0-13ff-4970-9252-4236d680df36" />
 

 

 

 

 

Game Management 

The pitstopmanager script controls the overall gameplay. It uses Boolean variables to track whether the tyre is installed, the wheel is tightened, the game has ended and the player has won. The pitstopmanager is also in charge of the timer, release button and the interface. The release button remains unavailable until the player has completed all the required tasks which is changing and installing new tyres. When this is complete the game manager will allow it to spawn in so the player can press it and stop the timer. The game manager also helps with the audio feedback providing separate audio clips for tyre installation, wheel tightening and victory. 
<img width="487" height="653" alt="Screenshot 2026-11-25 183250" src="https://github.com/user-attachments/assets/f841fe29-72d7-45ad-bff9-e1ebaf68817f" />
<img width="458" height="686" alt="Screenshot 2026-11-25 183311" src="https://github.com/user-attachments/assets/8826d2d4-89c3-4a98-97b4-52c6833815c4" />
<img width="583" height="642" alt="Screenshot 2026-11-25 183322" src="https://github.com/user-attachments/assets/32ebf5bf-ce56-4a1a-9acb-70d5c11230db" />
<img width="427" height="596" alt="Screenshot 2026-11-25 183331" src="https://github.com/user-attachments/assets/6f7f9098-464b-4555-9f1e-1d24a0aaf1e3" />
 

 

 

 

 

 

User Interface and Victory 

The user interface was using the canvas and text mesh pro components it displays a timer the player needs to beat to complete the challenge. When the player installs all the tyres in the given time the timer will stop and a victory audio will be played as well as a car spinning animation. The vicorycarspin script uses Vector3.up, transform.Rotate() and Time.deltaTime to rotate the car around its vertical axis at a consistent speed. This rotation as mentioned previously is activated by the game manager when the player beats the timer. 
<img width="462" height="567" alt="Screenshot 2026-11-25 184508" src="https://github.com/user-attachments/assets/b121a2f2-1824-4bb7-9471-d597ae4c7963" />
<img width="442" height="300" alt="Screenshot 2026-11-25 184635" src="https://github.com/user-attachments/assets/2f60167e-437d-4afe-8ac3-51194ae584f8" />
 

  

 

 

 

Personal Reflection And Conclusion: 

Throughout this project, I developed a better understanding of how different VR interaction techniques can be combined to create a complete gameplay experience. I don’t think I had the understanding of the amount of configuration that it takes in order to make this scene. Working through the many problems I encountered with colliders and imported assets not being ready to use in unity vr has given me the experience for the future. Working with the physics in vr and learning to combine separate objects to complete a task has been a valuable lesson. In conclusion I believe I was able to display the techniques that were learnt throughout the module and vr tutorials in order to make this F1 pit stop simulator.  
