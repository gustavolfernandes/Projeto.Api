using Projeto.Domain;
using System;
using Xunit;
using FluentAssertions;

namespace Projeto.Tests
{
    public class ProductTests
    {
        [Fact]
        public void EntityTest()
        {
            ProductId productId = Guid.NewGuid().ToType<ProductId>();
            Product entity = new(productId, "Lorem ipsum...");
            entity.Id.Should().Be(productId);
            entity.Name.Should().Be("Lorem ipsum...");

            entity.Update("Lorem ipsum");
            entity.Name.Should().Be("Lorem ipsum");
        }
    }
}