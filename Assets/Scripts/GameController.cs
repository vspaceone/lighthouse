using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject AudioPrefab;

    public void Action(string Action, GameObject GO)
    {
        //biggest f-ing switch monster ever

        switch (Action)
        {
            case "Start":
                Day1AlarmClock();
                break;
            default:
                Debug.Log(GO.name + " sent action " + Action);
                break;
        }
    }

    void PlayAudio(string name, bool loop=false)
    {
        AudioClip audioClip = Resources.Load("Audio/" + name) as AudioClip;
        GameObject go = Instantiate(new GameObject("Audio-" + name)) as GameObject;
        if (!loop) Destroy(go, audioClip.length);

        go.transform.parent = Camera.main.transform;
        go.transform.localPosition = Vector3.zero;

        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = audioClip;

        audioSource.loop = loop;

        audioSource.Play();
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(10);
        Action("Start", this.gameObject);
    }

    void Day1AlarmClock()
    {
        PlayAudio("319490__margau__30-seconds-alarm");
    }
}
