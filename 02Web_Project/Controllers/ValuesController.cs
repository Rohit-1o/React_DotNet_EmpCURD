using _02Web_Project.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _02Web_Project.Controllers
{
    [EnableCors(PolicyName ="fispl")]
    [Route("api/[controller]")] //  /api/Values
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly EmpDbContext _dbContext;

        public ValuesController(EmpDbContext context)
        {
            _dbContext = context;
        }

        #region Simple WebApi Demo
        //[HttpGet]
        //public string GetName()
        //{
        //    return "Hugh Jackman";
        //}
        //[HttpGet]
        //public string[] GetNames()
        //{
        //    return new string[] { "Hugh Jackman","Peter Parker", "MJ"};
        //} 
        #endregion

        [HttpGet]
        public List<Emp> GetAllEmps()
        {
            var emps = _dbContext.Emps.OrderBy(e => e.Id).ToList();
            return emps;
        }

        private int GetNextAvailableId()
        {
            var ids = _dbContext.Emps.OrderBy(e => e.Id).Select(e => e.Id).ToList();
            int nextId = 1;
            foreach (var id in ids)
            {
                if (id == nextId)
                {
                    nextId++;
                }
                else if (id > nextId)
                {
                    break;
                }
            }

            return nextId;
        }

        [HttpPost]  // POST : /api/Values
        public void Post(Emp emp)
        {
            emp.Id = GetNextAvailableId();

            using var transaction = _dbContext.Database.BeginTransaction();
            _dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Emp ON");
            _dbContext.Emps.Add(emp);
            _dbContext.SaveChanges();
            _dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Emp OFF");
            transaction.Commit();
        }

        [HttpPut("{id}")] //Put : /api/Values/id
        public void Put(int id,Emp emp)
        {
            Emp e = _dbContext.Emps.Find(id);
            e.Name = emp.Name;
            e.Address = emp.Address;
            _dbContext.SaveChanges();
        }

        [HttpDelete("{id}")] //Put : /api/Values/id
        public void Delete(int id)
        {
            Emp e = _dbContext.Emps.Find(id);
            _dbContext.Emps.Remove(e);
            _dbContext.SaveChanges();
        }
    }
}
