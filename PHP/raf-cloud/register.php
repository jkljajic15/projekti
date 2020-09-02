<?php session_start() ?>
<!doctype html>
<html lang="en">
<head>
    <title>RAF - Cloud</title>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
          integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

    <style>
        html, body {
            height: 100%;
        }
    </style>
</head>
<body>
<?php
if (isset($_POST['username']) && isset($_POST['password'])){
    $username = $_REQUEST['username'];
    if (!empty($_REQUEST['password'])){
        $password = password_hash($_REQUEST['password'], PASSWORD_DEFAULT);
    }
    $fname = $_REQUEST['fname'];
    $lname = $_REQUEST['lname'];
    $errors = false;
    require_once 'konekcija.php';
    $sql = $pdo -> query("SELECT username FROM users");
    $results = $sql -> fetchAll();

    /**
     *  Validacija username-a
     * @param $username
     * @return string
     */
    function validateUsername($username){
        if (empty($username)){
            $_SESSION['usernameErr'] = "Username is required";
            $GLOBALS['errors'] = true;
        }

        foreach ($GLOBALS['results'] as $result){

            if ($result['username'] == $GLOBALS['username']){
                $_SESSION['usernameErr'] = "Username already exists";
                $GLOBALS['errors'] = true;
            }
        }

        return trim($username);
    }

    /**
     * Validacija passworda
     * @param $password
     * @return string
     */
    function validatePassword($password){
        if (empty($password)){
            $_SESSION['passwordErr'] = "Enter password";
            $GLOBALS['errors'] = true;
        }
        return trim($password);
    }
    validateUsername($username);
    validatePassword($password);

    if ($errors){
        header("location: register.php");
        die();
    }

    $sql = $pdo -> prepare("INSERT INTO users (username, password,firstName,lastName)
                                VALUES (:username, :password, :fname, :lname)");
    $sql -> execute([
        'username' => $username,
        'password' => $password,
        'fname' => $fname,
        'lname' => $lname
    ]);

    header("Location: index.php");
}

?>
<div class="container d-flex h-100 ">
    <div class="mx-auto align-self-center text-center">
        <h1>RAF - Cloud </h1>
        <form action="register.php" method="post">
            <div class="form-group">
                <label for="usernameUnos">Username</label>
                <input type="text" name="username" id="usernameUnos" class="form-control" placeholder="Username..." required>
                <?php if (isset($_SESSION['usernameErr'])): ?>
                    <span class="m-1" style="color: darkred"><?= $_SESSION['usernameErr'] ?></span>
                    <?php unset($_SESSION['usernameErr']); ?>
                <?php endif; ?>
            </div>
            <div class="form-group">
                <label for="passwordUnos">Password</label>
                <input type="text" name="password" id="passwordUnos" class="form-control" placeholder="Password..." >
                <?php if (isset($_SESSION['passwordErr'])): ?>
                    <span class="m-1" style="color: darkred"><?= $_SESSION['passwordErr'] ?></span>
                    <?php unset($_SESSION['passwordErr']); ?>
                <?php endif; ?>
            </div>
            <div class="form-group">
                <label for="fname">First Name</label>
                <input type="text" name="fname" id="fname" class="form-control" placeholder="First Name">
            </div>
            <div class="form-group">
                <label for="lname">Last Name</label>
                <input type="text" name="lname" id="lname" class="form-control" placeholder="Last Name">
            </div>
            <button type="submit" class="btn btn-primary">Register</button>
        </form>
    </div>
</div>



<!-- Optional JavaScript -->
<!-- jQuery first, then Popper.js, then Bootstrap JS -->
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"
        integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo"
        crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"
        integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1"
        crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"
        integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM"
        crossorigin="anonymous"></script>
</body>
</html>