using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGI_6.Models;
using Microsoft.AspNetCore.Mvc;

namespace IGI_6.Controllers
{
    public class ValuesController : ControllerBase
    {
        Repository repo;

        public ValuesController(ApplicationContext context)
        {
            repo = new Repository(context);
        }

        [HttpGet]
        [Route("api/autor")]
        public ActionResult GetAutors()
        {
            var val = repo.GetAutors();
            return new JsonResult(val);
        }
        [HttpGet]
        [Route("api/order")]
        public ActionResult GetOrders()
        {
            var val = repo.GetOrders();
            return new JsonResult(val);
        }
        [HttpGet]
        [Route("api/contract")]
        public ActionResult GetContracts()
        {
            var val = repo.GetContracts();
            return new JsonResult(val);
        }
        [HttpGet]
        [Route("api/book")]
        public ActionResult GetBooks()
        {
            var val = repo.GetBooks();
            return new JsonResult(val);
        }
        [HttpGet]
        [Route("api/customer")]
        public ActionResult GetCustomers()
        {
            var val = repo.GetCustomers();
            return new JsonResult(val);
        }

        [HttpPost]
        [Route("api/AddAutor")]
        public ActionResult AddAutor(Autor autor)
        {
            repo.AddAutor(autor);
            return new JsonResult(repo.GetAutors());
        }
        [HttpPost]
        [Route("api/AddOrder")]
        public ActionResult AddOrder(Order order, string customerName, string bookName)
        {
            order.Customer = repo.GetCustomerByName(customerName);
            order.Book = repo.GetBookByName(bookName);
            repo.AddOrder(order);
            return new JsonResult(repo.GetOrders());
        }
        [HttpPost]
        [Route("api/AddContract")]
        public ActionResult AddContract(Contract contract, string bookName, string autorName)
        {
            contract.Book = repo.GetBookByName(bookName);
            contract.Autor = repo.GetAutorByName(autorName);
            repo.AddContract(contract);
            return new JsonResult(repo.GetContracts());
        }
        [HttpPost]
        [Route("api/AddBook")]
        public ActionResult AddBook(Book book)
        {
            repo.AddBook(book);
            return new JsonResult(repo.GetBooks());
        }
        [HttpPost]
        [Route("api/AddCustomer")]
        public ActionResult AddCustomer(Customer customer)
        {
            repo.AddCustomer(customer);
            return new JsonResult(repo.GetCustomers());
        }

        [HttpDelete]
        [Route("api/autor")]
        public ActionResult DelAutor(int id)
        {
            repo.RemoveAutor(id);
            return new JsonResult(repo.GetAutors());
        }
        [HttpDelete]
        [Route("api/order")]
        public ActionResult DelOrder(int id)
        {
            repo.RemoveOrder(id);
            return new JsonResult(repo.GetOrders());
        }
        [HttpDelete]
        [Route("api/contract")]
        public ActionResult DelContract(int id)
        {
            repo.RemoveContract(id);
            return new JsonResult(repo.GetContracts());
        }
        [HttpDelete]
        [Route("api/book")]
        public ActionResult DelBook(int id)
        {
            repo.RemoveBook(id);
            return new JsonResult(repo.GetBooks());
        }
        [HttpDelete]
        [Route("api/customer")]
        public ActionResult DelCustomer(int id)
        {
            repo.RemoveCustomer(id);
            return new JsonResult(repo.GetCustomers());
        }

        [HttpPut]
        [Route("api/autor")]
        public ActionResult EditAutor(Autor autor)
        {
            if (ModelState.IsValid)
            {
                repo.EditAutor(autor);
            }
            return new JsonResult(repo.GetAutors());
        }
        [HttpPut]
        [Route("api/order")]
        public ActionResult EditOrder(Order order, string customerName, string bookName)
        {
            if (ModelState.IsValid)
            {
                order.Customer = repo.GetCustomerByName(customerName);
                order.Book = repo.GetBookByName(bookName);
                repo.EditOrder(order);
            }
            return new JsonResult(repo.GetOrders());
        }
        [HttpPut]
        [Route("api/contract")]
        public ActionResult EditContract(Contract contract, string bookName, string autorName)
        {
            if (ModelState.IsValid)
            {
                contract.Book = repo.GetBookByName(bookName);
                contract.Autor = repo.GetAutorByName(autorName);
                repo.EditContract(contract);
            }
            return new JsonResult(repo.GetContracts());
        }
        [HttpPut]
        [Route("api/book")]
        public ActionResult EditBook(Book book)
        {
            if (ModelState.IsValid)
            {
                repo.EditBook(book);
            }
            return new JsonResult(repo.GetBooks());
        }
        [HttpPut]
        [Route("api/customer")]
        public ActionResult EditCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                repo.EditCustomer(customer);
            }
            return new JsonResult(repo.GetCustomers());
        }
    }
}
