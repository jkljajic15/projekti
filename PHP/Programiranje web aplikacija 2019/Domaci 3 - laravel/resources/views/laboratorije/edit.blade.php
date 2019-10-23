@extends('layout')

@section('content')
<h1>Izmeni labaratoriju</h1>

<form action="/lab/{{$lab->id}}" method="post">
    @csrf
    @method('put')
    <div>
        <label for="ime">Ime Laboratorije</label>
        <input type="text" name="ImeLaboratorije" id="ime" required value="{{$lab->ImeLaboratorije}}">
    </div>
    <div>
        <input type="submit" value="Izmeni">
    </div>

    @include('errors')
</form>

<div>
    <form action="/lab/{{$lab->id}}" method="post">
        @method('delete')
        @csrf
        <input type="submit" value="Izbrisi">
    </form>
</div>

@endsection