@extends('layout')

@section('content')

    <h1>Laboratorije</h1>
    @foreach ($lab as $l)
        <ul>
            <div class="links">
                <a href="/lab/{{ $l->id}}/edit">{{$l->ImeLaboratorije}}</a>
            </div>
        </ul>
    @endforeach
@endsection
