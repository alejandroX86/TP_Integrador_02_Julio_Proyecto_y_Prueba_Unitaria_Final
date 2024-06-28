using _03_Dominio.ValueObjects;
using System;
using Xunit;

namespace TestProject_DDD_Dominio_Email
{
    public class UnitTest1
    {
        public class EmailTests
        {
            [Fact]
            public void Email_Valido_NoLanzaExcepcion()
            {
                // Preparar
                var emailValido = "test@example.com";

                // Actuar
                var ex = Record.Exception(() => new Email(emailValido));

                // Afirmar
                Assert.Null(ex);
            }

            [Fact]
            public void Email_Invalido_LanzaExcepcion()
            {
                // Preparar
                var emailInvalido = "invalid-email";

                // Actuar y Afirmar
                var ex = Assert.Throws<Exception>(() => new Email(emailInvalido));
                Assert.Equal("El email no es válido", ex.Message);
            }
        }
    }
}