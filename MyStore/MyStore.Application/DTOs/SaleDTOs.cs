using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Application.DTOs
{
    public record SaleDTO(int SaleId, string UserName, decimal TotalAmount, string SaleDate, IEnumerable<SaleDetailDTO>? SaleDetail = null);

    public record SaleDetailDTO(string ProductName, decimal ProductPrice, int Quantity, decimal SubTotal);

    public record CreateSaleDTO(int UserId, decimal TotalAmount, IEnumerable<CreateSaleDetailDTO> SaleDetails);

    public record CreateSaleDetailDTO(int ProductId, int Quantity, decimal SubTotal);

}
