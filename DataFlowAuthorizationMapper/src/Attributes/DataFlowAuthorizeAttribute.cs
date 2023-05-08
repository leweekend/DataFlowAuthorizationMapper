namespace DataFlowAuthorizationMapper.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DataFlowAuthorizeAttribute : Attribute
    {
        internal readonly string[] Roles;

        public DataFlowAuthorizeAttribute(string roles)
        {
            Roles = roles.Split(',');
        }

        internal bool IsValid(string[] userRoles)
        {
            return Roles.Intersect(userRoles).Any();
        }
    }
}
