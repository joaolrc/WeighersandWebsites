<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "mcm";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
//Get Last ID
$sql = $conn->query("SELECT ord FROM peso1 ORDER BY ord DESC LIMIT 1");
$row = $sql->fetch_assoc();
$last= $row['ord'];

date_default_timezone_set("Europe/London");
$timestamp = date("Y-m-d H:i:s");


$sql = "UPDATE peso1 SET peso='".$_GET['peso1']."', peso2='".$_GET['peso2']."', peso3='".$_GET['peso3']."' WHERE ord='$last'";

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