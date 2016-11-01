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

$sql = "INSERT INTO Users (facebookUserID, firstName, middleName, insertion, lastName)
        VALUES ('".$facebookUserID."','".$firstName."','".$middleName."','".$insertion."','".$lastName."')";
        
$result = mysqli_query($conn, $sql);

if(!$result) echo $result;
else echo "Everything is okay!";

function registerUser(){
    $createdHash = password_hash($password, PASSWORD_DEFAULT);
    $sql = "INSERT INTO User (firstName, lastName,date_of_birth, height, weight)"
}

/*
To whom it may concern,

My name is Martin van Keulen and I'm a 4th years currently pursuing a Bachelor's degree in Computer Science at the Amsterdam University of Applied Sciences.
I am currently minoring in Serious Gaming at Nihon University in Japan and will be graduating between July and the end of August. 
After graduating I really want to pursue a master's degree in Computer science at Linkoping University, but reading the programme specific requirements left me a bit worried for the following reason:
The requirements state that I should have been credited at least 24 ECTS in mathematics/applied mathematics relevant to the program.
Is this requirement mandatory, if so, is there any way for me to still enroll in this master's program by, for example, following some additional courses or by self study until the start of the programme?
*/
?>