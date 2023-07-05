<?php
if (isset($_GET["id"])) {


	$ID = $_GET["id"];

	$sql = "update mails set seen_msg = 1   WHERE   id = '$ID' ";

	$SERVER = "localhost";
	$User  = "root";
	$Pass = "";
	$db_name = "emails";



	$connection = new mysqli($SERVER, $User, $Pass, $db_name);
	if ($connection->connect_error) {
		die("Connection Failed : " . $connection->connect_error);
	} else {
		$sth = mysqli_query($connection, $sql);

	}
}
