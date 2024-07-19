using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LanchoneteMVC.Views.Pedido
{
    public class CheckoutCompleto : PageModel
    {
        private readonly ILogger<CheckoutCompleto> _logger;

        public CheckoutCompleto(ILogger<CheckoutCompleto> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}