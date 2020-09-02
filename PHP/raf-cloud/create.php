<?php
session_start();
$name = $_POST['name'];
$ram = $_POST['ram'];
$fee = (double) $_POST['fee'];
$status = 1;
$uuid = uniqid();
$createdAt = date('Y-m-d');
$active = 0;

$errors = false;
$name = validateName($name);
$ram = validateRam($ram);
$fee = validateFee($fee);

if ($errors){
    if (!isset($_SESSION['nameErr']))
        $_SESSION['nameOld'] = $name;
    if (!isset($_SESSION['ramErr']))
        $_SESSION['ramOld'] = $ram;
    if (!isset($_SESSION['feeErr']))
        $_SESSION['feeOld'] = $fee;

    header('location: dashboard.php');
    exit();
}
require_once 'konekcija.php';

$sql = "INSERT INTO masine (uuid, name, status, createdAt, active, ram, max_fee) 
VALUES(:uuid, :name, :status, :createdAt, :active, :ram, :fee)";
$stmt = $pdo ->prepare($sql);
$stmt ->execute([
    'uuid' => $uuid,
    'name' => $name,
    'status' => $status,
    'createdAt' => $createdAt,
    'active' => $active,
    'ram' => $ram,
    'fee' => $fee
]);

header("Location: dashboard.php");

/**
 * validates the name
 * @param $name - variable to be validated
 * @return string - validated name
 */
function validateName($name){
    if (empty($name)){
        $_SESSION['nameErr'] = "Name is required";
        $GLOBALS['errors'] = true;
    }

    if (strlen($name) < 3 ){
        $_SESSION['nameErr'] = "Name must be longer than 3 characters";
        $GLOBALS['errors'] = true;
    }

    return trim($name);
}

/**
 * validation of ram, has to be positive and not bigger than 64
 * @param $ram
 * @return int
 */
function validateRam($ram){
    if (empty($ram)){
        $_SESSION['ramErr'] = "Enter ram";
        $GLOBALS['errors'] = true;
    }
    if ($ram < 0 || $ram > 64){
        $_SESSION['ramErr'] = "Ram has to be positive and not bigger than 64";
        $GLOBALS['errors'] = true;
    }
    return $ram;
}

/**
 * Max_fee validation, can be empty, otherwise has to be positive
 * @param $fee
 * @return double
 */
function validateFee($fee){
    if ($fee < 0){
        $_SESSION['feeErr'] = "Max_fee has to be greater than zero";
        $GLOBALS['errors'] = true;
    }
    return $fee;
}