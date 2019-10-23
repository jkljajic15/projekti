<?php
    session_start();
    $usr = $_SESSION['username'];
    
    $dir = 'slike/';
    $ime = $_FILES['file']['name'];
    $tmp = $_FILES['file']['tmp_name'];
    

    
    move_uploaded_file($tmp,$dir . $ime);
   
    $con = new mysqli("localhost","root","","moja_baza");
	$q = mysqli_query($con,"UPDATE korisnici SET Profilna = '$ime' WHERE username = '$usr'");
    
    header('Location:profil.php');

?>