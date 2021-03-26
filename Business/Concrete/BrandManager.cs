﻿using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            Console.WriteLine("Sistemden " + brand.BrandId + " numaralı " + brand.BrandName + " marka araç bilgisi eklendi.");
            return new Result(true, Messages.BrandAdded);
       
        }
        [SecuredOperation("admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IBrandService.Get")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(int brandId)
        {
            try
            {
                var brandBul = _brandDal.Get(b => b.BrandId == brandId);
                if (brandBul != null)
                {
                    _brandDal.Delete(brandBul);
                    return new SuccesResult(Messages.BrandDeleted);
                }
                else
                {
                    return new ErrorResult(Messages.IdError);
                }
            }
            catch
            {
                return new ErrorResult(Messages.IdError);
            }
        }
        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
        }
        [CacheAspect]
        public IDataResult<List<Brand>>GetById(int brandId)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandId == brandId));

        }
        [ValidationAspect(typeof(BrandValidator))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
          
            _brandDal.Update(brand);
            return new Result(true, Messages.BrandUpdated);
        }
    }
}
