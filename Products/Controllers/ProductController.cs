using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.IServices;
using Products.Models.Dto;

namespace Products.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            try
            {
                Response response = await _productService.GetAllProductsAsync();
                if(response.IsSuccess)
                    {
                        var products = response.Data;
                        return View(products);
                    }
                    else
                    {
                        // Handle the case where the service call was not successful
                        // You can log the error message or display it to the user
                        _logger.LogError("Failed to retrieve products: {Message}", response.Message);
                        return View("Error", response.Message); // Assuming you have an Error view to display the message
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                Response response = await _productService.GetProductByIdAsync(id);
                if (response.IsSuccess)
                {
                    var products = response.Data;
                    return View(products);
                }
                else
                {
                    // Handle the case where the service call was not successful
                    // You can log the error message or display it to the user
                    _logger.LogError("Failed to retrieve products: {Message}", response.Message);
                    return View("Error", response.Message); // Assuming you have an Error view to display the message
                }
            
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddProductRequest collection)
        {
            try
            {
                await _productService.AddProductAsync(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                Response response = await _productService.GetProductByIdAsync(id);
                if(response.IsSuccess)
                {
                    var products = response.Data;
                    return View(products);
                }
                else
                {
                    // Handle the case where the service call was not successful
                    // You can log the error message or display it to the user
                    _logger.LogError("Failed to retrieve products: {Message}", response.Message);
                    return View("Error", response.Message); // Assuming you have an Error view to display the message
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateProductRequest collection)
        {
            try
            {
                Response response = await _productService.UpdateProductAsync(collection);
                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Error", response.Message); // Assuming you have an Error view to display the message
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Response response = await _productService.GetProductByIdAsync(id);
                if (response.IsSuccess)
                {
                    var products = response.Data;
                    return View(products);
                }
                else
                {
                    // Handle the case where the service call was not successful
                    // You can log the error message or display it to the user
                    _logger.LogError("Failed to retrieve products: {Message}", response.Message);
                    return View("Error", response.Message); // Assuming you have an Error view to display the message
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(UpdateProductRequest collection)
        {
            try
            {
                await _productService.DeleteProductAsync(collection.ProductId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
