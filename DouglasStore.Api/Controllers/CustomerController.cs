using System;
using System.Collections.Generic;
using DouglasStore.Domain.StoreContext.CustomerCommands.Inputs;
using DouglasStore.Domain.StoreContext.Entities;
using DouglasStore.Domain.StoreContext.Handlers;
using DouglasStore.Domain.StoreContext.Queries;
using DouglasStore.Domain.StoreContext.Repositories;
using DouglasStore.Domain.StoreContext.ValueObjects;
using DouglasStore.Shared.Commands;
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
        [ResponseCache(Location = ResponseCacheLocation.Client ,Duration = 60)]  
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
        public ICommandResult Post([FromBody]CreateCustomerCommand command){
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("v1/customers/{id}")]
        public ICommandResult Put([FromBody]UpdateCustomerCommand command){
            
            var result = (UpdateCustomerCommandResult)_handler.Handle(command);
            return result;
        }

        [HttpDelete]
        [Route("v1/customers/{id}")] 
        public ICommandResult Delete([FromBody]DeleteCustomerCommand command){
            var result = (DeleteCustomerCommandResult)_handler.Handle(command);
            return result;
        }

        [HttpGet]
        [Route("v2/customers/{id}")]        
        public GetCustomerQueryResult GetByDocument(string document){
            return _repository.GetByDocument(document);
        }

    }
} 