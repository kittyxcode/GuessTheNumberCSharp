namespace GuessTheNumberCSharpTests;
using GuessTheNumberCSharp;

[TestClass]
public class HumanPlayerTests
{
    [TestMethod]
    public void MakeGuessTestNumber()
    {
        // Arrange
        var random = new Random();
        GuessTheNumberCSharp.HumanPlayer player = new HumanPlayer("TestPlayer");
        // Act
        int guess = player.MakeGuess();

        // Assert
        Assert.IsTrue(guess >= 1 && guess <= 100); // Verifica que el número esté en el rango correcto
        CollectionAssert.Contains(player.ListGuess, guess); // Verifica que el número esté en la lista de intentos

    }
}
