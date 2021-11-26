using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class InitSceneManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        Addressables.DownloadDependenciesAsync("Asset Map 1").Completed += OnLoadedMap1;
        Addressables.DownloadDependenciesAsync("Asset Map 2").Completed += OnLoadedMap2;
        Addressables.DownloadDependenciesAsync("Asset Map 3").Completed += OnLoadedMap3;
    }


    private void OnLoadedMap1(AsyncOperationHandle _obj)
    {
        if (_obj.Result is List<IAssetBundleResource> temp)
        {
            foreach (var assetBundle in temp.Select(_bundleResource => _bundleResource.GetAssetBundle()))
            {
                foreach (var assetName in assetBundle.GetAllAssetNames())
                {
                    Debug.Log("Addressable TESTING: " + assetName);
                }
                foreach (var sceneName in assetBundle.GetAllScenePaths())
                {
                    Debug.Log("Addressable TESTING: " + sceneName);
                }
            }
        }
        else
        {
            Debug.Log("Addressable TESTING: null temp1" );
        }
    }

    private void OnLoadedMap2(AsyncOperationHandle _obj)
    {
        if (_obj.Result is List<IAssetBundleResource> temp)
        {
            foreach (var assetBundle in temp.Select(_bundleResource => _bundleResource.GetAssetBundle()))
            {
                foreach (var assetName in assetBundle.GetAllAssetNames())
                {
                    Debug.Log("Addressable TESTING: " + assetName);
                }
                foreach (var sceneName in assetBundle.GetAllScenePaths())
                {
                    Debug.Log("Addressable TESTING: " + sceneName);
                }
            }
        }
        else
        {
            Debug.Log("Addressable TESTING: null temp2" );
        }
    }
    
    private void OnLoadedMap3(AsyncOperationHandle _obj)
    {
        if (_obj.Result is List<IAssetBundleResource> temp)
        {
            foreach (var assetBundle in temp.Select(_bundleResource => _bundleResource.GetAssetBundle()))
            {
                foreach (var assetName in assetBundle.GetAllAssetNames())
                {
                    Debug.Log("Addressable TESTING: " + assetName);
                }
                foreach (var sceneName in assetBundle.GetAllScenePaths())
                {
                    Debug.Log("Addressable TESTING: " + sceneName);
                }
            }
        }
        else
        {
            Debug.Log("Addressable TESTING: null temp3" );
        }
    }
  


    public void Map1()
    {
        StartCoroutine(LoadScene(1));
    }


    public void Map2()
    {
        StartCoroutine(LoadScene(2));
    }


    public void Map3()
    {
        StartCoroutine(LoadScene(3));
    }


    private IEnumerator LoadScene(int _level)
    {
        var op = Addressables.LoadSceneAsync("Level " + _level);
        yield return op;

        if (op.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log("Addressable TESTING: Loaded scene level " + _level);
        }
    }
}