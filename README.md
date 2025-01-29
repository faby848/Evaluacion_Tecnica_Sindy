# Evaluacion_Tecnica_Sindy

# Instrucciones para probar la API en POSTMAN:
1. Crear cuenta (GET): https://localhost:44321/Cuenta/Crear
-Haz clic en el botón Send.
Respuesta esperada:

Código de estado HTTP: 200 OK
Cuerpo de la respuesta:
json

{
  "numeroCuenta": "123456789012",  // Un número de cuenta generado aleatoriamente
  "saldo": 1000
}
Esto te devolverá un objeto con el número de cuenta generado y el saldo inicial de 1000.
![Image](https://github.com/user-attachments/assets/45c781de-0e3e-4559-9b56-3dceab9bc345)

----------------------------------------------------------------------------------------------
2. Consultar saldo (GET): https://localhost:44321/Cuenta/{numeroCuenta}

Reemplaza {numeroCuenta} con el número de cuenta que obtuviste en la respuesta anterior. Por ejemplo, si tu número de cuenta es 123456789012, la URL sería:

Ejemplo: https://localhost:44321/Cuenta/123456789012

Haz clic en el botón Send.

Respuesta esperada:

Código de estado HTTP: 200 OK
Cuerpo de la respuesta:
json

"1000"
Esto te devolverá el saldo actual de la cuenta.
![Image](https://github.com/user-attachments/assets/6b85f0fd-a305-4f87-bfd6-7bacdd40ba86)

----------------------------------------------------------------------------------------------
3. Depositar (POST): https://localhost:44321/Cuenta/Deposito?numeroCuenta={numeroCuenta}

Reemplaza {numeroCuenta} con el número de cuenta que obtuviste en la creación de cuenta.

En la pestaña Body, selecciona la opción raw y luego elige el formato JSON.

En el cuerpo de la solicitud, ingresa el monto del depósito:

json

500
Haz clic en el botón Send.

Respuesta esperada:

Código de estado HTTP: 200 OK
Cuerpo de la respuesta:
json: 
{
  "numeroCuenta": "123456789012",  // El número de cuenta
  "saldo": 1500
}
Esto actualizará el saldo de la cuenta a 1500.
![Image](https://github.com/user-attachments/assets/429f763f-5a99-480f-ad09-56fc8afcbc1d)

----------------------------------------------------------------------------------------------
4. Retirar (POST): https://localhost:44321/Cuenta/Retiro?numeroCuenta={numeroCuenta}

Reemplaza {numeroCuenta} con el número de cuenta que obtuviste previamente.

En la pestaña Body, selecciona la opción raw y luego elige el formato JSON.

En el cuerpo de la solicitud, ingresa el monto del retiro:

json

200
Haz clic en el botón Send.

Respuesta esperada:

Código de estado HTTP: 200 OK
Cuerpo de la respuesta:
json

{
  "numeroCuenta": "123456789012",  // El número de cuenta
  "saldo": 1300
}
Esto actualizará el saldo de la cuenta a 1300.
![Image](https://github.com/user-attachments/assets/12726ca0-2054-4c58-9783-bc0acc33b093)

-Probar el retiro con fondos insuficientes
Para intentar un retiro de una cantidad mayor al saldo disponible (por ejemplo, 2000), sigue estos pasos:

Método HTTP: POST

URL: https://localhost:44321/Cuenta/Retiro?numeroCuenta={numeroCuenta}

Reemplaza {numeroCuenta} con el número de cuenta que obtuviste previamente.

En la pestaña Body, selecciona la opción raw y luego elige el formato JSON.

En el cuerpo de la solicitud, ingresa el monto del retiro:

json

2000
Haz clic en el botón Send.

Haz clic en el botón Send.

Respuesta esperada:

Código de estado HTTP: 400 Bad Request
Cuerpo de la respuesta:
json: 

"Fondos insuficientes"
Esto indica que no puedes retirar más dinero del que tienes disponible en la cuenta.
![image](https://github.com/user-attachments/assets/1b5b9985-bd5d-4c03-a9bb-70a66188a582)


----------------------------------------------------------------------------------------------
5. Resumen de transacciones (GET): https://localhost:44321/Cuenta/Resumen
Haz clic en el botón Send.

Respuesta esperada:
Código de estado HTTP: 200 OK
Cuerpo de la respuesta:

json

{
  "SaldoFinal": 1300,
  "Transacciones": [
    {
      "Id": 1,
      "numeroCuenta": "123456789012",
      "Tipo": "Depósito",
      "Monto": 500,
      "SaldoDespues": 1500
    },
    {
      "Id": 2,
      "numeroCuenta": "123456789012",
      "Tipo": "Retiro",
      "Monto": 200,
      "SaldoDespues": 1300
    }
  ]
}
Esto te dará el saldo final y un listado de las transacciones (depósito y retiro) realizadas.
![image](https://github.com/user-attachments/assets/aced3009-07b6-43d0-b8c7-2cc407a85163)



