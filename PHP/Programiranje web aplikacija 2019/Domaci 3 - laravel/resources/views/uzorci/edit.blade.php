@extends('layout')

@section('content')
<h1>Update</h1>
<form method="POST" action="/uzorci/{{$uzorak->id}}">
    @method('PUT')
    @csrf

    <div>
        <input type="text" name="Naziv"  required value="{{$uzorak->Naziv}}">
    </div>
    <div>
        <input type="number " name="VremePrikupljanja" placeholder="VremePrikupljanja" required
            value="{{$uzorak->VremePrikupljanja}}">
    </div>
    <div>
        <input type="number " name="Sirina" placeholder="Sirina" required value="{{$uzorak->Sirina}}">
    </div>
    <div>
        <input type="number " name="Visina" placeholder="Visina" required value="{{$uzorak->Visina}}">
    </div>
    <div>
        Status:
        <select name="Status">
            <option hidden>{{$uzorak->Status}}</option>
            <option value="Na Marsu">Na Marsu</option>
            <option value="U transportu">U transportu</option>
            <option value="Na Zemlji">Na Zemlji</option>
        </select>
    </div>
    <div>
        <button type="submit">Update</button>
    </div>
    @include('errors')
</form>
@endsection
