<?php session_start();
	if(isset($_SESSION['username_login'])){
	header("location: home.php");
}
?>
<!DOCTYPE html>
<html>
<body bgcolor="#A9A9A9"> </body>
<head>

<title>Maquinas Login</title>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script> <!--biblioteca de jquery online-->
</head>

<body>

<center><h1>Pesadora Login </h1></center>

<div>
	<form action="/mcm/login.php" method="post">
		<div class="container">
			<label><center><b>Username:</b></center></label>
			<center><input type="text" placeholder="Enter Username" name="uname"  required></center>
			
			</br>
			<?php ?>
			<label><center><b>Password:</b></center></label>
			<center><input type="password" placeholder="Enter Password" name="upass" required></center>
			
			</br>
			
			<center><button type="submit"><h1>Login</h1></button></center>
		 </div>

	</form> 
</div><br>
<center><img src="peso1.png" alt="ledtrans" width="30%" height="30%"></center>
</body>
</html> 