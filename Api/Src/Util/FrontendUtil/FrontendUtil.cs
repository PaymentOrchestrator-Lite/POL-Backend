namespace Api.Src.Util.FrontendUtil
{
    public class FrontendUtil
    {
        public static object AlertForm(string args, eAlertForm type = eAlertForm.None, bool refresh = true)
        {
            string resultArgs = args;

            switch (type)
            {
                case eAlertForm.Success:
                    resultArgs = "✅ " + args;
                    break;
                case eAlertForm.Failed:
                    resultArgs = "🛑 " + args;
                    break;
                case eAlertForm.None:
                default:
                    resultArgs = args;
                    break;
            }

            return new
            {
                alertForm = new iAlertResponseArgs
                {
                    Body = resultArgs,
                    Refresh = refresh
                }
            };
        }
    }
}