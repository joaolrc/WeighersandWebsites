<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "mcm";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
date_default_timezone_set("Europe/London");
$timestamp = date("Y-m-d H:i:s");

//Get Last value
$sql = $conn->query("SELECT peso FROM peso1 ORDER BY ord DESC LIMIT 1");
$row = $sql->fetch_assoc();
$last= $row['peso'];

if ($last!=1) { //para evitar criar outra linha na tabela, se houver reset e a comunicaçao ainda nao estiver estabelecida com o micro principal
	$sql = "INSERT INTO peso1(peso, peso2, peso3) VALUES ('1','1','1')";
}
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

if ($conn->query($sql) === TRUE) {
    echo "New record created successfully";
} else {
    echo "Error: " . $sql . "<br>" . $conn->error;
}


	
$conn->close();	
?>