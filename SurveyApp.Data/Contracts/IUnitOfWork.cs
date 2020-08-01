using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
namespace SurveyApp.Data.Contracts
{
    public interface IUnitOfWork
    {
        int SaveChanges();       
    }
}
