using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject msgBoxPrefab;

    private Dictionary<string, bool> occuredActions = new Dictionary<string, bool>();
    public GameObject AudioPrefab;

    public void Action(string Action, GameObject GO)
    {
        //biggest f-ing switch monster ever
        bool temp = false;

        switch (Action)
        {
            case "schlafen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                
                if(!occuredActions.TryGetValue("zaehne_putzen", out temp)){
                    mBoxCtrl.Initialize("Ich muss erst Zaehne putzen.");
                }else{
                    mBoxCtrl.Initialize("Tzzzzzz....");
                    occuredActions.Add(Action, true);
                }
                break;
            }
            case "zaehne_putzen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.Initialize("Immer 3 Minuten Zähne putzen. Wichtig!");
                occuredActions.Add(Action, true);
                break;
            }
            case "dose_holen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.Initialize("Mhmmm Ravioli. Lecker. Jetzt wird gekocht...");
                break;
            }
            case "Start":
                Day1Ocean();
                break;
            default:
                Debug.Log(GO.name + " sent action " + Action);
                break;

        }
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
