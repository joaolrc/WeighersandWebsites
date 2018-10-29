<?php session_start(); //verificar se utilizador tem sessao iniciada (não--> redireciona para index.php)
	if(!isset($_SESSION['username_login'])){
	header("location: index.php");
	}
?>
 <!DOCTYPE html>
<html>
<body bgcolor="#A9A9A9"> 
<body topmargin="10" leftmargin="100">
</body>
<head>
<title>Home</title> 
	
</head>
<!--<body> -->
<section class="container">
	<div style="float:left; width:30%">
<h1>Bem-vindo <?php echo $_SESSION['username_login'];?> !</h1>
<h4> Utilizador do tipo : 
	<?php 
		if($_SESSION['tipo_login'] == 1){ echo "Técnico <br> Permission LVL: Total";
		} 
		else echo "Outro <br> Permission LvL: Parcial";
	?>
</h4>

	<!-- <button id="btnLigartudo"><b>Ligar Tudo</b></button>
	<button id="btnDesligartudo"><b>Desligar Tudo</b></button> <br> <br> 
	<button id="btnLigarAmarelo"><b>Ligar Amarelo</b></button> 
	<button id="btnLigarVermelho"><b>Ligar Vermelho</b></button> <br> <br> -->
	<a href="logout.php"><b>LOGOUT</b></a>
	<h3>Últimos acessos</h3>
	<?php
	 include('funcional/listarAcessos2.php');
	 ?></div>
	<div style="float:center ">
	<?php
	echo "<br><br>";
	 include('funcional/infind.php');
	?>
	</div>
	<footer>
</section>
<br><br><br><br>
<?php	
	echo ". <br> <br> "?>
<div style="float:left">
	<?php	
	include('funcional/insertTempvf.php');
	?>
</div>
</footer>
	

</html>