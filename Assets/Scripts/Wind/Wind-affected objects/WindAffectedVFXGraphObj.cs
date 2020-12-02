using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wind;
using UnityEngine.VFX;

[RequireComponent(typeof(VisualEffect))]
public class WindAffectedVFXGraphObj : MonoBehaviour
{
    public ComputeWindField windField;
    private RenderTexture staticWindField, dynamicWindField, noiseWindField;
    private Vector3 globalWind;
    private float windFieldCellSize;
    private Vector3Int windFieldNumCells;
    private Vector3 windFieldCentre;

    private VisualEffect vfxGraph;

    void Start()
    {
        vfxGraph = GetComponent<VisualEffect>();
        Init();
    }

    //Yields one frame to ensure the connected wind field is initialised, then sets corresponding VFX Graph parameters with wind field info 
    private IEnumerator Init()
    {
        while(true)
        {
            yield return null;

            if (windField == null)
            {
                Debug.LogException(new System.NullReferenceException("Wind field passed to " + this + "is null!"));
            }
            else
            {
                vfxGraph.SetTexture("Static Wind Field", windField.GetStaticWindField());
                vfxGraph.SetTexture("Dynamic Wind Field", windField.GetDynamicWindField());
                vfxGraph.SetTexture("Noise Wind Field", windField.GetNoiseWindField());
                vfxGraph.SetVector3("Global Wind", windField.GetGlobalWind());
                //vfxGraph.SetVector3("Wind Field Centre", windFieldCentre);
                vfxGraph.SetVector3("Wind Field Size", (Vector3)windField.GetNumCells() * windField.GetCellSize());
            }
        }
    }

}
