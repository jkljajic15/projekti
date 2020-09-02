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
require_once 'konekcija.php';

if (isset($_GET['search']) && !empty($_GET['search'])) {
    $search = $_GET['search'];

    $stmt = $pdo->prepare("select * from masine where name like :search");
    $param = [
        'search' => "%" . $search . "%"
    ];
} else {
    $sql = "select id, name, ram, max_fee from masine";
    $stmt = $pdo->prepare($sql);
    $param = [];
}
$stmt->execute($param);
$masine = $stmt->fetchAll();

?>
<div class="container h-100">

    <div class="row">
        <?php if (isset($_SESSION['nameErr'])): ?>
            <span class="m-1" style="color: darkred"><?= $_SESSION['nameErr'] ?></span>
            <?php unset($_SESSION['nameErr']); ?>
        <?php endif; ?>
        <?php if (isset($_SESSION['ramErr'])): ?>
            <span class="m-1" style="color: darkred"><?= $_SESSION['ramErr'] ?></span>
            <?php unset($_SESSION['ramErr']); ?>
        <?php endif; ?>
        <?php if (isset($_SESSION['feeErr'])): ?>
            <span class="m-1" style="color: darkred"><?= $_SESSION['feeErr'] ?></span>
            <?php unset($_SESSION['feeErr']); ?>
        <?php endif; ?>
    </div>


    <div class="row ">

        <form action="create.php" class="form-inline p-2" method="post">
            <div class="form-group m-1">
                <label for="name" class="sr-only"></label>
                <input type="text" name="name" id="name" class="form-control" placeholder="Name"
                       value="<?= $_SESSION['nameOld'] ?>">
            </div>
            <div class="form-group m-1">
                <label for="ram" class="sr-only"></label>
                <input type="text" name="ram" id="ram" class="form-control" placeholder="Ram"
                       value="<?= $_SESSION['ramOld'] ?>">
            </div>
            <div class="form-group m-1">
                <label for="fee" class="sr-only"></label>
                <input type="number" step=".01" name="fee" id="fee" class="form-control" placeholder="Max fee"
                       value="<?= $_SESSION['feeOld'] ?>">
            </div>
            <button type="submit" class="btn btn-primary m-2">Create</button>
        </form>
        <?php
        unset($_SESSION['nameOld']);
        unset($_SESSION['ramOld']);
        unset($_SESSION['feeOld']);
        ?>
        <form action="" class="p-2 form-inline mt-auto ml-auto">
            <div class="form-group m-2">
                <label for="search" class="sr-only"></label>
                <input type="text" name="search" id="search" class="form-control" placeholder="Pretraga">
            </div>
            <button type="submit" class="btn btn-primary">Search</button>
        </form>
    </div>
    <?php if (isset($_SESSION['masinaMsg'])): ?>
        <div class="m-1" style="color: green"><?= $_SESSION['masinaMsg'] ?></div>
        <?php unset($_SESSION['masinaMsg']); ?>
    <?php endif; ?>
    <div class="row h-50">
        <div class="col">
            <table class="table">
                <thead>
                <tr>
                    <th>Name</th>
                    <th>Ram</th>
                    <th>Max fee</th>
                </tr>
                </thead>
                <tbody>
                <?php foreach ($masine as $masina): ?>
                    <tr>
                        <td><a href="update.php?id=<?= $masina['id'] ?>"><?= $masina['name'] ?></a></td>
                        <td><?= $masina['ram'] ?></td>
                        <td><?= $masina['max_fee'] ?></td>
                    </tr>
                <?php endforeach; ?>
                </tbody>
            </table>
        </div>
    </div>
</div>
<?php

$_SESSION['nameOld'] = "";
$_SESSION['ramOld'] = "";
$_SESSION['feeOld'] = "";
?>

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