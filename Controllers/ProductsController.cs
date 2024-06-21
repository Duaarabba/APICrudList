using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prodeucts.Model;
using System.ComponentModel;

namespace Prodeucts.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		List<Product> Products = new List<Product>
		{
			new Product() { Id = 1, Name = "Product 1",Description = "This is Product one" },
			new Product (){Id =2, Name = "Product2",Description = "This is Product two " },
			new Product (){Id =3,Name = "Product3",Description = "This is Product three " },

		};
		[HttpGet]

		public IActionResult GetProducts()
		{
			return Ok(Products);
		}
		[HttpGet("{id}")]

		public IActionResult GetById()
		{
			var product = Products.First(product=> product.Id == 1);
			if(product == null)
			{
				return NotFound();
			}

			return Ok(product);
		}

		[HttpPost]
		public IActionResult Add(Product request)
		{
			if(request == null)
			{
				return BadRequest();

			}
			var NewProduct = new Product {
                Id = request.Id,
				Name = request.Name,
				Description= request.Description ,
			};
			Products.Add(NewProduct);
			return Ok(Products);

		}

		[HttpPut ("{id}")]
		public IActionResult Update(int id, Product request)
		{
			var CurrentProduct = Products.FirstOrDefault(product => product.Id == id);
			if (CurrentProduct == null)
			{
				return NotFound();
			}
			CurrentProduct.Name = request.Name;
			CurrentProduct.Description = request.Description;
			return Ok(CurrentProduct);

		}
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var product = Products.First(s => s.Id == id);
			if(product == null)
			{
				return NotFound();
			}
			Products.Remove(product);
			return Ok(Products);

		}

	}
}


