﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Delete(int userId);
        IResult Update(Customer customer);
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetCustomersById(int userId);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
    }
}
