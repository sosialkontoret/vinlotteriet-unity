using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxSetter : MonoBehaviour
{
    public Material[] skyboxList;
    public int skyboxIndexOnStart;

    public void Start()
    {
        setSkyboxMaterial(skyboxIndexOnStart);
    }

    public void setSkyboxMaterial(int index)
    {
        RenderSettings.skybox = skyboxList[index];
    }
}
