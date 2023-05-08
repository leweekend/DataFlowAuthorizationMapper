namespace DataFlowAuthorizationMapper.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class MapToAttribute : Attribute
    {
        internal string PropertyName { get; set; }

        public MapToAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}