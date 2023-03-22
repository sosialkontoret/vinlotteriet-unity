using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class SetPostProcessVolume : MonoBehaviour
{
    [SerializeField]
    private PostProcessVolume volume;
    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<PostProcessVolume>();
    }


    public void setPostProcessProfile(PostProcessProfile newProfile) {
        volume.profile = newProfile;
    }
}
