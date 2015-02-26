using System;
using System.Collections.Generic;
using System.Web;
using jpdemo1.Models;
using System.Web.Mvc;
using Umbraco;
using Umbraco.Web.WebApi;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using Newtonsoft.Json;
using System.Text;

namespace jpdemo1.Controllers
{
    /// <summary>
    /// Summary description for ProductsController
    /// </summary>
    public class ProductsController : UmbracoApiController
    {
            Product[] products = new Product[] 
            { 
                new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
                new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
                new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
            };

            public IEnumerable<Product> GetAllProducts()
            {
                return products;
            }

            public HttpResponseMessage GetProduct(int id)
            {
                HttpResponseMessage response = new HttpResponseMessage();
                //string message = "";
                var product = products.FirstOrDefault((p) => p.Id == id);
                if (product == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("No product with ID = {0}", id)),
                        ReasonPhrase = "Product ID Not Found"
                    };
                    throw new HttpResponseException(resp);

                }
                response.StatusCode = HttpStatusCode.OK;
                string json = JsonConvert.SerializeObject(product);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
            }
    }
}