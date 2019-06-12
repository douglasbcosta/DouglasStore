using System;
using System.Collections.Generic;
using DouglasStore.Domain.StoreContext.CustomerCommands.Inputs;
using DouglasStore.Domain.StoreContext.Entities;
using DouglasStore.Domain.StoreContext.Handlers;
using DouglasStore.Domain.StoreContext.Queries;
using DouglasStore.Domain.StoreContext.Repositories;
using DouglasStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace  DouglasStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;
        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }
        [HttpGet]
        [Route("v1/customers")]        
        public IEnumerable<ListCustomerQueryResult> Get(){
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/customers/{id}")]        
        public GetCustomerQueryResult GetById(Guid id){
            return _repository.GetById(id);
        }

        [HttpGet]
        [Route("v1/customers/{id}/orders")]        
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id){
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/customers")]
        public object Post([FromBody]CreateCustomerCommand command){
            var result = (CreateCustomerCommand)_handler.Handle(command);
            if(_handler.Invalid)
                return BadRequest(_handler.Notifications);
            return result;
        }

        [HttpPut]
        [Route("v1/customers/{id}")]
        public Customer Put([FromBody]CreateCustomerCommand command){
            
            Name name = new Name(command.FirstName,command.LastName);
            Document document = new Document(command.Document);
            Email email = new Email(command.Email);
            Customer customer = new Customer(name, document,email, command.Phone);
            return customer;
        }

        [HttpDelete]
        [Route("v1/customers/{id}")]
        public object Delete(Guid id){
            return new {message = "Cliente removido com sucesso"};
        }

        [HttpGet]
        [Route("v2/customers/{id}")]        
        public GetCustomerQueryResult GetByDocument(string document){
            return _repository.GetByDocument(document);
        }

    }
}