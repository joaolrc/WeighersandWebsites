<?php session_start(); //verificar se utilizador já tem sessao iniciada (sim-> redireciona para Home.php)
	if(isset($_SESSION['username_login'])){
		header("location: home.php");
	}
	if(!isset($_SESSION['username_login']) && !isset($_POST['uname'])){
		header("location: index.php");
	}
 include('dbconnect.php');
$esp_server = '192.168.1.169';			//$esp_server = 'http://192.168.1.75';									
 
 $sqlUsername = "SELECT username FROM utilizador WHERE username ='".$_POST['uname']."'";

 
 echo '</br>';
 echo $sqlUsername;
 $res = mysqli_query($conn, $sqlUsername);
 echo '</br>';
 
 if (mysqli_num_rows($res) == 1) {
    echo "O utlizador existe";
	
	$sqlPassword = "SELECT id, username, tipo FROM utilizador WHERE username ='". $_POST['uname']."' AND password ='".$_POST['upass']."'";
	echo '</br>';
	echo $sqlPassword;
	
	$res = mysqli_query($conn, $sqlPassword);
	
	
	if (mysqli_num_rows($res) == 1) { //dar match apenas com 1 utilizador 
		echo "</br>Username e Password Corretos ...!</br>";
		
		while($row = mysqli_fetch_assoc($res)) { 
			echo "</br>id: " . $row["id"]. " - username: " . $row["username"]. " - tipo: " . $row["tipo"]. "<br>";
			
			$_SESSION['id_user_login'] = $row["id"];
			$_SESSION['username_login'] = $row["username"];
			$_SESSION['tipo_login'] = $row["tipo"];
			
		}
		
		date_default_timezone_set("Europe/London");
		$sqlAcesso = "INSERT INTO acessos(user_id, time) VALUES ('".$_SESSION['id_user_login']."', '".date("Y-m-d H:i:s")."')";		//registar acesso
		
		if (mysqli_query($conn, $sqlAcesso)) { //direcionar para home
			echo "Acesso registado";
			header('Location: home.php');
		} else {
			echo "Erro a criar acesso: " . mysqli_error($conn);
		}
		
	} else {
			echo "</br>Username ou Password Incorretos";
			header("Location: index.php");
	}
	
} else {
    echo "0 utilizadores com esse nome";
	header("Location: index.php");
	
}

 
 //var_dump($VARIAVEL);

$conn->close();
?>


