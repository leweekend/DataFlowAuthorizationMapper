namespace DataFlowAuthorizationMapper.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class MapToAttribute : Attribute
    {
        internal string SourcePropertyName { get; set; }

        public MapToAttribute(string sourcePropertyName)
        {
            SourcePropertyName = sourcePropertyName;
        }
    }
}