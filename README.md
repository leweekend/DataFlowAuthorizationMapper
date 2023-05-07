# DataFlowAuthorizationMapper
An object to object mapper that applies role based authorization at the class property level

DataFlowAuthorizationMapper is a utility class that maps one object to another while enforcing role-based authorization at the property level. It provides a way to control which properties of an object should be exposed based on the user's role by checking against the DataFlowAuthorizeAttribute set on each property.

This mapper can be used in scenarios where you have a domain model that contains sensitive information, and you need to restrict access to certain fields based on the user's role. It can also be used when you have a persistent model that should not be updated based on authorization rules.

Overall, DataFlowAuthorizationMapper helps ensure that only authorized data is passed between objects in a secure and efficient way.


```C#
    class DomainModel
    {
        [DataFlowAuthorize("admin,superuser")]
        public string FirstName { get; set; } = null!;

        [DataFlowAuthorize("admin,superuser")]
        [MapTo("Surname")]
        public string LastName { get; set; } = null!;

        [DataFlowAuthorize("admin")]
        public string ContactNumber { get; set; } = null!;

        [DataFlowAuthorize("member")]
        public int? Age { get; set; }
    }

     var roles = new string[] { "admin" };

      var source = new DomainModel()
      {
          FirstName = "John",
          LastName = "Doe",
          ContactNumber = "000-000-000",
          Age = 30
      };

      var destination = new PersistentModel()
      {
          FirstName = "Jane",
          Surname = "Dae",        
          ContactNumber = "111-111-111",
          Age = 40
      };

      var viewModel = DataFlowAuthorizationMapper.Map(roles, domainModel, persistentModel);

      Console.WriteLine(destination.FirstName); // Outputs "John"
      Console.WriteLine(destination.Surname); // Outputs "Doe"
      Console.WriteLine(destination.ContactNumber); // Outputs "000-000-000"
      Console.WriteLine(destination.Age); // Outputs 40
````
