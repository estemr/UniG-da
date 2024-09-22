using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TTS.Data.UnitOfWorks;
using TTS.Entity.DTOs.CevreselIzleme.Fields;
using TTS.Entity.DTOs.Market.Products;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Entity.Entities.Market;
using TTS.Service.Extensions;
using TTS.Service.Services.Abstractions;

namespace TTS.Service.Services.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ClaimsPrincipal _user;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task CreateProductAsync(ProductAddDto productAddDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            Product product = new(productAddDto.Name, productAddDto.Price, productAddDto.Unit, userEmail);
            await unitOfWork.GetRepository<Product>().AddAsync(product);
            await unitOfWork.SaveAsync();
        }
        public async Task<List<ProductDto>> GetAllProductsDeletedAsync()
        {
            var products = await unitOfWork.GetRepository<Product>().GetAllAsync(x => x.IsDeleted);
            var map = mapper.Map<List<ProductDto>>(products);

            return map;
        }

        public async Task<List<ProductDto>> GetAllProductsNonDeletedAsync()
        {
            var products = await unitOfWork.GetRepository<Product>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<ProductDto>>(products);

            return map;
        }

        public async Task<List<ProductDto>> GetAllProductsWithUserNonDeletedAsync()
        {
            var userEmail = _user.GetLoggedInEmail();
            var products = await unitOfWork.GetRepository<Product>().GetAllAsync(x => !x.IsDeleted && x.CreatedBy == userEmail);
            var map = mapper.Map<List<ProductDto>>(products);

            return map;
        }

        public async Task<Product> GetProductByGuidAsync(Guid id)
        {
            var product = await unitOfWork.GetRepository<Product>().GetByGuidAsync(id);
            return product;
        }

        public async Task<string> SafeDeleteProductAsync(Guid productId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var product = await unitOfWork.GetRepository<Product>().GetByGuidAsync(productId);

            product.IsDeleted = true;
            product.DeletedDate = DateTime.Now;
            product.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();

            return product.Name;
        }

        public async Task<string> UndoDeleteProductAsync(Guid productId)
        {
            var product = await unitOfWork.GetRepository<Product>().GetByGuidAsync(productId);

            product.IsDeleted = false;
            product.DeletedDate = null;
            product.DeletedBy = null;

            await unitOfWork.GetRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();

            return product.Name;
        }

        public async Task<string> UpdateProductAsync(ProductUpdateDto productUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            var product = await unitOfWork.GetRepository<Product>().GetAsync(x => !x.IsDeleted && x.Id == productUpdateDto.Id);

            product.Name = productUpdateDto.Name;
            product.Price = productUpdateDto.Price;
            product.Unit = productUpdateDto.Unit;
            product.ModifiedBy = userEmail;
            product.ModifiedDate = DateTime.Now;

            await unitOfWork.GetRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();

            return product.Name;
        }
    }
}
