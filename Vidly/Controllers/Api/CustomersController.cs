using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOS;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private DataContext _context;
        public CustomersController()
        {
            _context = new DataContext();
        }

        //Get //api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }

        // Get //api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null) return NotFound();
            return Ok(Mapper.Map<Customer,CustomerDto>( customer));
        }

        //Post //api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid) return BadRequest(); //throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/"+customer.Id),customerDto);
        }

        //Put /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            var _customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(_customerInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map<CustomerDto, Customer>(customerDto,_customerInDb);
            _customerInDb.Name = customerDto.Name;
            _customerInDb.IsSubScribedToNewsLetter= customerDto.IsSubScribedToNewsLetter;
            _customerInDb.MembershipTypeId= customerDto.MembershipTypeId;
            _context.SaveChanges();
        }

        //Delete /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var _customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (_customerInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(_customerInDb);
            _context.SaveChanges();
        }
    }
}
