using MyStore.Application.DTOs;
using MyStore.Application.Interfaces;
using MyStore.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Application.Services
{
    public class ProductService(IProductRepository _repo, IFileStorageService _fileStorageService)
    {
        public async Task<IEnumerable<ProductDTO>> GetAsync()
        {
            var products = await _repo.GetAsync();
            return products.Select(e => new ProductDTO(
                ProductId: e.ProductId,
                SKU: e.SKU,
                Name: e.Name,
                Stock: e.Stock,
                Price: e.Price,
                SourceImage: e.SourceImage
                ));
        }

        public async Task<IEnumerable<ProductDTO>> GetByParameterAsync(string parameter)
        {
            var products = await _repo.GetAsync();
            return products.Select(e => new ProductDTO(
                ProductId: e.ProductId,
                SKU: e.SKU,
                Name: e.Name,
                Stock: e.Stock,
                Price: e.Price,
                SourceImage: e.SourceImage
                ));
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            if (id == 0) throw new ValidationException("Product Id is required");

            var product = await _repo.GetByIdAsync(id);

            if (product is null) throw new ValidationException("Product not found");

            return new ProductDTO(
                ProductId: product.ProductId,
                SKU: product.SKU,
                Name: product.Name,
                Stock: product.Stock,
                Price: product.Price,
                SourceImage: product.SourceImage
            );
        }

        public async Task AddAsync(CreateProductDTO product)
        {
            if (string.IsNullOrEmpty(product.SKU)) throw new ValidationException("SKU is required");
            if (string.IsNullOrEmpty(product.Name)) throw new ValidationException("Product name is required");

            var SourceImage = "";

            if (product.ImageStream != null && !string.IsNullOrEmpty(product.ImageFileName)) {
                SourceImage = await _fileStorageService.SaveImageAsync(product.ImageStream, product.ImageFileName);
            }
            
            var newProduct = new Product
            {
                SKU = product.SKU,
                Name = product.Name,
                Stock = product.Stock,
                Price = product.Price,
                SourceImage = SourceImage
            };

            await _repo.AddAsync(newProduct);
        }

        public async Task UpdateAsync(UpdateProductDTO product)
        {
            if (product.ProductId == 0) throw new ValidationException("Product Id is required");
            if (string.IsNullOrEmpty(product.SKU)) throw new ValidationException("SKU is required");
            if (string.IsNullOrEmpty(product.Name)) throw new ValidationException("Product name is required");

            var existingProduct = await _repo.GetByIdAsync(product.ProductId);

            if (existingProduct is null) throw new ValidationException("Product not found");

            if (existingProduct.SKU != product.SKU)
                existingProduct.SKU = product.SKU;

            if (existingProduct.Name != product.Name)
                existingProduct.Name = product.Name;

            if (existingProduct.Stock != product.Stock)
                existingProduct.Stock = product.Stock;

            if (existingProduct.Price != product.Price)
                existingProduct.Price = product.Price;

            if (product.ImageStream != null && !string.IsNullOrEmpty(product.ImageFileName))
            {
                var SourceImage = "";
                SourceImage = await _fileStorageService.SaveImageAsync(product.ImageStream, product.ImageFileName);

                if (!string.IsNullOrEmpty(existingProduct.SourceImage))
                {
                    await _fileStorageService.DeleteImageAsync(existingProduct.SourceImage);
                }

                existingProduct.SourceImage = SourceImage;
            }

            await _repo.EditAsync(existingProduct);
        }

        public async Task DeleteAsync(int Id)
        {
            if (Id == 0) throw new ValidationException("Product Id is required");


            var product = await _repo.GetByIdAsync(Id);

            if (product is null) throw new ValidationException("Product not found");

            if (!string.IsNullOrEmpty(product.SourceImage))
            {
                await _fileStorageService.DeleteImageAsync(product.SourceImage);
            }

            await _repo.DeleteAsync(Id);
        }
    }
}
