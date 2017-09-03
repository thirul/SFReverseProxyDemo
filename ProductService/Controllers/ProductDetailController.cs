using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    public class ProductDetailController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<ProductDetail> Get()
        {
            var page = "http://localhost:19081/ReverseProxyDemo/OrderService/ApI/Order";
            IEnumerable<OrderDetail> orderDetail = null;
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                  var result = await content.ReadAsStringAsync();
                orderDetail =  Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<OrderDetail>>(result);
                             }
            return new ProductDetail { Name = "Samsung Galaxy 9 Edge", Price =123.45, Description ="This is the top most selling model in mobile world.", Orders = orderDetail};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
