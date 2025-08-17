namespace Api.Src.Util.FrontendUtil
{
    public enum eAlertForm
    {
        None,
        Success,
        Failed
    }

    public class iAlertResponseArgs
    {
        public string Body { get; set; } = string.Empty;
        public bool Refresh { get; set; } = true;
    }
}