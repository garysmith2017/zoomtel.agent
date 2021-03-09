namespace Zoomtel.Auth
{
    /// <summary>
    /// 权限树模型
    /// </summary>
    public class PermissionTreeModel
    {
        public string Label { get; set; }

        public string Code { get; set; }

        public bool IsPermission { get; set; }

        public bool IsPage { get; set; }
    }
}
