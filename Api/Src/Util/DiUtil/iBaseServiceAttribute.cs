namespace Api.Src.Util.Di
{
    [AttributeUsage(AttributeTargets.Class)]
    public class iBaseServiceAttribute : Attribute
    {
        public eServiceScope Scope { get; }
        public iBaseServiceAttribute(eServiceScope scope = eServiceScope.Singleton)
        {
            Scope = scope;
        }
    }
}