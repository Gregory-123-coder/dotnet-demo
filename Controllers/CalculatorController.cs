 using Microsoft.AspNetCore.Mvc;
using CalculatorApp.Models;

namespace CalculatorApp.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public IActionResult Index(CalculatorModel model)
        {
            switch (model.Operation)
            {
                case "Add":
                    model.Result = model.Number1 + model.Number2;
                    break;
                case "Subtract":
                    model.Result = model.Number1 - model.Number2;
                    break;
                case "Multiply":
                    model.Result = model.Number1 * model.Number2;
                    break;
                case "Divide":
                    model.Result = model.Number2 != 0 ? model.Number1 / model.Number2 : 0;
                    break;
                default:
                    model.Result = 0;
                    break;
            }
            return View(model);
        }
    }
}
       