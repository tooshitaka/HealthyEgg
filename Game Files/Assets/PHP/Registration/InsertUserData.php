<?php
//Database variables
$db_name = "zkeulenm001";
$server_name= "localhost";
$server_username = "keulenm001";
$server_password = "GXu+B3rgaRw1u#";

//User data
$facebookUserID = $_POST['uID'];
$firstName = $_POST['fName'];
$middleName = $_POST['mName'];
$insertion = $_POST['ins'];
$lastName = $_POST['lName'];
$password = $_POST['password'];

$conn = new mysqli($server_name, $server_username, $server_password, $db_name);

if(!$conn){
    die("Connection Failed. ". mysqli_connect_error());
}

$sql = "INSERT INTO Account (facebookUserID, firstName, middleName, insertion, lastName)
        VALUES ('".$facebookUserID."','".$firstName."','".$middleName."','".$insertion."','".$lastName."')";
        
$result = mysqli_query($conn, $sql);

if(!$result) echo $result;
else echo "Everything is okay!";

function registerUser(){
    $createdHash = password_hash($password, PASSWORD_DEFAULT);
    $sql = "INSERT INTO User (firstName, lastName,date_of_birth, height, weight)"
}

?>