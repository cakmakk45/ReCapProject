using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        RentalDetailDto GetRentalDetailsByCarId(int rentalId);
        List<RentalDetailDto> GetRentalDetails();
        List<RentalDto> RentalDto();
    }
}
