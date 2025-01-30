using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ultima_prueba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuentaController : ControllerBase
    {
        private static Cuenta nuevaCuenta = new Cuenta();

        // Crear cuenta con saldo inicial de 1000
        [HttpGet("Crear", Name = "CrearCuenta")]
        public Cuenta CrearCuenta()
        {
            Random rnd = new Random();
            long randomNumber = (long)(rnd.NextDouble() * 9_000_000_000_000) + 1_000_000_000_000;
            nuevaCuenta.numeroCuenta = randomNumber.ToString();
            nuevaCuenta.saldo = 1000;
            return nuevaCuenta;
        }

        // Consultar saldo de la cuenta
        [HttpGet("{numeroCuenta}", Name = "ConsultaSaldo")]
        public string ConsultaSaldo(string numeroCuenta)
        {
            if (numeroCuenta == nuevaCuenta.numeroCuenta)
            {
                return nuevaCuenta.saldo.ToString();
            }
            else
            {
                return "No se encontró la cuenta";
            }
        }

        // Realizar depósito
        [HttpPost("Deposito", Name = "Deposito")]
        public IActionResult Deposito([FromBody] decimal monto, [FromQuery] string numeroCuenta)
        {
            if (numeroCuenta != nuevaCuenta.numeroCuenta)
            {
                return BadRequest("El número de cuenta no coincide.");
            }

            // Validación del monto
            if (monto <= 0)
            {
                return BadRequest("El monto del depósito debe ser mayor que cero");
            }

            nuevaCuenta.saldo += monto;

            // Crear una nueva transacción
            var transaccion = new Transaccion
            {
                Id = nuevaCuenta.transacciones.Count + 1,
                numeroCuenta = nuevaCuenta.numeroCuenta,
                Tipo = "Depósito",
                Monto = monto,
                SaldoDespues = nuevaCuenta.saldo
            };

            // Registrar la transacción
            nuevaCuenta.transacciones.Add(transaccion);

            return Ok(nuevaCuenta);
        }

        // Realizar retiro
        [HttpPost("Retiro", Name = "Retiro")]
        public IActionResult Retiro([FromBody] decimal monto, [FromQuery] string numeroCuenta)
        {
            if (numeroCuenta != nuevaCuenta.numeroCuenta)
            {
                return BadRequest("El número de cuenta no coincide.");
            }

            // Validación del monto
            if (monto <= 0)
            {
                return BadRequest("El monto del retiro debe ser mayor que cero");
            }

            // Validar si hay fondos suficientes
            if (monto > nuevaCuenta.saldo)
            {
                return BadRequest("Fondos insuficientes");
            }

            nuevaCuenta.saldo -= monto;

            // Crear una nueva transacción
            var transaccion = new Transaccion
            {
                Id = nuevaCuenta.transacciones.Count + 1,
                numeroCuenta = nuevaCuenta.numeroCuenta,
                Tipo = "Retiro",
                Monto = monto,
                SaldoDespues = nuevaCuenta.saldo
            };

            // Registrar la transacción
            nuevaCuenta.transacciones.Add(transaccion);

            return Ok(nuevaCuenta);
        }

        // Obtener el resumen de transacciones y el saldo final
        [HttpGet("Resumen", Name = "ResumenTransacciones")]
        public IActionResult Resumen()
        {
            if (nuevaCuenta.transacciones.Count == 0)
            {
                return NotFound("No hay transacciones registradas");
            }

            var resumen = new
            {
                SaldoFinal = nuevaCuenta.saldo,
                Transacciones = nuevaCuenta.transacciones
            };

            return Ok(resumen);
        }
    }
}

