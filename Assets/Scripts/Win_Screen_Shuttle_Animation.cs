﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls the behavior of the rocket on the Win
//Screen for the ISS mission. Attach it to the rocket object

public class Win_Screen_Shuttle_Animation: MonoBehaviour {

    public static AudioSource audio;
    Material sky;

    //Start out by setting the skybox to the custom space backdrop
    //Also make sure the color of the rocket is consistent and the audio
    //carries over from the previous screen
    void Start() {
        sky = RenderSettings.skybox;
        sky.SetFloat("_AtmosphereThickness", 0);
        ColorChange.ChangeColor(ColorChange.getColor());
        audio = ScreenChanges.audio2;
    }

    // Update is called once per frame
    void Update() {
        Vector3 old_pos = gameObject.transform.position;
        Vector3 new_pos = new Vector3(old_pos.x + 10f, old_pos.y + 50f, old_pos.z);
        gameObject.transform.position = new_pos;
        //Decrease the launch sounds over time
        audio.volume -= 0.005f;
        //Stop it if volume decreases to 0
        if (audio.volume <= 0 && audio.isPlaying) {
            audio.Stop();
        }
    }

    //Reset the audio volume to default. Call this with
    //the button press on the win screen
    public void reset() {
        audio.volume = 1;
        if (audio.isPlaying) {
            ScreenChanges.launch_sounds();
        }
    }

}
