namespace GuessTheNumberCSharpTests;
using GuessTheNumberCSharp;

[TestClass]
public class AIPlayerTests
{
    [TestMethod]
    public void MakeGuessTestNumber()
    {
        // Arrange
        var random = new Random();
        GuessTheNumberCSharp.AIPlayer player = new AIPlayer("Computina");
        // Act
        int guess = player.MakeGuess();

        // Assert
        Assert.IsTrue(guess >= 1 && guess <= 100); // Verifica que el número esté en el rango correcto
        CollectionAssert.Contains(player.ListGuess, guess); // Verifica que el número esté en la lista de intentos

    }
}
