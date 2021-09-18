using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class AssetLoader : MonoBehaviour
{
    public string url = "https://aws-s3-horse-ar-stream-bucket.s3.eu-west-2.amazonaws.com/horsear";
    public string assetName = "HorseAR";

    IEnumerator Start()
    {
        using (UnityWebRequest web =  UnityWebRequestAssetBundle.GetAssetBundle("https://aws-s3-horse-ar-stream-bucket.s3.eu-west-2.amazonaws.com/horsear"))
        {
            yield return web.SendWebRequest();
                 
            

            if(web.isNetworkError || web.isHttpError)
            {
                Debug.LogError(web.error);
                yield break;
            }

            AssetBundle assetBundle = DownloadHandlerAssetBundle.GetContent(web);

            GameObject horse = Instantiate(assetBundle.LoadAsset(assetName)) as GameObject;
            assetBundle.Unload(false);

            horse.transform.parent = GameObject.FindGameObjectWithTag("ImageTarget").transform;
            horse.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            horse.transform.localPosition = new Vector3(-0.26f, 0.02f, -0.086f);

            UIManager.Instance.AssignModel(horse.GetComponent<Animator>(), horse.transform.GetChild(4).GetChild(0).gameObject, horse.transform.GetChild(4).GetChild(1).gameObject);

        }
    }

    
}
