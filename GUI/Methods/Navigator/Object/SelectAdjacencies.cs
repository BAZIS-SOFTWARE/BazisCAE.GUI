using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private List<(ISetInfo, List<int> Numbers)> SelectAdj(int dim, int number)
        {
            var (upperLevel, lowerLevel) = GmshController.Gmsh.Model.GetAdjacencies(dim, number);
            var dimUp = dim + 1;
            var dimLow = dim - 1;
            var adgTypeUp = (ObjType)dimUp;
            var adgTypeLow = (ObjType)dimLow;
            List<(ISetInfo, List<int> Numbers)> sets = new List<(ISetInfo, List<int> Numbers)>();
            var setU = project.GetModelSetInfo(adgTypeUp, adgTypeUp.ToString());
            if(setU != null)
            {
                List<int> numbers = new List<int>();
                foreach (var set in setU.GetNumbers())
                    if (Array.Exists(upperLevel, x => x == set))
                        numbers.Add(set);
                
                sets.Add((setU, numbers));
            }

            var setL = project.GetModelSetInfo(adgTypeLow, adgTypeLow.ToString());
            if(setL != null)
            {
                List<int> numbers = new List<int>();

                foreach (var set in setL.GetNumbers())
                    if (Array.Exists(lowerLevel, x => x == set))
                        numbers.Add(set);
                sets.Add((setL, numbers));
            }

            return sets;
        }


        private (ISetInfo Set, List<int> Numbers) GetFilteredSet(int dim, int[] adjNumbers)
        {
            var setInfo = project.GetModelSetInfo((ObjType)dim, ((ObjType)dim).ToString());
            if (setInfo == null) return (null, new List<int>());

            var adjSet = new HashSet<int>(adjNumbers);
            var numbers = setInfo.GetNumbers().Where(n => adjSet.Contains(n)).ToList();

            return (setInfo, numbers);
        }
    }
}
