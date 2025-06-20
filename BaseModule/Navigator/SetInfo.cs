using System.Collections.Generic;

namespace BaseModule.Navigator
{
    public class SetInfo
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ObjType
        /// </summary>
        public NodeType NodeType { get; set; }
        /// <summary>
        /// Count
        /// </summary>
        public int NumberOfObjects { get; set; }
        /// <summary>
        /// ObjectsData
        /// </summary>
        public IEnumerable<string> ObjectsData { get; set; } 
    }
}