using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using static UnityEngine.InputManagerEntry;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sounds[] sounds;

    


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }



    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }


    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }


    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene == SceneManager.GetSceneByName("MainMenu"))
        {
            StopAudio("Victory Theme");
            StopAudio("Losing Theme");

            PlayAudio("Main Menu Theme");
            
        }
        else if(scene == SceneManager.GetSceneByName("Main"))
        {
            StopAudio("Victory Theme");
            StopAudio("Losing Theme");
            StopAudio("Main Menu Theme");

           //play bg music here 
        }

    }

    

    public void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("On Scene Unloaded:" + scene.name);
        Debug.Log("mode");
    }

    
    //Used for unity events (same as play audio but not a static funtion)
    public void PlayAudioEvent(string name)
    {
        //Finds a sound in the sounds array
        Sounds s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Play();
    }

    //Plays the audio sound with the given name
    public static void PlayAudio(string name)
    {
        //Finds a sound in the sounds array
        Sounds s = Array.Find(instance.sounds, sounds => sounds.name == name);
        s.source.Play();
       
        
    }

    public static void EnableAudioSource(string name,  bool enable)
    {
        //Finds a sound in the sounds array
        Sounds s = Array.Find(instance.sounds, sounds => sounds.name == name);
        s.source.enabled = enable;
    }

    //Stops the audio sound with the given name
    public static void StopAudio(string name)
    {
        //Finds a sound in the sounds array
        Sounds s = Array.Find(instance.sounds, sounds => sounds.name == name);
        s.source.Stop();
        
    }
}
