<?php
if (isset($_GET["id"])) {


	$ID = $_GET["id"];

	$sql = "select seen_msg from mails  WHERE   id like '$ID' ";

	$SERVER = "localhost";
	$User  = "root";
	$Pass = "";
	$db_name = "emails";



	$connection = new mysqli($SERVER, $User, $Pass, $db_name);
	if ($connection->connect_error) {
		die("Connection Failed : " . $connection->connect_error);
	} else {
		
		$sth = mysqli_query($connection, $sql);
		$row = array();
		if ($r = mysqli_fetch_assoc($sth)) {
			$row[]  = $r;
			print_r($row[0]["seen_msg"]);
		} else {
		}
	}
}
