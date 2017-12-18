﻿using Common.Log;
using Core.Products;
using Core.Settings.ServiceSettings;
using LykkePartnerPortal.Models.Products;
using LykkePartnerPortal.Strings;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LykkePartnerPortal.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        protected readonly ILog _log;
        private readonly ProductsInformationSettings _productsSettings;

        public ProductsController(ILog log, ProductsInformationSettings productsSettings)
        {
            _log = log;
            _productsSettings = productsSettings;
        }

        /// <summary>
        /// Get lykke products
        /// </summary>
        [HttpGet]
        [SwaggerOperation("GetProducts")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<ProductResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<ProductResponseModel> result = GetProducts().Select(p => ProductResponseModel.Create(p));

            if (result.Count() <= 0)
                return NotFound(Phrases.ProductsNotFound);

            return Ok(result);
        }

        private IEnumerable<IProduct> GetProducts()
        {
            string productsImagesFolder = _productsSettings.ProductsFolder;

            IEnumerable<IProduct> products = new List<IProduct>
            {
                new Product()
                {
                    Title = "Lykke Trading Wallet",
                    Description = "Trade FX and Digital Assets",
                    ImageUrl = System.IO.Path.Combine(productsImagesFolder, "lykke_wallet_ios_android.png")
                },
                new Product()
                {
                    Title = "Lykke Margin Trading",
                    Description = "FX and Crypto Margin Trading",
                    ImageUrl = System.IO.Path.Combine(productsImagesFolder, "lykke_margin_trading.png")
                },
                new Product()
                {
                    Title = "Lykke Pay",
                    Description = "Payments on blockchain",
                    ImageUrl = System.IO.Path.Combine(productsImagesFolder, "lykke_pay.png")
                },
                new Product()
                {
                    Title = "Lykke Exchange",
                    Description = "Trading platform and API",
                    ImageUrl =System.IO.Path.Combine(productsImagesFolder, "lykke_exchange.png")
                },
                new Product()
                {
                    Title = "POS Terminal",
                    Description = "POS handheld terminal",
                    ImageUrl = System.IO.Path.Combine(productsImagesFolder, "lykke_pos_terminal.png")
                },
                new Product()
                {
                    Title = "Modern money",
                    Description = "Personal finance application",
                    ImageUrl = System.IO.Path.Combine(productsImagesFolder, "modern_money.png")
                },
                new Product()
                {
                    Title = "Lykke.blue",
                    Description = "Natural capital investment",
                    ImageUrl = System.IO.Path.Combine(productsImagesFolder, "lykke_blue.png")
                }
            };

            return products;
        }
    }
}