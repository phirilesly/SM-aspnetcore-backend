﻿using ErrorOr;
using StockManager.Contracts.Product;
using StockManager.ServiceErrors;

namespace StockManager.Models
{
    public class Product
    {


        public const int MinNameLength = 3;
        public const int MaxNameLength = 50;

        public const int MinDescriptionLength = 2;
        public const int MaxDescriptionLength = 150;

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string Barcode { get; }
        public string Category { get; }
        public decimal Price { get; }
        public string Brand { get; }
        public string Supplier { get; }
     


        public Product(Guid id, string name, string description, string barcode, string category, decimal price , string brand, string supplier)
        {
            Id = id;
            Name = name;
            Description = description;
            Barcode = barcode;
            Category = category;
            Price = price;
            Brand = brand;
            Supplier = supplier;
          
        }

        public static ErrorOr<Product> Create(
            string name,
            string description,
            string barcode,
            string category,
            decimal price,
            string brand,
            string supplier,
            Guid? id = null)


        {
            List<Error> errors = new();

            if (name.Length is < MinNameLength or > MaxNameLength)
            {
                errors.Add(Errors.Product.InvalidName);
            }

            if (description.Length is < MinDescriptionLength or > MaxDescriptionLength)
            {
                errors.Add(Errors.Product.InvalidDescription);
            }

            if (errors.Count > 0)
            {
                return errors;
            }

            return new Product(
                id ?? Guid.NewGuid(),
                name,
                description,
                barcode,
                category,
                price,
                brand,
                supplier
                );
        }

        public static ErrorOr<Product> From(CreateProductRequest request)
        {
            return Create(
                request.Name,
                request.Description,
                request.Barcode,
                request.Category,
                request.Price,
                request.Brand,
                request.Supplier
              );
        }

        public static ErrorOr<Product> From(Guid id, UpsertProductRequest request)
        {
            return Create(
                request.Name,
                request.Description,
                request.Barcode,
                request.Category,
                request.Price,
                request.Brand,
                request.Supplier,
                id);
        }
    }

}
