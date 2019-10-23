@extends('layout')

@section('content')

    <h1>Nova Laboratorija</h1>

    <form action="/lab" method="post">
        @csrf

        <div>
            <label for="ime">Ime Laboratorije</label>
            <input type="text" name="ImeLaboratorije" id="ime" required>
        </div>
        <div>
            <input type="submit" value="Kreiraj">
        </div>

    </form>

    @include('errors')
@endsection
