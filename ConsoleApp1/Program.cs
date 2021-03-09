using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Zoomtel.Entity;
using Zoomtel.Entity.Test;
using Zoomtel.Persist;
using Zoomtel.PersistComm;

using EFCoreRepository.Extensions;
using FluentValidation;
using FluentValidation.Results;

namespace ConsoleApp1
{

    public interface Logger
    {
        void info(string msg);
    }

    public class logger1 : Logger
    {
        public void info(string msg)
        {
            Console.WriteLine("logg1:"+msg);        }
    }

    public class logger2 : Logger
    {
        public void info(string msg)
        {
            Console.WriteLine("logg2:" + msg);
        }
    }

    public interface IOperation
    {
        Guid OperationId { get; }
    }
    public interface IOperationSingleton : IOperation { }
    public interface IOperationTransient : IOperation { }
    public interface IOperationScoped : IOperation { }
    public class Operation :
  IOperationSingleton,
  IOperationTransient,
  IOperationScoped
    {
        private Guid _guid;

        public Operation()
        {
            _guid = Guid.NewGuid();
        }
        public Guid OperationId {
            get
            {
              return  _guid;
            }
        }
    }

    public abstract class testAb
    {


    }

    public class test2:testAb
    {


    }
    class Program
    {

        public class Customer
        {
            public int Id { get; set; }
            public string Surname { get; set; }
            public string Forename { get; set; }
            public decimal Discount { get; set; }
            public string Address { get; set; }
        }

        public class CustomerValidator : AbstractValidator<Customer>
        {
            public CustomerValidator()
            {
                RuleFor(customer => customer.Surname).NotNull();
            }
        }

        static void Main(string[] args)
        {

            //Customer customer = new Customer();
            //CustomerValidator validator = new CustomerValidator();

            //ValidationResult results = validator.Validate(customer);
            //if (!results.IsValid)
            //{
            //    foreach (var failure in results.Errors)
            //    {
            //        Console.WriteLine("Property " + failure.PropertyName + " Error was: " + failure.ErrorMessage);
            //    }
            //}
            //Console.ReadKey();


            EFCoreRepository.DbContexts.DefaultDbContext db = new EFCoreRepository.DbContexts.DefaultDbContext((options =>
              options.UseSqlServer("Data Source=192.168.3.18;Initial Catalog=zoomtel;User ID=sa;Password=sasa;")));
           
            //object o = db.ExecuteScalar("SELECT NEXT VALUE FOR TestSeq");


            using (var ts = db.Database.BeginTransaction())
            {
                var dbset = db.Set<Zoomtel.Entity.Test.T1Entity>();
             
               
                EFCoreRepository.Repositories.RepositoryAb<Zoomtel.Entity.Test.T1Entity> AB = new EFCoreRepository.Repositories.RepositoryAb<T1Entity>(db);
                AB.SoftDelete(11);

                db.SaveChanges();
         
                ts.Commit();
            }

            Console.ReadKey();
            


        }
    }
}
