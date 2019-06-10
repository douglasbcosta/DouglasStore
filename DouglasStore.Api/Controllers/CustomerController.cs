using System;
using System.Collections.Generic;
using DouglasStore.Domain.StoreContext.CustomerCommands.Inputs;
using DouglasStore.Domain.StoreContext.Entities;
using DouglasStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace  DouglasStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]        
        public List<Customer> Get(){
            Name name = new Name("Douglas","Costa");
            Document document = new Document("28659170377");
            Email email = new Email("teste@teste.com");
            Customer customer = new Customer(name, document,email, "24578913");
            List<Customer> customers = new List<Customer>();
            customers.Add(customer);
            return customers;
        }

        [HttpGet]
        [Route("customers/{id}")]        
        public Customer GetById(Guid id){
            Name name = new Name("Douglas","Costa");
            Document document = new Document("28659170377");
            Email email = new Email("teste@teste.com");
            Customer customer = new Customer(name, document,email, "24578913");
            return customer;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]        
        public List<Order> GetOrders(Guid id){
            Name name = new Name("Douglas","Costa");
            Document document = new Document("28659170377");
            Email email = new Email("teste@teste.com");
            Customer customer = new Customer(name, document,email, "24578913");
            Order order = new Order(customer);
            Product mouse = new Product("Mouse gamer","Mouse gamer", "mouse.jpg", 99M, 10);
            Product monitor = new Product("Monitor","Mouse gamer", "mouse.jpg", 99M, 10);
            order.AddItem(mouse,5);
            order.AddItem(monitor, 5);
            List<Order> orders = new List<Order>();
            return orders;
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody]CreateCustomerCommand command){
            Name name = new Name(command.FirstName,command.LastName);
            Document document = new Document(command.Document);
            Email email = new Email(command.Email);
            Customer customer = new Customer(name, document,email, command.Phone);
            return customer;
        }

        
        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody]CreateCustomerCommand command){
            
            Name name = new Name(command.FirstName,command.LastName);
            Document document = new Document(command.Document);
            Email email = new Email(command.Email);
            Customer customer = new Customer(name, document,email, command.Phone);
            return customer;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete(Guid id){
            return new {message = "Cliente removido com sucesso"};
        }
    }
}