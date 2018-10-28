<!DOCTYPE html>
<html>
<head>
<meta name="viewport" content="width=device-width, initial-scale=1">
</head>
<body>


<div id="myDIV"><?php //regista o acesso do utilizador na tabela acessos da DB maquinasV2_db
	if(!isset($_SESSION['username_login'])){
	header("location: index.php");
	}
	include('dbconnect.php');
	
	$sql = "SELECT time FROM acessos WHERE user_id =".$_SESSION['id_user_login']." ORDER BY id DESC LIMIT 3";
	
	$res = mysqli_query($conn, $sql);
	while($row = mysqli_fetch_assoc($res)) { 			 //efetua ciclo para escrever todos os acessos (registados na DB acessos)do utilizador que fez login
			echo "Acesso em: " . $row["time"] . "<br>";
	}
	
	$conn->close();
?></div>

<script>
function myFunction() {
    var x = document.getElementById("myDIV");
    if (x.innerHTML === "<?php //regista o acesso do utilizador na tabela acessos da DB maquinasV2_db
	if(!isset($_SESSION['username_login'])){
	header("location: index.php");
	}
	include('dbconnect.php');
	
	$sql = "SELECT time FROM acessos WHERE user_id =".$_SESSION['id_user_login']." ORDER BY id DESC LIMIT 3";
	
	$res = mysqli_query($conn, $sql);
	while($row = mysqli_fetch_assoc($res)) { 			 //efetua ciclo para escrever todos os acessos (registados na DB acessos)do utilizador que fez login
			echo "Acesso em: " . $row["time"] . "<br>";
	}
	
	$conn->close();
?>") {
        x.innerHTML = "<?php //regista o acesso do utilizador na tabela acessos da DB maquinasV2_db
	if(!isset($_SESSION['username_login'])){
	header("location: index.php");
	}
	include('dbconnect.php');
	
	$sql = "SELECT time FROM acessos WHERE user_id =".$_SESSION['id_user_login']." ORDER BY id DESC LIMIT 20";
	
	$res = mysqli_query($conn, $sql);
	while($row = mysqli_fetch_assoc($res)) { 			 //efetua ciclo para escrever todos os acessos (registados na DB acessos)do utilizador que fez login
			echo "Acesso em: " . $row["time"] . "<br>";
	}
	
	$conn->close();
?>";
    } else {
        x.innerHTML = "<?php //regista o acesso do utilizador na tabela acessos da DB maquinasV2_db
	if(!isset($_SESSION['username_login'])){
	header("location: index.php");
	}
	include('dbconnect.php');
	
	$sql = "SELECT time FROM acessos WHERE user_id =".$_SESSION['id_user_login']." ORDER BY id DESC LIMIT 3";
	
	$res = mysqli_query($conn, $sql);
	while($row = mysqli_fetch_assoc($res)) { 			 //efetua ciclo para escrever todos os acessos (registados na DB acessos)do utilizador que fez login
			echo "Acesso em: " . $row["time"] . "<br>";
	}
	
	$conn->close();
?>";
    }
}
</script>
<p><button onclick="myFunction()">Mostrar Mais/Menos Acessos</button></p>
</body>
</html>