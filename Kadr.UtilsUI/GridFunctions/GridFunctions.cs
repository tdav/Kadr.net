using DevExpress.Data;

namespace Kadr.UtilsUI.GridFunctions
{
    public class GridColunmConfigItem
    {
        public int ColIndex { get; set; }
        public string Name { get; set; }
        public string FieldName { get; set; }
        public string DisplayName { get; set; }
        public bool IsGroups { get; set; }
        public bool IsAgrs { get; set; }
        public int Width { get; set; }
        public string DateType { get; set; }
        public bool Visible { get; set; }
        public SummaryItemType SumType { get; set; }
    }
}
