using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;

namespace ApiRestAspNet5_01.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class CalculatorsController : ControllerBase
    {
        //private readonly ILogger<CalculatorController> _logger;

        //public CalculatorController(ILogger<CalculatorController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Ivalid input!");
        }

        [HttpGet("squareRoot/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (IsNumeric(number))
            {
                var sqrt = Math.Sqrt((double)ConvertToDecimal(number)); //DownCasting
                return Ok(sqrt.ToString());
            }
            return BadRequest("Ivalid input!");
        }

        [HttpGet("power/{firstNumber}/{secondNumber}")]
        public IActionResult Power(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var pow = Math.Pow(ConvertToDouble(firstNumber), ConvertToDouble(secondNumber));
                return Ok(pow.ToString());
            }
            return BadRequest("Ivalid input!");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber, NumberStyles.Any, 
                NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private double ConvertToDouble(string strNumber)
        {
            double doubleValue;
            if (double.TryParse(strNumber, out doubleValue))
            {
                return doubleValue;
            }
            return 0.0;
        }
    }
}
