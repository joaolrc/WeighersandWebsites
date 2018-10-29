<?php 
	if(!isset($_SESSION['username_login'])){
	header("location: /mcm/index.php");
	}
?>

<html>
<body><body bgcolor="#A9A9A9"> </body>
<center><h1>------- Supervisão das Linhas -------</h1>

<?php
$page = $_SERVER['PHP_SELF'];
$sec = "20";

/* Conectando, escolhendo o banco de dados */
$conn = mysqli_connect("localhost", "root", "")or die("Conexao falhada 1 " . mysqli_error());
mysqli_select_db($conn,"mcm") or die("Conexao falhada 2");

$sql = "SELECT peso, peso2, peso3, time_stamp FROM peso1 ORDER BY ord DESC LIMIT 1";
$result = $conn->query($sql);


if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        echo "<h2>Linha 1:  " . $row["peso"]. "<br>Linha 2:  " . $row["peso2"]. "<br>Linha 3: ". $row["peso3"]. "<br><br>Atualizado em ". $row["time_stamp"]."<h2>";
    }
} else {
    echo "0 results";
}
$conn->close();
?>
<html>
    <head>
    <meta http-equiv="refresh" content="<?php echo $sec?>;URL='<?php echo $page?>'"> 
    </head>
</body>

</html>