﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CarRentalControl(rental.CarId));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccesResult(Messages.RentalAdded);


        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccesResult(Messages.RentalDeleted);
        }

        public IResult Delete(int rentalId)
        {
            try
            {
                var rentalBul = _rentalDal.Get(r => r.RentalId == rentalId);
                if (rentalBul != null)
                {
                    _rentalDal.Delete(rentalBul);
                    return new SuccesResult(Messages.RentalDeleted);
                }
                else
                {
                    return new ErrorResult(Messages.IdError);
                }
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }


        public IResult GetRentalICarId(int carId)
        {
            var results = _rentalDal.GetAll(p => p.CarId == carId && p.ReturnDate == null || p.CarId == carId && p.ReturnDate > DateTime.Now);
            if (results.Count == 0)
            {
                return new SuccesResult();
            }
            return new ErrorResult(Messages.RentalCarIdError);
        }



        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {

            IResult result = BusinessRules.Run(RentalControl(rental.RentalId));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Update(rental);
            return new Result(true, Messages.Updated);
        }
        private IResult RentalControl(int rentalId)
        {
            var result = _rentalDal.Get(r => r.RentalId == rentalId);
            if (result == null)
            {
                return new ErrorResult("Girdiğiniz Id'ye ait şu an müsait değil");
            }
            return new SuccesResult();
        }
        public IDataResult<List<Rental>> GetRentalsById(int rentalId)
        {
            throw new NotImplementedException();
        }
        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {

            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
        private IResult CarRentalControl(int carId)
        {
            var results = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate != null && r.ReturnDate <= DateTime.Now);
            if (results.Count != 0)
            {
                var resultK = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate >DateTime.Now );
                if (resultK.Count == 0)
                {
                    return new SuccesResult();
                }
                return new ErrorResult("Bu araç henüz teslim edilmediği için kiralanamaz");
            }
            else
            {
                var resultsC = _rentalDal.GetAll(r => r.CarId == carId);
                if (resultsC.Count == 0)
                {
                    return new SuccesResult();
                }
                return new ErrorResult("Bu araç kiralandı");
            }
        }
    }
}

