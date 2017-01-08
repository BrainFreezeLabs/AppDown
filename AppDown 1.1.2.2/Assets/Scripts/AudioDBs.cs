using UnityEngine;
using System.Collections;

public class AudioDBs : MonoBehaviour {
    public static AudioDBs instance;
    public AudioClip[] diana;
    public AudioClip[] marco;
    public AudioSource audioS;


    private AudioClip currAudioFile;
    void Awake()
    {
        instance = this;
    }

    private void SetAudio(string _palabra, bool _left)
    {
        if(_left)
        {
            foreach(AudioClip audioName in diana)
            {
                if(audioName.name.Contains(_palabra))
                {
                    currAudioFile = audioName;
                    break;
                }
            }
        }
        else
        {
            foreach (AudioClip audioName in marco)
            {
                if (audioName.name.Contains(_palabra))
                {
                    currAudioFile = audioName;
                    break;
                }
            }
        }
        audioS.clip = currAudioFile;
    }

    public void PlayAudio(string _palabra, bool _vaca)
    {
        SetAudio(_palabra, _vaca);
        audioS.Play();
    }

    public float AudioLenght()
    {
        if (currAudioFile != null)
            return currAudioFile.length;

        else
            return 0;
    }
}
