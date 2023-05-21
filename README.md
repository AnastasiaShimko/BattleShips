<h1>Battleships Game</h1>

<p>Battleships Game is a simple console-based implementation of the classic game Battleships. The objective of the game is to sink all the ships placed on the grid by guessing their locations.</p>

<h2>How to Play</h2>

<ol>
  <li>Clone or download the repository to your local machine.</li>
  <li>Open the project in your preferred C# development environment.</li>
  <li>Build the project to compile the code.</li>
  <li>Run the application to start the game.</li>
  <li>Follow the instructions displayed in the console to enter your target coordinates.</li>
  <li>Keep guessing the coordinates until you sink all the ships or quit the game.</li>
</ol>

<h2>Features</h2>

<ul>
  <li>Random placement of ships on the grid at the beginning of each game.</li>
  <li>Display of the grid with marked hits, misses, and ships.</li>
  <li>Validation of user input for target coordinates.</li>
  <li>Check for already targeted positions.</li>
  <li>Detection of sunk ships and display of relevant messages.</li>
  <li>Congratulations message upon sinking all the ships.</li>
</ul>

<h2>Code Structure</h2>

<p>The code is organized into the following files:</p>

<ul>
  <li><code>BattleshipsGame.cs</code>: The main class that represents the Battleships game and orchestrates the gameplay.</li>
  <li><code>Grid.cs</code>: A class that represents the game grid and provides methods for grid operations.</li>
  <li><code>Ship.cs</code>: An abstract class representing a ship and defining common properties and methods.</li>
  <li><code>Battleship.cs</code> and <code>Destroyer.cs</code>: Subclasses of the <code>Ship</code> class, representing specific types of ships.</li>
</ul>

<h2>Contributing</h2>

<p>Contributions to the project are welcome. If you find any issues or have suggestions for improvements, please submit an issue or a pull request.</p>

<h2>Acknowledgments</h2>

<ul>
  <li>The Battleships game implementation is inspired by the classic board game of the same name.</li>
</ul>
