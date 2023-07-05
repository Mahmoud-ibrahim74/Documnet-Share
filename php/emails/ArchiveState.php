<?php
if(isset($_GET["date"]))
{
	$date = $_GET["date"];
$sql = "select COUNT(ArchiveSent) from mails  WHERE   ArchiveSent = 1 and date_mail like '%$date%' ";

$SERVER = "localhost";
$User  = "root";
$Pass = "";
$db_name = "emails";



$connection = new mysqli($SERVER, $User, $Pass, $db_name);
if ($connection->connect_error) {
	die("Connection Failed : " . $connection->connect_error);
} else {

	$sth = mysqli_query($connection, $sql);
	$row = mysqli_fetch_array($sth);
	echo $row[0];
}
}


?>