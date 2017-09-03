using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace EcomDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Product()
        {
            ViewData["Message"] = " Product Details:";

            var page = "http://localhost:19081/ReverseProxyDemo/ProductService/ApI/ProductDetail";
            ProductDetail productDetail = null;
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                var result = await content.ReadAsStringAsync();
                productDetail = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductDetail>(result);
            }

            return View(productDetail);
        }

        public async Task< IActionResult> Orders()
        {
            ViewData["Message"] = "Your Orders:";

            var page = "http://localhost:19081/ReverseProxyDemo/OrderService/ApI/Order";
            IEnumerable<OrderDetail> orderDetail = null;
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                var result = await content.ReadAsStringAsync();
                orderDetail = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<OrderDetail>>(result);
            }

            return View(orderDetail);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
