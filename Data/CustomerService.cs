using KarigarBotiqueStore.Context;
using KarigarBotiqueStore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KarigarBotiqueStore.Data
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _applicationDbContext.Customers.ToListAsync();
        }

        public async Task<bool> InsertCustomer(Customer customer)
        {
            if (!ValidateCustomerModel(customer))
            {
                return false;
            }

            try
            {
                await _applicationDbContext.Customers.AddAsync(customer);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some way
                return false;
            }
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _applicationDbContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            if (!ValidateCustomerModel(customer))
            {
                return false;
            }

            try
            {
                _applicationDbContext.Customers.Update(customer);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some way
                return false;
            }
        }

        public async Task<bool> DeleteCustomer(Customer customer)
        {
            try
            {
                _applicationDbContext.Customers.Remove(customer);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some way
                return false;
            }
        }

        private bool ValidateCustomerModel(Customer customer)
        {
            var validationContext = new ValidationContext(customer, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(customer, validationContext, validationResults, validateAllProperties: true))
            {
                foreach (var validationResult in validationResults)
                {
                    // Log or handle validation errors
                }

                return false;
            }

            return true;
        }
    }
}
