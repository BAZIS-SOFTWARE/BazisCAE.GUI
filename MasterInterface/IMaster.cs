using Model.Interfaces;
using Model.Interfaces.Attributes;

namespace MasterInterface
{
    /// <summary>
    /// Интерфейс для определения мастера автоматизированной постановки задач (ICondData)
    /// </summary>
    public interface IMaster
    {
        /// <summary>
        /// Событие для вывода сообщения на главный контрол или форму, если необходимо вывести информацию для пользователя через консоль или другой способ вывода.
        /// </summary>
        event Action<string, Color> PrintInfoEvent;

        /// <summary>
        /// Событие подтвержденя завершения ввода пользователем строк для формирования граничных условий (ICondData).
        /// </summary>
        event Action<string[]> SubmintParametrizedStringsEvent;

        /// <summary>
        /// Событие для запроса обновления сцены.
        /// </summary>
        event Action UpdateSceneEvent;

        /// <summary>
        /// Имя мастера.
        /// Используется для создания необходимой инфраструктуры и обращения к нему
        /// </summary>
        string MasterName { get; }

        /// <summary>
        /// Начальное определение данных для мастера
        /// </summary>
        /// <param name="materials">Названия материалов для определения их параметров в виде строк для формирования граничных условий</param>
        /// <param name="functions">Названия функций для определения параметров процесса в виде строк для формирования граничных условий</param>
        /// <param name="groupsByObjType">Группировака групп (их имен) по типу объектов. Необходимо для создания строк связывания объектов модели и их свойств при формирования граничных условий</param>
        void InitialMasterFilling(IEnumerable<string> materials, IEnumerable<string> functions, Dictionary<ObjType, List<string>> groupsByObjType);

        /// <summary>
        /// Обработка события добавления группы. Добавление в словарь группы, после ее создания при открытом мастере.
        /// Необходимо для корректного использования новой группы в процессе создания строк для формирования граничных условий
        /// </summary>
        /// <param name="type">Тип группы</param>
        /// <param name="groupName">Имя группы</param>
        void AddGroup(ObjType type, string groupName);

        /// <summary>
        /// Обработка события переименования группы. Изменение в словаре и в сформированных строках определенной группы (переименование) при открытом мастере.
        /// Необходимо для корректного использования измененной группы в процессе создания строк для формирования граничных условий
        /// </summary>
        /// <param name="type">Тип группы</param>
        /// <param name="oldName">Старое имя группы</param>
        /// <param name="newName">Новое имя группы</param>
        void RenameGroup(ObjType type, string oldName, string newName);

        /// <summary>
        /// Обработка события удаления группы. Удаление из словаря и из сформированных строк определенной группы при открытом мастере.
        /// Необходимо для избавления от упоминаний удаленной группы в процессе создания строк для формирования граничных условий
        /// </summary>
        /// <param name="type">Тип группы</param>
        /// <param name="groupName">Имя группы</param>
        void DeleteGroup(ObjType type, string groupName);

        /// <summary>
        /// Замена названий функций для создания строк формирования граничных условий
        /// </summary>
        /// <param name="materials">Названия материалова</param>
        [Warning("Изменение набора материалов приведет к удалению уже созданных строк для формирования граничных условий")]
        void ChangeMaterials(IEnumerable<string> materials);

        /// <summary>
        /// Замена названий функций для создания строк формирования граничных условий
        /// </summary>
        /// <param name="functions">Названия функций</param>
        [Warning("Изменение набора функций приведет к удалению уже созданных строк для формирования граничных условий")]
        void ChangeFunctions(IEnumerable<string> functions);
    }
}
