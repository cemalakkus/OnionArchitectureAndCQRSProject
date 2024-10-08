﻿using CQRSProject.Domain.Common;

namespace CQRSProject.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
