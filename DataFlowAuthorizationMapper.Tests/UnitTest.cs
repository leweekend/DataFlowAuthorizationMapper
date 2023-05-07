using DataFlowAuthorizationMapper.Tests.Models;

namespace DataFlowAuthorizationMapper.Tests
{
    public class UnitTest
    {
        [Fact]
        public void TestMap_DomainModelToViewModel_WithAuthorization_Admin()
        {
            var expectedFirstName = "John";
            var expectedLastName = "Doe";

            var roles = new string[] { "admin" };

            DomainModel domainModel = new()
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30
            };

            var viewModel = DataFlowAuthorizationMapper.Map<DomainModel, ViewModel>(roles, domainModel);

            Assert.NotNull(viewModel);
            Assert.Equal(expectedFirstName, viewModel.FirstName);
            Assert.Equal(expectedLastName, viewModel.Surname);
            Assert.Null(viewModel.Age);
        }

        [Fact]
        public void TestMap_DomainModelToViewModel_WithAuthorization_SuperUser()
        {
            var expectedFirstName = "John";
            var expectedLastName = "Doe";

            var roles = new string[] { "superuser" };

            DomainModel domainModel = new()
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30
            };

            var viewModel = DataFlowAuthorizationMapper.Map<DomainModel, ViewModel>(roles, domainModel);

            Assert.NotNull(viewModel);
            Assert.Equal(expectedFirstName, viewModel.FirstName);
            Assert.Equal(expectedLastName, viewModel.Surname);
            Assert.Null(viewModel.Age);
        }

        [Fact]
        public void TestMap_DomainModelToViewModel_WithAuthorization_Member()
        {
            var expectedAge = 30;

            var roles = new string[] { "member" };

            DomainModel domainModel = new()
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30
            };

            var viewModel = DataFlowAuthorizationMapper.Map<DomainModel, ViewModel>(roles, domainModel);

            Assert.NotNull(viewModel);
            Assert.Equal(expectedAge, viewModel.Age);
        }

        [Fact]
        public void TestMap_DomainModelToPersistentModel_WithAuthorization_Admin()
        {
            var expectedFirstName = "John";
            var expectedLastName = "Doe";
            var expectedAge = 40;

            var roles = new string[] { "admin" };

            DomainModel domainModel = new()
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30
            };

            PersistentModel persistentModel = new()
            {
                FirstName = "Jane",
                Surname = "Dae",
                Age = 40
            };

            var viewModel = DataFlowAuthorizationMapper.Map(roles, domainModel, persistentModel);

            Assert.NotNull(viewModel);
            Assert.Equal(expectedFirstName, viewModel.FirstName);
            Assert.Equal(expectedLastName, viewModel.Surname);
            Assert.Equal(expectedAge, viewModel.Age);
        }

        [Fact]
        public void TestMap_DomainModelToPersistentModel_WithAuthorization_SuperUser()
        {
            var expectedFirstName = "John";
            var expectedLastName = "Doe";
            var expectedAge = 40;

            var roles = new string[] { "superuser" };

            DomainModel domainModel = new()
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30
            };

            PersistentModel persistentModel = new()
            {
                FirstName = "Jane",
                Surname = "Dae",
                Age = 40
            };

            var viewModel = DataFlowAuthorizationMapper.Map(roles, domainModel, persistentModel);

            Assert.NotNull(viewModel);
            Assert.Equal(expectedFirstName, viewModel.FirstName);
            Assert.Equal(expectedLastName, viewModel.Surname);
            Assert.Equal(expectedAge, viewModel.Age);
        }

        [Fact]
        public void TestMap_DomainModelToPersistentModel_WithAuthorization_Member()
        {
            var expectedFirstName = "Jane";
            var expectedLastName = "Dae";
            var expectedAge = 30;

            var roles = new string[] { "member" };

            DomainModel domainModel = new()
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30
            };

            PersistentModel persistentModel = new()
            {
                FirstName = "Jane",
                Surname = "Dae",
                Age = 40
            };

            var viewModel = DataFlowAuthorizationMapper.Map(roles, domainModel, persistentModel);

            Assert.NotNull(viewModel);
            Assert.Equal(expectedFirstName, viewModel.FirstName);
            Assert.Equal(expectedLastName, viewModel.Surname);
            Assert.Equal(expectedAge, viewModel.Age);
        }
    }
}