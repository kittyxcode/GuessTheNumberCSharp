namespace GuessTheNumberCSharpTests;
using GuessTheNumberCSharp;

[TestClass]
public class HumanPlayerTests
{
    [TestMethod]
    public void MakeGuessTestNumber()
    {
        // Arrange
        var input = new StringReader("50"); // Simula que el usuario ingresa 50
        Console.SetIn(input);
        var output = new StringWriter(); // Captura la salida de la consola
        Console.SetOut(output);

        var player = new HumanPlayer("TestPlayer");

        // Act
        int guess = player.MakeGuess();

        // Assert
        Assert.IsTrue(guess >= 1 && guess <= 100); // Verifica que el número esté en el rango correcto
        CollectionAssert.Contains(player.ListGuess, guess); // Verifica que el número esté en la lista de intentos

        // Verifica que el mensaje de entrada haya sido mostrado en la consola
        StringAssert.Contains(output.ToString(), "Ingresa tu numero: ");

    }
}
