using Project.Interfaces.Tasks;
using Project.TaskParameters;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI.PropertiesPanel.PhysicalSets
{
    /// <summary>
    /// Единственный источник знаний о составе физических наборов: какой набор для задачи
    /// родной, какие она может получить извне и какие величины входят в набор.
    /// В Project эта таксономия не описана, поэтому её держит графика — но в одном месте:
    /// добавление типа задачи, набора или величины затрагивает только этот класс.
    /// </summary>
    internal sealed class PhysicalSetCatalog
    {
        /// <summary>Величины, входящие в набор.</summary>
        private static readonly Dictionary<PhysicalSetName, PhysicalFieldName[]> Quantities =
            new Dictionary<PhysicalSetName, PhysicalFieldName[]>
            {
                [PhysicalSetName.Thermal] = new[]
                {
                    PhysicalFieldName.Temperature,
                    PhysicalFieldName.PhaseComposition
                },
                [PhysicalSetName.Mechanical] = new[]
                {
                    PhysicalFieldName.Displacement,
                    PhysicalFieldName.Stress,
                    PhysicalFieldName.Strain,
                    PhysicalFieldName.Temperature,
                    PhysicalFieldName.PhaseComposition
                },
                [PhysicalSetName.Hydrodynamic] = new[]
                {
                    PhysicalFieldName.Velocity,
                    PhysicalFieldName.Pressure,
                    PhysicalFieldName.Temperature
                },
                [PhysicalSetName.Chemical] = new[]
                {
                    PhysicalFieldName.Concentration,
                    PhysicalFieldName.Temperature
                }
            };

        /// <summary>Родной набор задачи и наборы, которые она получает от других задач.</summary>
        private static readonly Dictionary<TaskKind, (PhysicalSetName Native, PhysicalSetName[] Foreign)> Sets =
            new Dictionary<TaskKind, (PhysicalSetName, PhysicalSetName[])>
            {
                [TaskKind.термическая] = (PhysicalSetName.Thermal, new[]
                {
                    PhysicalSetName.Hydrodynamic,
                    PhysicalSetName.Chemical
                }),
                [TaskKind.механическая] = (PhysicalSetName.Mechanical, new[]
                {
                    PhysicalSetName.Thermal,
                    PhysicalSetName.Chemical,
                    PhysicalSetName.Hydrodynamic
                }),
                [TaskKind.химическая] = (PhysicalSetName.Chemical, new[]
                {
                    PhysicalSetName.Thermal
                })
            };

        /// <summary>
        /// Родной набор задачи или <c>null</c>, если тип задачи неизвестен каталогу.
        /// </summary>
        public PhysicalSetName? GetNativeSet(GeneralParameters parameters)
        {
            return Sets.TryGetValue(parameters.TaskKind, out var sets) ? sets.Native : (PhysicalSetName?)null;
        }

        /// <summary>
        /// Внешние наборы, которые нужно показать: объявленные для типа задачи плюс
        /// уже сохранённые в файле, чтобы настройки не пропадали из виду.
        /// </summary>
        public List<PhysicalSetName> GetInputSets(GeneralParameters parameters)
        {
            var sets = Sets.TryGetValue(parameters.TaskKind, out var declared)
                ? declared.Foreign.ToList()
                : new List<PhysicalSetName>();

            foreach (var set in parameters.InputSets ?? Enumerable.Empty<PhysicalSet>())
                if (!sets.Contains(set.Name))
                    sets.Add(set.Name);

            return sets;
        }

        /// <summary>
        /// Величины набора: объявленные каталогом плюс те, что уже есть в значениях,
        /// чтобы не потерять данные, записанные другой версией препроцессора.
        /// </summary>
        public List<PhysicalFieldName> GetQuantities(PhysicalSetName set, PhysicalSet values)
        {
            var quantities = Quantities.TryGetValue(set, out var declared)
                ? declared.ToList()
                : new List<PhysicalFieldName>();

            foreach (var group in values?.Values?.Values ?? Enumerable.Empty<List<PhysicalField>>())
                foreach (var field in group ?? Enumerable.Empty<PhysicalField>())
                    if (!quantities.Contains(field.Name))
                        quantities.Add(field.Name);

            return quantities;
        }

        /// <summary>
        /// Имена элементных групп, для которых задаются значения. Значения набора Core
        /// хранит по группам MatData, а их состав для инструкции перечислен
        /// в <see cref="GeneralParameters.ActiveConditions"/>.
        /// </summary>
        public List<string> GetGroups(GeneralParameters parameters)
        {
            var groups = new List<string>();

            foreach (var condition in parameters.ActiveConditions ?? Enumerable.Empty<ConditionReference>())
                if (condition.Kind == DataKind.Материал && !groups.Contains(condition.GroupName))
                    groups.Add(condition.GroupName);

            return groups;
        }

        /// <summary>Локализованное имя набора.</summary>
        public string GetSetHeader(PhysicalSetName set)
        {
            switch (set)
            {
                case PhysicalSetName.Thermal: return Properties.Resources.Header_comp_SetThermal;
                case PhysicalSetName.Mechanical: return Properties.Resources.Header_comp_SetMechanical;
                case PhysicalSetName.Chemical: return Properties.Resources.Header_comp_SetChemical;
                case PhysicalSetName.Hydrodynamic: return Properties.Resources.Header_comp_SetHydrodynamic;
                default: return set.ToString();
            }
        }

        /// <summary>Локализованное имя физической величины.</summary>
        public string GetQuantityHeader(PhysicalFieldName quantity)
        {
            switch (quantity)
            {
                case PhysicalFieldName.Temperature: return Properties.Resources.Header_comp_FieldTemperature;
                case PhysicalFieldName.PhaseComposition: return Properties.Resources.Header_comp_FieldPhaseComposition;
                case PhysicalFieldName.Velocity: return Properties.Resources.Header_comp_FieldVelocity;
                case PhysicalFieldName.Displacement: return Properties.Resources.Header_comp_FieldDisplacement;
                case PhysicalFieldName.Pressure: return Properties.Resources.Header_comp_FieldPressure;
                case PhysicalFieldName.Concentration: return Properties.Resources.Header_comp_FieldConcentration;
                case PhysicalFieldName.Stress: return Properties.Resources.Header_comp_FieldStress;
                case PhysicalFieldName.Strain: return Properties.Resources.Header_comp_FieldStrain;
                default: return quantity.ToString();
            }
        }
    }
}
