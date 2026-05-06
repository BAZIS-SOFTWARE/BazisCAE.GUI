using BazisGUI.Properties;
using BazisGUI.PropertiesPanel;
using BazisGUI.Utilities;
using GmshApi;
using Model.GeometryObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        enum VolumePropertyKeys { Number, MeshType, TransitionGradientDegree, LayerThickness, SurfaceElementsSize, CenterElementsSize }
        private List<RowProperty> GetVolProperties(int number)
        {
            var rows = new List<RowProperty>();
            rows.Add(new RowProperty(VolumePropertyKeys.Number.ToString(), Resources.Header_volume_number, number));

            var attributes = GmshController.GetTransfiniteVolume(number);
            var meshTypes = new List<string>() { "*", "градиентная", "регулярная" };


            if (attributes.Length == 0)
                rows.Add(new RowProperty(VolumePropertyKeys.MeshType.ToString(), 
                    Resources.Header_volume_meshType,
                    new DropDownPropertyValue("*", meshTypes)));
            else
            {
                rows.Add(new RowProperty(VolumePropertyKeys.MeshType.ToString(),
                    Resources.Header_volume_meshType,
                    new DropDownPropertyValue(attributes[0], meshTypes)));
                if (attributes[0] == meshTypes[1])
                {
                    rows.Add(new RowProperty(VolumePropertyKeys.TransitionGradientDegree.ToString(),
                        Resources.Header_volume_TransitionGradientDegree,
                        attributes[1]));

                    rows.Add(new RowProperty(VolumePropertyKeys.LayerThickness.ToString(),
                        Resources.Header_volume_layerThickness,
                        attributes[2]));

                    rows.Add(new RowProperty(VolumePropertyKeys.SurfaceElementsSize.ToString(),
                        Resources.Header_volume_surfaceElementsSize,
                        attributes[3]));

                    rows.Add(new RowProperty(VolumePropertyKeys.CenterElementsSize.ToString(),
                        Resources.Header_volume_centerElementsSize,
                        attributes[4]));
                }
            }
            
            return rows;
        }      
    }
}
