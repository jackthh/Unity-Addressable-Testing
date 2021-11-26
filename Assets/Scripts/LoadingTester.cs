using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class LoadingTester : MonoBehaviour
{
    public AssetReferenceGameObject temp;


    private void Start()
    {
       //  Addressables.LoadAssetAsync<GameObject>("Temp Prefab 3").Completed += Spawn;
       //
       // // var a = temp.LoadAssetAsync();
       // // Instantiate(a.Result, new Vector3(5f, 0f, 0f), Quaternion.identity, null);
       //
       //  temp.InstantiateAsync(new Vector3(0f, 10f, 0f), Quaternion.identity);


        // Addressables.LoadSceneAsync("Empty Scene").Completed += Test;
        Addressables.DownloadDependenciesAsync("Temp 2").Completed += Test1;
    }


    private void Test1(AsyncOperationHandle _obj)
    {
        var temp = _obj.Result as List<IAssetBundleResource>;

        foreach (var bundleResource in temp)
        {
            var assetBundle = bundleResource.GetAssetBundle();
            
            foreach (var assetName in  assetBundle.GetAllAssetNames())
            {
                Debug.Log("ADDRESSABLE TESTING: " + assetName);
            }
        }
    }



}