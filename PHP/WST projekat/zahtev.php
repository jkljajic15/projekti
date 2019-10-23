<?php
    session_start();
    $con = new mysqli("localhost","root","","moja_baza");
    $nalog = $_SESSION['username'];
    
    $username = $_GET['korisnik'];

    $q = mysqli_query($con,"INSERT INTO `zahtevi` (`od`,`ka`) VALUES('$nalog','$username')") or die($con --> error($q));
        
   

?>