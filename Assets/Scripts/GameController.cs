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

                if(!occuredActions.TryGetValue("licht_anschalten", out temp)){
                    mBoxCtrl.SetMsg("Ich muss erst das Licht anschalten.");
                }else if(!occuredActions.TryGetValue("zaehne_putzen", out temp)){
                    mBoxCtrl.SetMsg("Ich denke ich sollte mir erst die Zähne putzen?");
                }else if(!occuredActions.TryGetValue("essen", out temp)){
                    mBoxCtrl.SetMsg("Ich hab noch garnichts gegessen!");
                }else{
                    mBoxCtrl.SetMsg("Tzzzzzz....");
                    occuredActions.Add(Action, true);
                }
                break;
            }
            case "licht_anschalten":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.SetMsg("Es wird Zeit, das Licht anzuschalten.");
                occuredActions.Add(Action, true);
                break;
            }
            case "licht_ausschalten":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.SetMsg("Es ist hell. Wir brauchen kein Licht mehr.");
                occuredActions.Add(Action, true);
                break;
            }
            case "dose_holen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.SetMsg("Mhmmm Ravioli. Lecker. Jetzt wird gekocht...");
                occuredActions.Add(Action, true);
                break;
            }
            case "kochen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();

                if(!occuredActions.TryGetValue("dose_holen", out temp)){
                    mBoxCtrl.SetMsg("Ich denke ich sollte mir erst was zum kochen besorgen...");
                }else{
                    mBoxCtrl.SetMsg("Ravioli sind auch schön einfach. Nur kein Stress.");
                    occuredActions.Add(Action, true);
                }
                break;
            }
            case "essen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();

                if(!occuredActions.TryGetValue("kochen", out temp)){
                    mBoxCtrl.SetMsg("Ich denke ich sollte mir erst was kochen. Oder nicht?");
                }else{
                    mBoxCtrl.SetMsg("Die Ravioli sind super");
                    occuredActions.Add(Action, true);
                }
                break;
            }
            case "blumen_giessen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.SetMsg("Ich liebe meine Blumen.");
                occuredActions.Add(Action, true);
                break;
            }
            case "karte_anschauen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.SetMsg("Mhmmm Ravioli. Lecker. Jetzt wird gekocht...");
                occuredActions.Add(Action, true);
                break;
            }
            case "zaehne_putzen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.SetMsg("Immer 3 Minuten Zähne putzen. Wichtig!");
                occuredActions.Add(Action, true);
                break;
            }
            case "generator_nachfuellen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.SetMsg("Ja der braucht schon wieder Sprit...");
                occuredActions.Add(Action, true);
                break;
            }
            case "tomaten_streicheln":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.SetMsg("Die Tomaten lieben es wenn man sie streichelt.");
                occuredActions.Add(Action, true);
                break;
            }
            case "in_briefkasten_schauen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.SetMsg("Oh. Leider kein Brief für mich.");
                occuredActions.Add(Action, true);
                break;
            }
            case "fernschreiber_anschauen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.SetMsg("Das ist mein Fernschreiber. Hier kommen regelmäßig wichtige Neuigkeiten rein.");
                occuredActions.Add(Action, true);
                break;
            }
            case "funkgeraet_anschauen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.SetMsg("Das ist mein Funkgeraet. Aber es ist schon lange kaputt. Es kann nur noch empfangen.");
                occuredActions.Add(Action, true);
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

        //audioSource.Play();
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
