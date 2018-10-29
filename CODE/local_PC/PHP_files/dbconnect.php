<?php //codigo para conectar a base de dados maquinasV2_db
$servername = "localhost";
$username = "root";
$password = "";
$dbname = 'mcm';

// Create connection
$conn = mysqli_connect($servername, $username, $password, $dbname);

// Check connection
if (!$conn) {
    die("Connection failed: " . mysqli_connect_error());
}
//echo "Connect DB Result: Connected successfully";
?> 