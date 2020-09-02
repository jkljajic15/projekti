<?php
session_start();
if (isset($_POST)){

    $username = $_POST['username'];
    $password = $_POST['password'];
    require_once "konekcija.php";

    $stmt = $pdo -> prepare("SELECT username, password FROM users WHERE username = :username");
    $stmt ->execute([
        'username' => $username,
    ]);
    $user = $stmt ->fetch();

    if (password_verify($password,$user['password'])){
        header("Location: dashboard.php");
    }
    else{
        $_SESSION['loginErr'] = 'Bad credentials, please log in again.';
        header("location:index.php");
    }
}


