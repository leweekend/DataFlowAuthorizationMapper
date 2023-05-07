# DataFlowAuthorizationMapper
An object to object mapper that applies role based authorization at the class property level

DataFlowAuthorizationMapper is a utility class that maps one object to another while enforcing role-based authorization at the property level. It provides a way to control which properties of an object should be exposed based on the user's role by checking against the DataFlowAuthorizeAttribute set on each property.

This mapper can be used in scenarios where you have a domain model that contains sensitive information, and you need to restrict access to certain fields based on the user's role. It can also be used when you have a persistent model that should not be updated based on authorization rules.

Overall, DataFlowAuthorizationMapper helps ensure that only authorized data is passed between objects in a secure and efficient way.
