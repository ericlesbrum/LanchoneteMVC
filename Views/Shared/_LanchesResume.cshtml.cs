using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LanchoneteMVC.Views.Shared
{
    public class _LanchesResume : PageModel
    {
        private readonly ILogger<_LanchesResume> _logger;

        public _LanchesResume(ILogger<_LanchesResume> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}