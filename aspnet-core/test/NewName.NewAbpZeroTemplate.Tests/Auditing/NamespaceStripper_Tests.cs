using NewName.NewAbpZeroTemplate.Auditing;
using NewName.NewAbpZeroTemplate.Test.Base;
using Shouldly;
using Xunit;

namespace NewName.NewAbpZeroTemplate.Tests.Auditing
{
    // ReSharper disable once InconsistentNaming
    public class NamespaceStripper_Tests: AppTestBase
    {
        private readonly INamespaceStripper _namespaceStripper;

        public NamespaceStripper_Tests()
        {
            _namespaceStripper = Resolve<INamespaceStripper>();
        }

        [Fact]
        public void Should_Stripe_Namespace()
        {
            var controllerName = _namespaceStripper.StripNameSpace("NewName.NewAbpZeroTemplate.Web.Controllers.HomeController");
            controllerName.ShouldBe("HomeController");
        }

        [Theory]
        [InlineData("NewName.NewAbpZeroTemplate.Auditing.GenericEntityService`1[[NewName.NewAbpZeroTemplate.Storage.BinaryObject, NewName.NewAbpZeroTemplate.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null]]", "GenericEntityService<BinaryObject>")]
        [InlineData("CompanyName.ProductName.Services.Base.EntityService`6[[CompanyName.ProductName.Entity.Book, CompanyName.ProductName.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null],[CompanyName.ProductName.Services.Dto.Book.CreateInput, N...", "EntityService<Book, CreateInput>")]
        [InlineData("NewName.NewAbpZeroTemplate.Auditing.XEntityService`1[NewName.NewAbpZeroTemplate.Auditing.AService`5[[NewName.NewAbpZeroTemplate.Storage.BinaryObject, NewName.NewAbpZeroTemplate.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null],[NewName.NewAbpZeroTemplate.Storage.TestObject, NewName.NewAbpZeroTemplate.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null],]]", "XEntityService<AService<BinaryObject, TestObject>>")]
        public void Should_Stripe_Generic_Namespace(string serviceName, string result)
        {
            var genericServiceName = _namespaceStripper.StripNameSpace(serviceName);
            genericServiceName.ShouldBe(result);
        }
    }
}
