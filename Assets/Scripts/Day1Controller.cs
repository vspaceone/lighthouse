using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1Controller : MonoBehaviour
{

    public GameObject msgBoxPrefab;

    private Dictionary<string, bool> occuredActions = new Dictionary<string, bool>();
    public GameObject AudioPrefab;

    public bool HandleAction(string Action, GameObject GO, ref Dictionary<string, bool> completeActions)
    {
        //biggest f-ing switch monster ever
        bool temp = false;

        switch (Action)
        {

            case "fernschreiber_anschauen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.SetMsg("Wetter: Heute stürmische See. 13 Grad, Wind NW, 10kmh");
                Global.Gamestate.lightstate = "on";
                occuredActions.Add(Action, true);
                completeActions.Add(Action, true);
                return true;
                break;
            }
            case "Start":
                Day1Ocean();
                return true;
                break;
            default:
                Debug.Log(GO.name + " sent action " + Action);
                return false;
                break;

        }

        return false;
    }

    void PlayAudio(string name, bool loop = false)
    {
        AudioClip audioClip = Resources.Load("Audio/" + name) as AudioClip;
        GameObject go = new GameObject("Audio-" + name);
        if (!loop) Destroy(go, audioClip.length);

        go.transform.parent = Camera.main.transform;
        go.transform.localPosition = Vector3.zero;
        go.tag = "Audio";

        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = audioClip;

        audioSource.loop = loop;

        audioSource.Play();
    }

    IEnumerator FadeOutSound(GameObject go, float duration = 2f)
    {
        AudioSource audioSource = go.GetComponent<AudioSource>();
        float startVol = audioSource.volume;
        float rate = 1.0f / duration;

        for (float x = 0.0f; x <= 1.0f; x += Time.deltaTime * rate)
        {
            audioSource.volume = Mathf.Lerp(startVol, 0, x);
            yield return null;
        }
        Destroy(go);
    }


    void FadeAllAudio(float duration = 2f)
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Audio");

        foreach (var go in gos)
        {
            StartCoroutine(FadeOutSound(go, duration));
        }
    }

    IEnumerator Start()
    {
        Day1Ocean();
        yield return new WaitForSeconds(10);
        Day1AlarmClock();
    }

    void Day1AlarmClock()
    {
        //PlayAudio("319490__margau__30-seconds-alarm");
    }

    void Day1Ocean()
    {
        PlayAudio("400632__inspectorj__ambience-seaside-waves-close-a");
    }
}
