<?php
	if(!isset($_SESSION['username_login'])){
	header("location: /mcm/index.php");
	}
?>
<!DOCTYPE HTML>
<html>
<head>
<style>
div.ex1 {
    width:1500px;
    margin: 10;
}
</style>


		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<title>Highcharts Example</title>

		<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
		<style type="text/css">
${demo.css}
		</style>
	</head>
	<body>
<script src="https://code.highcharts.com/highcharts.js"></script>
<script src="https://code.highcharts.com/modules/exporting.js"></script>

<!--<div id="container" style="min-width: 310px; height: 400px; margin: 0 auto"></div>  -->
<?php
$Temp="";
$ordem="";
$line1="";
$line2="";
$line3="";

	/* Conectando, escolhendo o banco de dados */
    $link = mysqli_connect("localhost", "root", "")or die("No pude conectar: " . mysqli_error());
    mysqli_select_db($link,"mcm") or die("No pude selecionar o banco de dados");

    $query = "SELECT peso, peso2, peso3, ord, time_stamp FROM peso1 ORDER BY ord DESC LIMIT 50";
    $result = mysqli_query($link,$query) or die("A query falhou: " . mysqli_error());
	while ($row=mysqli_fetch_array($result,MYSQLI_ASSOC)){
		$linha1[]= $row['peso'].",";
		$linha2[]= $row['peso2'].",";
		$linha3[]= $row['peso3'].",";
		
		$timestamp = strtotime($row['time_stamp'])*1000;		
	    $line1= $line1."[".$timestamp.",".$row['peso']."],";
		$line2= $line2."[".$timestamp.",".$row['peso2']."],";
		$line3= $line3."[".$timestamp.",".$row['peso3']."],";	
    }

    $line1= substr(trim($line1), 0, -1);  //cortar ultima virgula
?>
 <center>   <div class="ex1" id="container"></div>
    <div class="ex1" id="container2"></div>
	<div class="ex1" id="container3"></div> </center>

		<script type="text/javascript">

		Highcharts.chart('container', {
		chart: {
        renderTo: 'container',
		type: 'spline'
        },
    title: {text: 'Linha 1'},
    yAxis: { title: {text: 'Peso Total Diário Registado (Kg)'}},
	xAxis: {
		title: {text: 'Data de Registo'},
        type: 'datetime',
        dateTimeLabelFormats: {
           day: '%d %b %Y'    //ex- 01 Jan 2016
        }
},
	legend: {layout: 'vertical',align: 'right',verticalAlign: 'middle'},
	plotOptions: { series: {pointStart: 0}},
	colors: ['green'],
		
    series: [{
        name: 'Linha 1',
        data: [ <?PHP echo $line1?>]
    }]
});

		Highcharts.chart('container2', {
		chart: {
        renderTo: 'container2',
		type: 'spline'
        },
    title: {text: 'Linha 2'},
    yAxis: { title: {text: 'Peso Total Diário Registado (Kg)'}},
	xAxis: {
		title: {text: 'Data de Registo'},
        type: 'datetime',
        dateTimeLabelFormats: {
           day: '%d %b %Y'    //ex- 01 Jan 2016
        }
},
	legend: {layout: 'vertical',align: 'right',verticalAlign: 'middle'},
	plotOptions: { series: {pointStart: 0}},
	colors: ['red'],
    series: [{
        name: 'Linha 2',
        data: [ <?PHP echo $line2?>]
    }]
});

		Highcharts.chart('container3', {
		chart: {
        renderTo: 'container3',
		type: 'spline'
        },
    title: {text: 'Linha 3'},
    yAxis: { title: {text: 'Peso Total Diário Registado (Kg)'}},
	xAxis: {
		title: {text: 'Data de Registo'},
        type: 'datetime',
        dateTimeLabelFormats: {
           day: '%d %b %Y'    //ex- 01 Jan 2016
        }
},
	legend: {layout: 'vertical',align: 'right',verticalAlign: 'middle'},
	plotOptions: { series: {pointStart: 0}},
	colors: ['blue'],	
    series: [{
        name: 'Linha 3',
        data: [ <?PHP echo $line3?>]
    }]
});

		</script>

	</body>
</html>