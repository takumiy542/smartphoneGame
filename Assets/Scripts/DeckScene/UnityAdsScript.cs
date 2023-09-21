using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsScript : MonoBehaviour
{
    private string gameID;
    player_State player;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_IOS
        gameID = "5134296";
#elif UNITY_ANDROID
        gameID = "5134297";
#endif

        Advertisement.Initialize(gameID);

        player = GameObject.Find("Player").GetComponent<player_State>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        //if (GUILayout.Button("Call ShowUnityAds()")) 
        //{
        //    ShowUnityAds();
        //}
    }

    public void ShowUnityAds()
    {
        if(Advertisement.IsReady("Rewarded_Android"))
        {
            var options = new ShowOptions
            {
                resultCallback = HandleShowResult
            };
            Advertisement.Show("Rewarded_Android", options);
        }
    }
    void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Finish");

                player.AddCoin();

                break;

            case ShowResult.Skipped:
                Debug.Log("Skipped");
                break;

            case ShowResult.Failed:
                Debug.Log("Failed");
                break;

            default:
                break;
        }
        
    }
}
