﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Contracts.Purchase
{
    public record CreatePurchasesRequest(
        Guid ProductId,
         Guid BranchId,
         DateTime SaleDate,
        int Quantity,
        decimal Price

    );
   
}
