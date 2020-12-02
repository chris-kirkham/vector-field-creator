using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Wind
{
    [RequireComponent(typeof(WindProducer))]
    [ExecuteAlways]
    public class WindVis_WindProducer : WindVis
    {
        private WindProducer windProducer;

        protected override void OnEnable()
        {
            windProducer = GetComponent<WindProducer>();
            base.OnEnable();
        }

        private void OnDrawGizmos()
        {
            if(displayWindArrows) DrawWindPoints(windProducer.GetWindFieldPointsBuffer());
        }
    }
}