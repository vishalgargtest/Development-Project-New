using NSubstitute;
using NUnit.Framework;
using Sparcpoint.BusinessLayer.Product;
using Sparcpoint.DataLayer.Repository;
using Sparcpoint.Mappers.DomainToEntity;
using Sparcpoint.Models;
using Sparcpoint.Models.DomainDto.Product;
using System.Threading.Tasks;
using Xunit;

namespace Sparcpoint.Tests
{
    public class ProductManagerTest
    {
        
        [Trait("TestCategory", "Unit")]
        [Test]
        public async Task AddProduct()
        {
            IProductRepository productRepository = Substitute.For<IProductRepository>();
            ProductDto productDto = Substitute.For<ProductDto>();
            ProductManager productManager = new ProductManager(productRepository);
            productRepository.AddProduct(Arg.Any<Products>()).Returns(new Products() {Description = "Test Product",Name = "Test" });
            var result  = await productManager.AddProduct(ProductEntityMapper.MapDTOtoDomain(productDto)).ConfigureAwait(false);
            Assert.IsNotNull(result);
        }
    }
}