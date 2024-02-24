using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPP.DTO;
using ProductAPP.Models;

namespace ProductAPP.Controllers
{
    // localhost:5159/api/Products
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController: ControllerBase{

        private readonly ProductsContext _context;

        public ProductsController(ProductsContext context){
            _context = context;
        }
        // localhost:5159/api/Products => GET
        [HttpGet]
        public async Task<IActionResult> GetProducts(){
           var products = await _context
                                .Products.Where(i=>i.IsActive).Select(p =>ProductDTO(p)).ToListAsync();

           return Ok(products);
        }

        // localhost:5159/api/Products/1 => GET
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducts(int? id){
            if(id == null){
                return NotFound();
            }
            var p = await _context
                            .Products
                            .Where(i=>i.ProductId == id)
                            .Select(p => ProductDTO(p))
                            .FirstOrDefaultAsync();

            if(p == null){
                return NotFound();
            }
            return Ok(p);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product entity){
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducts),new{id = entity.ProductId},entity);

        }

        [HttpPut("{id}")]
            public async Task<IActionResult> UpdateProduct(int id, Product entity)
            {
                if(id != entity.ProductId){
                    return BadRequest();
                }

                var product = await _context.Products.FirstOrDefaultAsync(i=>i.ProductId == id);

                if(product == null){
                    return NotFound();
                }

                product.ProductName = entity.ProductName;
                product.Price = entity.Price;
                product.IsActive = entity.IsActive;

                try{
                    await _context.SaveChangesAsync();
                }
                catch(Exception){
                    return NotFound();
                }
                return NoContent();
            }
            
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteProduct(int? id){
                if(id == null){
                    return NotFound();
                }
                var product = await _context.Products.FirstOrDefaultAsync(i=>i.ProductId == id);

                if(product == null){
                    return NotFound();
                }
                _context.Products.Remove(product);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return NotFound();
                }

                return NoContent();
            }

            private static ProductDTO ProductDTO(Product p){
                var entity = new ProductDTO();
                if(p != null){
                    entity.ProductId = p.ProductId;
                    entity.ProductName = p.ProductName;
                    entity.Price = p.Price;
                }
                return entity;
            }
        }
    }