using MyStore.Application.DTOs;
using MyStore.Application.Interfaces;
using MyStore.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Application.Services
{
    public class SaleService (ISaleRepository _repo)
    {
        public async Task<IEnumerable<SaleDTO>> GetAsync(DateOnly startDate, DateOnly endDate)
        {
            var sales = await _repo.GetAsync(startDate, endDate);

            return sales.Select(e => new SaleDTO(
                SaleId: e.SaleId,
                UserName: e.User.FullName,
                TotalAmount: e.TotalAmount,
                SaleDate: e.CreatedAt.ToString("dd/MM/yyyy")
                ));
        }

        public async Task<SaleDTO> GetByIdAsync(int id)
        {
            if (id == 0) throw new ValidationException("Sale id is required");

            var sale = await _repo.GetByIdAsync(id);

            if(sale == null) throw new ValidationException("Sale not found")


            return new SaleDTO(
                SaleId: sale.SaleId,
                UserName: sale.User.FullName,
                TotalAmount: sale.TotalAmount,
                SaleDate: sale.CreatedAt.ToString("dd/MM/yyyy"),
                SaleDetail: sale.SaleDetails.Select( d=> new SaleDetailDTO(
                    ProductName: d.Product.Name,
                    ProductPrice: d.Product.Price,
                    Quantity: d.Quantity,
                    SubTotal: d.SubTotal
                    ))
                );
        }

        public async Task AddAsync(CreateSaleDTO sale)
        {
            if (sale.UserId == 0) throw new ValidationException("User id is required");
            if (!sale.SaleDetails.Any()) throw new ValidationException("Products is required");

            var newSale = new Sale
            {
                UserId = sale.UserId,
                TotalAmount = sale.TotalAmount,
                SaleDetails = sale.SaleDetails.Select(d => new SaleDetail
                {
                    ProductId = d.ProductId,
                    Quantity = d.Quantity,
                    SubTotal = d.SubTotal
                }).ToList()
            };

            await _repo.AddAsync(newSale);
        }
    }
}
