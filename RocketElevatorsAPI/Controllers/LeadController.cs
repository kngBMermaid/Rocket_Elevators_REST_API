using System;
using System.Xml;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RocketElevatorsAPI.Models;
using RocketElevatorsAPI.Data;

namespace RocketElevatorsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        // Context
        private readonly RocketElevatorsContext _context;

        public LeadController(RocketElevatorsContext context)
        {
            _context = context;

        }

        // Get full list of leads                                    
        // https://localhost:5000/api/lead/all
        // GET: api/lead/all           
        [HttpGet("all")]
        public IEnumerable<Lead> GetLeads()
        {
            IQueryable<Lead> leads =
            from lead in _context.Leads
            select lead;
            return leads.ToList();

        }

        // Retrieve list of Leads created in the last 30 days who have not yet become customers                                                      
        // https://localhost:5000/api/lead/noncustomers
        // GET: api/lead/noncustomers         
        [HttpGet("noncustomers")]
        public IEnumerable<Lead> GetNonCustomers()
        {
            IQueryable<Lead> nonCustomers = 
            from lead in _context.Leads
            where !(from customer in _context.Customers
                    select customer.EmailCompanyContact).Contains(lead.Email)
                    && lead.CreatedAt >= DateTime.UtcNow.AddDays(-30)
            select lead;
            return nonCustomers.ToList();

            /*lead.CreatedAt >= System.DateTime.Now.AddDays(-30)
            select lead;
            return nonCustomers.ToList();

            /*
            IEnumerable<Customer> customers = _context.Customers;

            var nonCustomers = leads.Where(lead => lead.CreatedAt >= System.DateTime.UtcNow.AddDays(-30) && lead.Email != customers.);
            return nonCustomers.ToList();
            */



            /*
            from lead in _context.Leads
            where !(from customer in _context.Customers
                    select customer.EmailCompanyContact).Contains(lead.Email)
            select lead;
            return nonCustomers.ToList();

            /*lead.CreatedAt >= System.DateTime.Now.AddDays(-30)
            select lead;
            return nonCustomers.ToList();
            */
        }

        /*
            where !(from c in _context.Customers select c.UserId).Contains(lead.UserId)
            // the last 30 days
            && lead.CreatedAt >= DateTime.UtcNow.AddDays(-30)
            select lead;

            return Leads.ToList();

            IEnumerable<Leads> Leads =
            from lead in _context.Leads
                // we select all the leads made it by non customers 
            where !(from c in _context.Customers select c.UserId).Contains(lead.UserId)
            // the last 30 days
            && lead.CreatedAt >= DateTime.UtcNow.AddDays(-30)
            select lead;

            return Leads.ToList();
        */
    }
}